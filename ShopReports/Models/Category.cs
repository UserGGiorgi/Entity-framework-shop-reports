using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual IList<ProductTitle> Titles { get; set; }
}
