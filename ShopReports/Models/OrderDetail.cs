using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public double PriceWithDiscount { get; set; }

    public int ProductAmount { get; set; }

    public Order Order { get; set; }

    public Product Product { get; set; }
}
