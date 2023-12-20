using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fodders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fodders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fodders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinTemperature = table.Column<float>(type: "real", nullable: false),
                    MaxTemperature = table.Column<float>(type: "real", nullable: false),
                    MinHumidity = table.Column<float>(type: "real", nullable: false),
                    MaxHumidity = table.Column<float>(type: "real", nullable: false),
                    MinLivingSpace = table.Column<float>(type: "real", nullable: false),
                    LifeSpan = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivingPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    LivingSpace = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivingPlaces_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsectFodders",
                columns: table => new
                {
                    InsectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FodderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FodderConsumptionVolume = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsectFodders", x => new { x.InsectId, x.FodderId });
                    table.ForeignKey(
                        name: "FK_InsectFodders_Fodders_FodderId",
                        column: x => x.FodderId,
                        principalTable: "Fodders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InsectFodders_Insects_InsectId",
                        column: x => x.InsectId,
                        principalTable: "Insects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InsectLivingPlases",
                columns: table => new
                {
                    InsectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivingPlaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsectCount = table.Column<int>(type: "int", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivingPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsectLivingPlases", x => new { x.InsectId, x.LivingPlaseId });
                    table.ForeignKey(
                        name: "FK_InsectLivingPlases_Insects_InsectId",
                        column: x => x.InsectId,
                        principalTable: "Insects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InsectLivingPlases_LivingPlaces_LivingPlaceId",
                        column: x => x.LivingPlaceId,
                        principalTable: "LivingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LivingPlaseFodders",
                columns: table => new
                {
                    FodderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivingPlaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FodderVolume = table.Column<float>(type: "real", nullable: false),
                    LivingPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingPlaseFodders", x => new { x.LivingPlaseId, x.FodderId });
                    table.ForeignKey(
                        name: "FK_LivingPlaseFodders_Fodders_FodderId",
                        column: x => x.FodderId,
                        principalTable: "Fodders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LivingPlaseFodders_LivingPlaces_LivingPlaceId",
                        column: x => x.LivingPlaceId,
                        principalTable: "LivingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
        });

            migrationBuilder.CreateIndex(
                name: "IX_Fodders_UserId",
                table: "Fodders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InsectFodders_FodderId",
                table: "InsectFodders",
                column: "FodderId");

            migrationBuilder.CreateIndex(
                name: "IX_InsectLivingPlases_LivingPlaceId",
                table: "InsectLivingPlases",
                column: "LivingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Insects_UserId",
                table: "Insects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LivingPlaces_UserId",
                table: "LivingPlaces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LivingPlaseFodders_FodderId",
                table: "LivingPlaseFodders",
                column: "FodderId");

            migrationBuilder.CreateIndex(
                name: "IX_LivingPlaseFodders_LivingPlaceId",
                table: "LivingPlaseFodders",
                column: "LivingPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsectFodders");

            migrationBuilder.DropTable(
                name: "InsectLivingPlases");

            migrationBuilder.DropTable(
                name: "LivingPlaseFodders");

            migrationBuilder.DropTable(
                name: "Insects");

            migrationBuilder.DropTable(
                name: "Fodders");

            migrationBuilder.DropTable(
                name: "LivingPlaces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
