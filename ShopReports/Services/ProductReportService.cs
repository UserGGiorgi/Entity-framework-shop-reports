using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class ProductReportService : IDisposable
{
    private readonly bool disposed = false;
    private readonly ShopContext shopContext;

    public ProductReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext;
    }

    public ProductCategoryReport GetProductCategoryReport()
    {
        var productCategories = this.shopContext.Categories
            .OrderBy(pc => pc.Name)
            .Select(pc => new ProductCategoryReportLine
            {
                CategoryId = pc.Id,
                CategoryName = pc.Name,
            })
            .ToList();

        return new ProductCategoryReport(productCategories, DateTime.Now);
    }

    public ProductReport GetProductReport()
    {
        var product = this.shopContext.Products
            .OrderByDescending(p => p.Title)
            .Select(p => new ProductReportLine
            {
                ProductId = p.Id,
                ProductTitle = this.shopContext.Titles.Where(t => t.Id == p.TitleId).Select(t => t.Title).FirstOrDefault() ?? "Null",
                Manufacturer = this.shopContext.Manufacturers.Where(m => m.Id == p.ManufacturerId).Select(m => m.Name).FirstOrDefault() ?? "Null",
                Price = p.UnitPrice,
            })
            .ToList();

        return new ProductReport(product, DateTime.Now);
    }

    public FullProductReport GetFullProductReport()
    {
        var product = this.shopContext.Products
            .OrderBy(p => p.Title)
            .Select(p => new FullProductReportLine
            {
                ProductId = p.Id,
                Name = this.shopContext.Titles.Where(t => t.Id == p.TitleId).Select(t => t.Title).FirstOrDefault() ?? "Null",
                Manufacturer = this.shopContext.Manufacturers.Where(m => m.Id == p.ManufacturerId).Select(m => m.Name).FirstOrDefault() ?? "Null",
                CategoryId = this.shopContext.Titles.Where(t => t.Id == p.TitleId).Select(m => m.CategoryId).FirstOrDefault(),
                Category = this.shopContext.Categories.Where(c => c.Id == this.shopContext.Titles.Where(t => t.Id == p.TitleId).Select(m => m.CategoryId).FirstOrDefault()).Select(c => c.Name).FirstOrDefault() ?? "Null",
                Price = p.UnitPrice,
            })
            .ToList();

        return new FullProductReport(product, DateTime.Now);
    }

    public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
    {
        var product = this.shopContext.Products
            .GroupBy(p => p.TitleId)
            .Select(g => new ProductTitleSalesRevenueReportLine
            {
                ProductTitleName = this.shopContext.Titles
                .Where(t => t.Id == g.Key)
                .Select(t => t.Title)
                .FirstOrDefault() ?? "Null",

                SalesRevenue = g.Sum(p => p.OrderDetails.Sum(o => o.PriceWithDiscount)),
                SalesAmount = g.Sum(p => p.OrderDetails.Sum(o => o.ProductAmount)),
            })
            .OrderByDescending(p => p.SalesRevenue)
            .ToList();

        return new ProductTitleSalesRevenueReport(product, DateTime.Now);
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing && this.shopContext != null)
        {
                this.shopContext.Dispose();
        }
    }
}
