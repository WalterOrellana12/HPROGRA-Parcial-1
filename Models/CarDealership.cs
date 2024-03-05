namespace walterParcial1.Models;

public class CarDealership
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City{get; set; }
    public int ZipCode{get; set; }
    public virtual ICollection<Car> Cars { get; set; }
}