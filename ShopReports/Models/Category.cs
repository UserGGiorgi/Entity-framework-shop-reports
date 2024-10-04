using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;
[Table("product_categories", Schema = "Shop")]
public class Category
{
    [Key]
    [Column("category_id")]
    public int Id { get; set; }

    [Column("category_name")]
    public string Name { get; set; }

    [Column("titles")]
    public virtual IList<ProductTitle> Titles { get; set; }
}
