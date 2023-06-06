using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuPositions",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPositions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfDish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_Dishes_MenuPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "MenuPositions",
                        principalColumn: "PositionId");
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfDrink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.PositionId);
                    table.ForeignKey(
                        name: "FK_Drinks_MenuPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "MenuPositions",
                        principalColumn: "PositionId");
                });

            migrationBuilder.InsertData(
                table: "MenuPositions",
                columns: new[] { "PositionId", "Name", "PhotoLink", "Price" },
                values: new object[,]
                {
                    { new Guid("06e0d7c2-9fbb-4c5e-b1cf-3951bba9316e"), "Hamburger menu 1", "https://ik.imagekit.io/7owxt4tem/06e0d7c2-9fbb-4c5e-b1cf-3951bba9316e_updatedAt_1684869326662?updatedAt=1686002735152", 400m },
                    { new Guid("177b95a1-8ead-4fb1-8510-9bec5c89c16a"), "Dorado", "https://ik.imagekit.io/7owxt4tem/177b95a1-8ead-4fb1-8510-9bec5c89c16a_updatedAt_1684828620582?updatedAt=1686003053586", 400m },
                    { new Guid("2a287245-da79-4f6f-9bca-29c4fd1c8b05"), "Grilled fish", "https://ik.imagekit.io/7owxt4tem/2a287245-da79-4f6f-9bca-29c4fd1c8b05_updatedAt_1684828669643?updatedAt=1686002999534", 500m },
                    { new Guid("349ac30a-ffa1-4c2f-a871-a172100d5dd7"), "Kebab", "https://ik.imagekit.io/7owxt4tem/349ac30a-ffa1-4c2f-a871-a172100d5dd7_updatedAt_1684828595451?updatedAt=1686002882783", 400m },
                    { new Guid("78506416-6bc4-469e-9b03-1e2cf5b708a3"), "Steak", "https://ik.imagekit.io/7owxt4tem/78506416-6bc4-469e-9b03-1e2cf5b708a3_updatedAt_1684828867102?updatedAt=1686002839959", 600m },
                    { new Guid("7bdc8f1d-6677-4065-8425-218e4c8bac36"), "Fried with tomato souce", "https://ik.imagekit.io/7owxt4tem/7bdc8f1d-6677-4065-8425-218e4c8bac36_updatedAt_1684828713325?updatedAt=1686002966679", 700m },
                    { new Guid("860617fd-d341-41d2-a494-d982e8ae1f84"), "Hamburger menu 3", "https://ik.imagekit.io/7owxt4tem/860617fd-d341-41d2-a494-d982e8ae1f84_updatedAt_1684869385003?updatedAt=1686002789666", 550m },
                    { new Guid("94ba0fbc-76ec-4eac-9b48-5ff5859da457"), "Hamburger menu 2", "https://ik.imagekit.io/7owxt4tem/94ba0fbc-76ec-4eac-9b48-5ff5859da457_updatedAt_1684869350144?updatedAt=1686002762114", 450m },
                    { new Guid("a23bcec4-d07c-4e6a-a131-43a064066304"), "Chef summer fish", "https://ik.imagekit.io/7owxt4tem/a23bcec4-d07c-4e6a-a131-43a064066304_updatedAt_1684828784696?updatedAt=1686003079826", 500m },
                    { new Guid("a680749e-8e43-4877-9fe4-cb7b3caf130d"), "Hamburger menu 4", "https://ik.imagekit.io/7owxt4tem/a680749e-8e43-4877-9fe4-cb7b3caf130d_updatedAt_1684828898277?updatedAt=1686002815166", 500m },
                    { new Guid("c5d0bd03-f244-4429-b59c-181268153359"), "Salmon", "https://ik.imagekit.io/7owxt4tem/c5d0bd03-f244-4429-b59c-181268153359_updatedAt_1684828638160?updatedAt=1686002938650", 600m },
                    { new Guid("d0d023f5-aea2-4b19-9b18-f949b02ea87d"), "Nugets", "https://ik.imagekit.io/7owxt4tem/d0d023f5-aea2-4b19-9b18-f949b02ea87d_updatedAt_1684828605346?updatedAt=1686002912137", 300m },
                    { new Guid("fa744911-5fc6-486a-9cd4-3a09c539a31e"), "Easter fish", "https://ik.imagekit.io/7owxt4tem/fa744911-5fc6-486a-9cd4-3a09c539a31e_updatedAt_1684828749243?updatedAt=1686003027414", 650m },
                    { new Guid("17a3c19e-1575-4a69-ae89-46059cce8dc7"), "Herbal tea", "https://ik.imagekit.io/7owxt4tem/17a3c19e-1575-4a69-ae89-46059cce8dc7?updatedAt=1686002693678", 100m },
                    { new Guid("2708e10a-b0cd-41b9-8ed2-0a8de5d864dd"), "Pineapple juice", "https://ik.imagekit.io/7owxt4tem/2708e10a-b0cd-41b9-8ed2-0a8de5d864dd?updatedAt=1686002614056", 130m },
                    { new Guid("47d6710b-32e5-429d-8723-e7971f6bef17"), "Orange juice", "https://ik.imagekit.io/7owxt4tem/47d6710b-32e5-429d-8723-e7971f6bef17?updatedAt=1686002553057", 130m },
                    { new Guid("ab10d367-35f4-4da6-ab7f-01413eddd8d4"), "Apple juice", "https://ik.imagekit.io/7owxt4tem/ab10d367-35f4-4da6-ab7f-01413eddd8d4?updatedAt=1686002586188", 130m },
                    { new Guid("b46d3334-e53f-4dfa-bea9-3a1aef72d5d1"), "Black tea", "https://ik.imagekit.io/7owxt4tem/b46d3334-e53f-4dfa-bea9-3a1aef72d5d1?updatedAt=1686002644091", 100m },
                    { new Guid("cc26f172-64bd-4b14-aeca-2ffe1f7d4d63"), "Latte", "https://ik.imagekit.io/7owxt4tem/cc26f172-64bd-4b14-aeca-2ffe1f7d4d63?updatedAt=1686002522820", 140m },
                    { new Guid("cdc8e3c4-42c5-47e9-932d-5d196c04351e"), "Espresso", "https://ik.imagekit.io/7owxt4tem/cdc8e3c4-42c5-47e9-932d-5d196c04351e_updatedAt_1684867378345?updatedAt=1686002415749", 100m },
                    { new Guid("ce5db9df-0c47-4bfc-9d5f-1412cf7dc856"), "Green tea", "https://ik.imagekit.io/7owxt4tem/ce5db9df-0c47-4bfc-9d5f-1412cf7dc856?updatedAt=1686002666709", 150m },
                    { new Guid("eb80cd9d-6586-4d76-ae91-a8e6bf5c8b5e"), "Cappuccino", "https://ik.imagekit.io/7owxt4tem/eb80cd9d-6586-4d76-ae91-a8e6bf5c8b5e?updatedAt=1686002487487", 130m }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "PositionId", "TypeOfDish", "Weight" },
                values: new object[,]
                {
                    { new Guid("06e0d7c2-9fbb-4c5e-b1cf-3951bba9316e"), "Burger", 350.0 },
                    { new Guid("177b95a1-8ead-4fb1-8510-9bec5c89c16a"), "Fish", 250.0 },
                    { new Guid("2a287245-da79-4f6f-9bca-29c4fd1c8b05"), "Fish", 250.0 },
                    { new Guid("349ac30a-ffa1-4c2f-a871-a172100d5dd7"), "Meat", 350.0 },
                    { new Guid("78506416-6bc4-469e-9b03-1e2cf5b708a3"), "Meat", 500.0 },
                    { new Guid("7bdc8f1d-6677-4065-8425-218e4c8bac36"), "Fish", 250.0 },
                    { new Guid("860617fd-d341-41d2-a494-d982e8ae1f84"), "Burger", 450.0 },
                    { new Guid("94ba0fbc-76ec-4eac-9b48-5ff5859da457"), "Burger", 400.0 },
                    { new Guid("a23bcec4-d07c-4e6a-a131-43a064066304"), "Fish", 250.0 },
                    { new Guid("a680749e-8e43-4877-9fe4-cb7b3caf130d"), "Burger", 400.0 },
                    { new Guid("c5d0bd03-f244-4429-b59c-181268153359"), "Fish", 250.0 },
                    { new Guid("d0d023f5-aea2-4b19-9b18-f949b02ea87d"), "Meat", 250.0 },
                    { new Guid("fa744911-5fc6-486a-9cd4-3a09c539a31e"), "Fish", 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "PositionId", "TypeOfDrink", "Volume" },
                values: new object[,]
                {
                    { new Guid("17a3c19e-1575-4a69-ae89-46059cce8dc7"), "Tea", 150.0 },
                    { new Guid("2708e10a-b0cd-41b9-8ed2-0a8de5d864dd"), "Juice", 200.0 },
                    { new Guid("47d6710b-32e5-429d-8723-e7971f6bef17"), "Juice", 200.0 },
                    { new Guid("ab10d367-35f4-4da6-ab7f-01413eddd8d4"), "Juice", 200.0 },
                    { new Guid("b46d3334-e53f-4dfa-bea9-3a1aef72d5d1"), "Tea", 150.0 },
                    { new Guid("cc26f172-64bd-4b14-aeca-2ffe1f7d4d63"), "Coffe", 50.0 },
                    { new Guid("cdc8e3c4-42c5-47e9-932d-5d196c04351e"), "Coffe", 30.0 },
                    { new Guid("ce5db9df-0c47-4bfc-9d5f-1412cf7dc856"), "Tea", 150.0 },
                    { new Guid("eb80cd9d-6586-4d76-ae91-a8e6bf5c8b5e"), "Coffe", 50.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "MenuPositions");
        }
    }
}
