using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Country { get; set; }

    public virtual IList<Location> Locations { get; set; }
}
