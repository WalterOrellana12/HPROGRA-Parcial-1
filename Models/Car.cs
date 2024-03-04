namespace walterParcial1.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int Kilometraje { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public int? CarBrandId { get; set; }
    public virtual CarBrand Brand { get; set; }

}