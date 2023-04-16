using System.Text.Json.Serialization;

namespace EmployeeAPI.Models
{
    public class Positions
    {
        public int OfficeId { get; set; }
        public string Description { get; set; } = null!;

        public ICollection<Employee>? Employee { get; set; }
    }
}
