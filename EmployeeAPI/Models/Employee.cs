namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string? Sex { get; set; }
        public string MotherName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int OfficeId { get; set; }

        public Adress? Adress { get; set; }
        public Positions? Office { get; set; }
    }
}
