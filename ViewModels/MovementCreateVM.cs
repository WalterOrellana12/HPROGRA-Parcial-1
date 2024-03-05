using System.ComponentModel.DataAnnotations;

namespace walterParcial1.ViewModels;

public class MovementCreateVM
{
    public string ClientName { get; set; }
    public int InvoiceNumber { get; set; }
    public int Quantity{get; set; }
    public DateTime Date { get; set; }
    public int CarId { get; set; }
}