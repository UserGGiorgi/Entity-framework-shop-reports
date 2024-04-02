using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models;

public class PersonContact
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public int ContactTypeId { get; set; }

    public string Value { get; set; }

    public Person Person { get; set; }

    public ContactType Type { get; set; }
}
