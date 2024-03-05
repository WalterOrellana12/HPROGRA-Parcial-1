using walterParcial1.Models;
namespace walterParcial1.Services;

public interface ICarService
{
    Task<List<Car>> GetAll(string filter);
    Task Update(Car car);
    Task Delete(int id);
    Task Create(Car car);
    Task<Car> GetById(int? id);
    Task<List<CarDealership>> GetAllDealerships();
    Task <string>Purchase(Movement movement);
    Task <string>Sale(Movement movement);
}