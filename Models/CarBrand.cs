namespace walterParcial1.Models;

public class CarBrand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country{get; set; }
    public virtual ICollection<Car> Cars { get; set; }
}