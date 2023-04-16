using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAPI.Migrations
{
    public partial class PopulandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_POSITIONS",
                columns: new[] { "OfficeId", "Description" },
                values: new object[,]
                {
                    { 1, "Junior Developer" },
                    { 2, "Engineer Developer" },
                    { 3, "Senior Developer" },
                    { 4, "Back-End Developer" },
                    { 5, "Front-End Developer" },
                    { 6, "Full-Stack Developer" },
                    { 7, "Senior Back-End Developer" }
                });

            migrationBuilder.InsertData(
                table: "TB_EMPLOYEES",
                columns: new[] { "EmployeeId", "Cpf", "Email", "MotherName", "Name", "OfficeId", "Password", "Sex", "UserName" },
                values: new object[] { 1, "432.756.645-43", "amanda@gmail.com", "Marlene Dal Pra", "Amanda Do Espirito Santo", 2, "Neg@7699", "Fêmea", "amandaeps" });

            migrationBuilder.InsertData(
                table: "TB_ADREESSES",
                columns: new[] { "AdressId", "Cep", "City", "Complement", "EmployeeId", "Neighborhood", "Number", "Street" },
                values: new object[] { 1, "89224-475", "Joinville", "Bloco 06 apt 201", 1, "Jardim Iririu", 1215, "Areia Branca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_ADREESSES",
                keyColumn: "AdressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TB_EMPLOYEES",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_POSITIONS",
                keyColumn: "OfficeId",
                keyValue: 2);
        }
    }
}
