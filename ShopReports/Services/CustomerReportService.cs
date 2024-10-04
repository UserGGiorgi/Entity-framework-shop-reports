using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services;

public class CustomerReportService : IDisposable
{
    private readonly bool disposed = false;
    private readonly ShopContext shopContext;

    public CustomerReportService(ShopContext shopContext)
    {
        this.shopContext = shopContext ?? throw new ArgumentNullException(nameof(shopContext));
    }

    public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
    {
        var customer = this.shopContext.Customers
            .OrderByDescending(c => c.Discount)
            .Select(c => new CustomerSalesRevenueReportLine
            {
                CustomerId = c.Id,
                PersonFirstName = c.Person.FirstName,
                PersonLastName = c.Person.LastName,
                SalesRevenue = c.Orders.
                SelectMany(o => o.Details)
                .Sum(d => d.PriceWithDiscount),
            })
            .ToList();
        return new CustomerSalesRevenueReport(customer, DateTime.Now);
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

        if (disposing)
        {
            if (this.shopContext != null)
            {
                this.shopContext.Dispose();
            }
        }

        disposing = true;
    }
}
