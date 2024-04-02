using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Customer
{
    public int Id { get; set; }

    public string CardNumber { get; set; }

    public decimal Discount { get; set; }

    public Person Person { get; set; }

    public virtual IList<Order> Orders { get; set; }
}
