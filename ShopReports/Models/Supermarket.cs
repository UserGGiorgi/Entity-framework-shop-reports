using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Supermarket
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual IList<SupermarketLocation> Locations { get; set; }
}
