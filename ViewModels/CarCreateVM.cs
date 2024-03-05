using System.ComponentModel.DataAnnotations;

namespace walterParcial1.ViewModels;

public class CarCreateVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public int? CarBrandId { get; set; }
    [Display(Name = "Marca")]
    public string? BrandName {get; set; }
    public List<int> DealershipIds{get; set; }
}