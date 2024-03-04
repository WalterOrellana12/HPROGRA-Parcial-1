namespace walterParcial1.ViewModels;

public class CarListVM
{
    public List<CarVM> Cars {get; set; } = new List<CarVM>();
    public string? Filter {get; set; }
}