using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrailerOrder.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Tractors",
                columns: table => new
                {
                    TractorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TruckNumber = table.Column<string>(nullable: true),
                    TractorMake = table.Column<string>(nullable: true),
                    TractorModel = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    VinNumber = table.Column<string>(nullable: true),
                    PlateNumber = table.Column<string>(nullable: true),
                    DotInp = table.Column<DateTime>(nullable: false),
                    RegDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    DateReturned = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tractors", x => x.TractorID);
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(nullable: true),
                    TrailerNumber = table.Column<string>(nullable: true),
                    TrailerMake = table.Column<string>(nullable: true),
                    TrailerModel = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    InspDate = table.Column<DateTime>(nullable: false),
                    TrailerStatus = table.Column<string>(nullable: true),
                    TrailerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.TrailerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    SsnConfirm = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    LicNumber = table.Column<string>(nullable: true),
                    LicIssue = table.Column<DateTime>(nullable: false),
                    LicExpire = table.Column<DateTime>(nullable: false),
                    MedCardNumber = table.Column<string>(nullable: true),
                    MedIssue = table.Column<DateTime>(nullable: false),
                    MedExpire = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordConf = table.Column<string>(nullable: true),
                    DotCompliant = table.Column<bool>(nullable: false),
                    WorkStatus = table.Column<string>(nullable: true),
                    OrderID = table.Column<int>(nullable: false),
                    TractorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Tractors_TractorID",
                        column: x => x.TractorID,
                        principalTable: "Tractors",
                        principalColumn: "TractorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverTractorsAssignmentHistory",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    TractorId = table.Column<int>(nullable: false),
                    TractorNumber = table.Column<string>(nullable: true),
                    DateTimeAssigned = table.Column<DateTime>(nullable: false),
                    DateTimeUnassigned = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTractorsAssignmentHistory", x => new { x.EmployeeId, x.TractorId });
                    table.ForeignKey(
                        name: "FK_DriverTractorsAssignmentHistory_Tractors_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Tractors",
                        principalColumn: "TractorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverTractorsAssignmentHistory_Employees_TractorId",
                        column: x => x.TractorId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<string>(nullable: true),
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrailerForLoadID = table.Column<int>(nullable: false),
                    CustomerOrdersID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    DateDelivered = table.Column<DateTime>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerOrdersID",
                        column: x => x.CustomerOrdersID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Trailers_TrailerForLoadID",
                        column: x => x.TrailerForLoadID,
                        principalTable: "Trailers",
                        principalColumn: "TrailerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverTractorsAssignmentHistory_TractorId",
                table: "DriverTractorsAssignmentHistory",
                column: "TractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TractorID",
                table: "Employees",
                column: "TractorID",
                unique: true,
                filter: "[TractorID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerOrdersID",
                table: "Orders",
                column: "CustomerOrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TrailerForLoadID",
                table: "Orders",
                column: "TrailerForLoadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverTractorsAssignmentHistory");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "Tractors");
        }
    }
}
