using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class CustomerReportService : IDisposable
{
    private readonly ShopContext shopContext;

    public CustomerReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext;
    }

    public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
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
