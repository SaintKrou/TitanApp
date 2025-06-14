using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TitanApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    PurchasedSessions = table.Column<int>(type: "INTEGER", nullable: false),
                    SubscriptionEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Telegram = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Unlimited = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SessionsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Unlimited = table.Column<bool>(type: "INTEGER", nullable: false),
                    DurationMonths = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseName = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NewSubscriptionEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionsAdded = table.Column<int>(type: "INTEGER", nullable: true),
                    Unlimited = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionLogs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionLogs_ClientId",
                table: "SubscriptionLogs",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "SubscriptionLogs");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
