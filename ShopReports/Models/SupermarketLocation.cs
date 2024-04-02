using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class SupermarketLocation
{
    public int Id { get; set; }

    public int SupermarketId { get; set; }

    public int LocationId { get; set; }

    public Supermarket Supermarket { get; set; }

    public Location Location { get; set; }

    public virtual IList<Order> Orders { get; set; }
}
