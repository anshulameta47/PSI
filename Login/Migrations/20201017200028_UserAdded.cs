using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Sapient.Migrations
{
    public partial class UserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Gender = table.Column<char>(nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    IsdCode = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressLineOne = table.Column<string>(nullable: false),
                    AddressLineTwo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    PinCode = table.Column<int>(nullable: false),
                    UserAccountId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Role_Mappings",
                columns: table => new
                {
                    UserAccountId = table.Column<long>(nullable: false),
                    RoleId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Role_Mappings", x => new { x.UserAccountId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_User_Role_Mappings_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_Mappings_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_SecurityQuestion_Mappings",
                columns: table => new
                {
                    UserAccountId = table.Column<long>(nullable: false),
                    SecurityQuestionId = table.Column<short>(nullable: false),
                    Answer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_SecurityQuestion_Mappings", x => new { x.UserAccountId, x.SecurityQuestionId });
                    table.ForeignKey(
                        name: "FK_User_SecurityQuestion_Mappings_SecurityQuestions_SecurityQuestionId",
                        column: x => x.SecurityQuestionId,
                        principalTable: "SecurityQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_SecurityQuestion_Mappings_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "Id", "Question" },
                values: new object[] { (short)1, "What is your pet name?" });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "Id", "Question" },
                values: new object[] { (short)2, "What is your favourite dish?" });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 1L, "test1@gmail.com", "raj", 'm', false, (short)0, "kapoor", "IGuSjnsanhBXHqjlBfuc/zr5bEUF+gMJqx0cLo3qxUk=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 2L, "test2@gmail.com", "manroop", 'm', true, (short)0, "singh", "xtbgJ2u7Mnwi2ltBq8gnuj9Fs4Pc+je76k2FkWTkuIc=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 3L, "adityakhanna2009@gmail.com", "vin", 'm', true, (short)0, "diesel", "5wmsr/dFEZ182tLrRlSWAkRkpWBXeU163W52dKE8D5w=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 4L, "anshulameta@gmail.com", "charles", 'm', true, (short)0, "arthur", "pAwQoC/tCfZfJJwPJUnooqsKMld5AUs5aDveAygv4Mw=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 5L, "soni.nikhilkumar@gmail.com", "nikhil", 'm', true, (short)0, "soni", "3WKb/tDJ8RQKwN1/72hUdWtVDoMqj/IxP6/XxYQKzvI=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 6L, "amrithkhanna2010@gmail.com", "pariwesh", 'm', true, (short)0, "gupta", "7s+Jo6RqenNWecaZbluGFZo3eQkBvgGM8XBtptdQtyA=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 7L, "test4@gmail.com", "megha", 'f', true, (short)0, "gupta", "pNpb0Jiv9awBMN0qCAYK4Q05SYGgrpd7e9DA+6bn3dQ=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 8L, "test5@gmail.com", "arnab", 'm', true, (short)0, "ari", "C/Yfv0Sa9csNn4kOb1seot4qObkGlTJOVYDWPvWBtks=", 0L });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "IsActive", "IsdCode", "LastName", "Password", "Phone" },
                values: new object[] { 9L, "test6@gmail.com", "vijay", 'm', true, (short)0, "pandey", "/egXcXQpCI34wJE76eccYzYmw1p6pH5iRTH8o7MSP7g=", 0L });

            migrationBuilder.InsertData(
                table: "User_SecurityQuestion_Mappings",
                columns: new[] { "UserAccountId", "SecurityQuestionId", "Answer" },
                values: new object[] { 1L, (short)1, "Fluffy" });

            migrationBuilder.InsertData(
                table: "User_SecurityQuestion_Mappings",
                columns: new[] { "UserAccountId", "SecurityQuestionId", "Answer" },
                values: new object[] { 2L, (short)2, "chicken" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserAccountId",
                table: "Addresses",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_Mappings_RoleId",
                table: "User_Role_Mappings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SecurityQuestion_Mappings_SecurityQuestionId",
                table: "User_SecurityQuestion_Mappings",
                column: "SecurityQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "User_Role_Mappings");

            migrationBuilder.DropTable(
                name: "User_SecurityQuestion_Mappings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
