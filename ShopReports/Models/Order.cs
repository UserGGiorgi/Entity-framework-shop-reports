using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Order
{
    public int Id { get; set; }

    public string OperationTime { get; set; }

    public int SupermarketLocationId { get; set; }

    public int? CustomerId { get; set; }

    public SupermarketLocation SupermarketLocation { get; set; }

    public Customer? Customer { get; set; }

    public virtual IList<OrderDetail> Details { get; set; }
}
