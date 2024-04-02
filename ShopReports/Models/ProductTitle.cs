using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class ProductTitle
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public virtual IList<Product> Products { get; set; }
}
