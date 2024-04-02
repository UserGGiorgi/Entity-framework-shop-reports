using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class ProductReportService : IDisposable
{
    private readonly ShopContext shopContext;

    public ProductReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext;
    }

    public ProductCategoryReport GetProductCategoryReport()
    {
        // TODO Implement the service method.
        throw new NotImplementedException();
    }

    public ProductReport GetProductReport()
    {
        // TODO Implement the service method.
        throw new NotImplementedException();
    }

    public FullProductReport GetFullProductReport()
    {
        // TODO Implement the service method.
        throw new NotImplementedException();
    }

    public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
    {
        // TODO Implement the service method.
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        throw new NotImplementedException();
    }
}
