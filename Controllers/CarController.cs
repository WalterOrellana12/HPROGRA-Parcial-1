using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using walterParcial1.Models;
using walterParcial1.Services;
using walterParcial1.ViewModels;

namespace walterParcial1.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: Car
        public async Task<IActionResult> Index(string filter)
        {
            var carListVM = new CarListVM();
            var carList = await _carService.GetAll(filter);


            foreach (var item in carList)
            {
                carListVM.Cars.Add(new CarVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Year = item.Year,
                    Color = item.Color,
                    Price = item.Price,
                    Image = item.Image,
                    BrandName = item.Brand?.Name,
                    Stock = item.Stock

                });
            }
            return View(carListVM);
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var car = _carService.GetById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Car/Create
        public async Task<IActionResult> Create()
        {
            var dealershipList = await _carService.GetAllDealerships();
            if (dealershipList == null) dealershipList = new List<CarDealership>();
            ViewData["Dealerships"] = new SelectList(dealershipList, "Id", "Name");
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year,Kilometraje,Color,Price,Image,CarBrandId,DealershipIds")] CarCreateVM car)
        {
            if (ModelState.IsValid)
            {
                var dealershipList = await _carService.GetAllDealerships();
                var dealershipFilteredList = dealershipList.Where(x => car.DealershipIds.Contains(x.Id)).ToList();
                var newCar = new Car
                {
                    Name = car.Name,
                    Year = car.Year,
                    Color = car.Color,
                    Price = car.Price,
                    Image = car.Image,
                    CarBrandId = car.CarBrandId,
                    Dealerships = dealershipList

                };
                await _carService.Create(newCar);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var car = await _carService.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Kilometraje,Color,Price,Image,CarBrandId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _carService.Update(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_carService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var car = await _carService.GetById(id);
            if (id == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Purchase(int id)
        {
            var car = await _carService.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["Car"] = car;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase([Bind("CarId,Date,ClientName,Quantity,InvoiceNumber")] MovementCreateVM purchase)
        {
            if (ModelState.IsValid)
            {
                var newPurchase = new Movement
                {
                    CarId = purchase.CarId,
                    Date = purchase.Date,
                    ClientName = purchase.ClientName,
                    InvoiceNumber = purchase.InvoiceNumber,
                    Quantity = purchase.Quantity,
                    TypeM = Utils.MovementType.purchase

                };
                var response = await _carService.Purchase(newPurchase);
                if (string.IsNullOrEmpty(response))
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMag"] = response;
            }
            return View(purchase);
        }
        //GET SALE
        public async Task<IActionResult> Sale(int id)
        {
            var car = await _carService.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["Car"] = car;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST SALE
        public async Task<IActionResult> Sale([Bind("CarId,Date,ClientName,Quantity,InvoiceNumber")] MovementCreateVM sale)
        {
            if (ModelState.IsValid)
            {
                var newSale = new Movement
                {
                    CarId = sale.CarId,
                    Date = sale.Date,
                    ClientName = sale.ClientName,
                    InvoiceNumber = sale.InvoiceNumber,
                    Quantity = sale.Quantity,
                    TypeM = Utils.MovementType.sale

                };
                await _carService.Purchase(newSale);
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }
    }
}


