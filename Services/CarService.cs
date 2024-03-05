using Microsoft.EntityFrameworkCore;
using walterParcial1.Models;
namespace walterParcial1.Services;

public class CarService : ICarService
{
    private readonly CarContext _context;
    public CarService(CarContext context)
    {
        _context = context;
    }
    public async Task Create(Car car)
    {
        _context.Add(car);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var car = await _context.Car.FindAsync(id);
        if (car != null)
        {
            _context.Car.Remove(car);
        }
        await _context.SaveChangesAsync();
    }
    public async Task<List<Car>> GetAll(string filter)
    {
        var query = from car in _context.Car select car;
        query = query.Include(x => x.Brand);

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        return await query.ToListAsync();
    }
    public async Task<List<CarDealership>> GetAllDealerships()
    {
        return await _context.CarDealership.ToListAsync();
    }
    public async Task<Car?> GetById(int? id)
    {
        if (id == null || _context.Car == null)
        {
            return null;
        }

        return await _context.Car
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Car car)
    {
        _context.Update(car);
        await _context.SaveChangesAsync();
    }

    public async Task<string> Purchase(Movement movement)
    {
         return await CreateMovement(movement);
    }

    public async Task<String> Sale(Movement movement)
    {
         return await CreateMovement(movement);
    }
    private async Task <string> CreateMovement(Movement movement)
    {
        var stock = movement.Quantity;
        var car = await _context.Car.FirstOrDefaultAsync(m => m.Id == movement.CarId);
        if(movement.TypeM == Utils.MovementType.sale)
        {
           stock*= -1;
           if((car.Stock + stock) < 0){
            return "No hay stock disponible para " + car.Name;
           }
        }

        if (car is null)
        {
            return "El juego no existe";
        }

        car.Stock += stock;
            _context.Update(car);
            _context.Add(movement);
            await _context.SaveChangesAsync();

            return string.Empty;
    }
}