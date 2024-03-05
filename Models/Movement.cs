using walterParcial1.Utils;
namespace walterParcial1.Models;


public class Movement
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public int InvoiceNumber { get; set; }
    public DateTime Date { get; set; }
    public MovementType TypeM { get; set; }
    public int Quantity { get; set; }
    public int CarId { get; set; }
    public virtual Car Car { get; set; }
}
