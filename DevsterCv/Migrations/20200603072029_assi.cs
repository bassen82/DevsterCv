using Microsoft.EntityFrameworkCore.Migrations;

namespace DevsterCv.Migrations
{
    public partial class assi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assigments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Employeeid = table.Column<int>(nullable: false),
                    Uppdrag = table.Column<string>(nullable: true),
                    Tid = table.Column<string>(nullable: true),
                    Roll = table.Column<string>(nullable: true),
                    Beskrivning = table.Column<string>(nullable: true),
                    Teknik = table.Column<string>(nullable: true),
                    Focus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyAdress = table.Column<string>(nullable: true),
                    CompanyPostalAdress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(nullable: false),
                    Tele = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    ExpertiseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.ExpertiseId);
                });

            migrationBuilder.CreateTable(
                name: "Middlewares",
                columns: table => new
                {
                    MiddlewareId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Middlewares", x => x.MiddlewareId);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    TechniqueId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.TechniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeId);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsDegree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    ProfileCompany = table.Column<string>(nullable: true),
                    ProfileCompanyAdress = table.Column<string>(nullable: true),
                    ProfileCompanyPostalAdress = table.Column<string>(nullable: true),
                    EmployeeInfo = table.Column<string>(nullable: true),
                    EmployeRole = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AssigmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Assigments_AssigmentId",
                        column: x => x.AssigmentId,
                        principalTable: "Assigments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExpertises",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    ExpertiseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExpertises", x => new { x.EmployeeId, x.ExpertiseId });
                    table.ForeignKey(
                        name: "FK_EmployeeExpertises_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeExpertises_Expertises_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "ExpertiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMiddlewares",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    MiddlewareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMiddlewares", x => new { x.EmployeeId, x.MiddlewareId });
                    table.ForeignKey(
                        name: "FK_EmployeeMiddlewares_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMiddlewares_Middlewares_MiddlewareId",
                        column: x => x.MiddlewareId,
                        principalTable: "Middlewares",
                        principalColumn: "MiddlewareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTechniques",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    TechniqueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTechniques", x => new { x.EmployeeId, x.TechniqueId });
                    table.ForeignKey(
                        name: "FK_EmployeeTechniques_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTechniques_Techniques_TechniqueId",
                        column: x => x.TechniqueId,
                        principalTable: "Techniques",
                        principalColumn: "TechniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTrades",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    TradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTrades", x => new { x.EmployeeId, x.TradeId });
                    table.ForeignKey(
                        name: "FK_EmployeeTrades_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTrades_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "TradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTrainings",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    TrainingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTrainings", x => new { x.EmployeeId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_EmployeeTrainings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpertises_ExpertiseId",
                table: "EmployeeExpertises",
                column: "ExpertiseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMiddlewares_MiddlewareId",
                table: "EmployeeMiddlewares",
                column: "MiddlewareId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AssigmentId",
                table: "Employees",
                column: "AssigmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTechniques_TechniqueId",
                table: "EmployeeTechniques",
                column: "TechniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrades_TradeId",
                table: "EmployeeTrades",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrainings_TrainingId",
                table: "EmployeeTrainings",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "EmployeeExpertises");

            migrationBuilder.DropTable(
                name: "EmployeeMiddlewares");

            migrationBuilder.DropTable(
                name: "EmployeeTechniques");

            migrationBuilder.DropTable(
                name: "EmployeeTrades");

            migrationBuilder.DropTable(
                name: "EmployeeTrainings");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Middlewares");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Assigments");
        }
    }
}
