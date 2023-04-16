using System.Text.Json.Serialization;

namespace EmployeeAPI.Models
{
    public class Adress
    {
        public int AdressId { get; set; }
        public string Cep { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int Number { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; } = null!; 
        public string City { get; set; } = null!;
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
