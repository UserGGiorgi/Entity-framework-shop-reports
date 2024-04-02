using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Product
{
    public int Id { get; set; }

    public int TitleId { get; set; }

    public int ManufacturerId { get; set; }

    public int SupplierId { get; set; }

    public decimal UnitPrice { get; set; }

    public string Description { get; set; }

    public ProductTitle Title { get; set; }

    public Manufacturer Manufacturer { get; set; }

    public Supplier Supplier { get; set; }

    public virtual IList<OrderDetail> OrderDetails { get; set; }
}
