﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;
[Table("shop_products", Schema = "Shop")]
public class Product
{
    [Key]
    [Column("product_id")]
    public int Id { get; set; }

    [ForeignKey("Title")]
    [Column("product_title_id")]
    public int TitleId { get; set; }

    [ForeignKey("Manufacturer")]
    [Column("product_manufacturer_id")]
    public int ManufacturerId { get; set; }

    [ForeignKey("Supplier")]
    [Column("product_supplier_id")]
    public int SupplierId { get; set; }

    [Column("unit_price")]
    public decimal UnitPrice { get; set; }

    [Column("comment")]
    public string Description { get; set; }

    [Column("title")]
    public ProductTitle Title { get; set; }

    [Column("manufacturer")]
    public Manufacturer Manufacturer { get; set; }

    [Column("suplier")]
    public Supplier Supplier { get; set; }

    [Column("orderDetails")]
    public virtual IList<OrderDetail> OrderDetails { get; set; }
}
