using walterParcial1.ViewModels;

namespace walterParcial1.ViewModels;

public class BrandListVM
{
    public List<BrandVM> Brands { get; set; } = new List<BrandVM>();
    public string? Filter { get; set; }
}