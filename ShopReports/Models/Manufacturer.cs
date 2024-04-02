using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual IList<Product> Products { get; set; }
}
