using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Location
{
    public int Id { get; set; }

    public string Address { get; set; }

    public int CityId { get; set; }

    public City City { get; set; }

    public virtual IList<SupermarketLocation> Supermarkets { get; set; }
}
