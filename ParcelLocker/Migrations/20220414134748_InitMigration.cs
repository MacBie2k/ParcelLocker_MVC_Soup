using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ParcelLocker.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "complaint_reasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complaint_reasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lockers",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(767)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lockers", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "parcels",
                columns: table => new
                {
                    parcel_number = table.Column<string>(type: "varchar(767)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    pickup_code = table.Column<string>(type: "text", nullable: false),
                    sender_phone = table.Column<string>(type: "text", nullable: false),
                    sender_email = table.Column<string>(type: "text", nullable: false),
                    receiver_phone = table.Column<string>(type: "text", nullable: false),
                    receiver_email = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    locker = table.Column<string>(type: "varchar(767)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcels", x => x.parcel_number);
                    table.ForeignKey(
                        name: "FK_parcels_lockers_locker",
                        column: x => x.locker,
                        principalTable: "lockers",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "complaints",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    parcel_number = table.Column<string>(type: "varchar(767)", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complaints", x => x.id);
                    table.ForeignKey(
                        name: "FK_complaints_parcels_parcel_number",
                        column: x => x.parcel_number,
                        principalTable: "parcels",
                        principalColumn: "parcel_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintComplaintReason",
                columns: table => new
                {
                    ComplaintsId = table.Column<int>(type: "int", nullable: false),
                    ReasonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintComplaintReason", x => new { x.ComplaintsId, x.ReasonsId });
                    table.ForeignKey(
                        name: "FK_ComplaintComplaintReason_complaint_reasons_ReasonsId",
                        column: x => x.ReasonsId,
                        principalTable: "complaint_reasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintComplaintReason_complaints_ComplaintsId",
                        column: x => x.ComplaintsId,
                        principalTable: "complaints",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintComplaintReason_ReasonsId",
                table: "ComplaintComplaintReason",
                column: "ReasonsId");

            migrationBuilder.CreateIndex(
                name: "IX_complaints_parcel_number",
                table: "complaints",
                column: "parcel_number");

            migrationBuilder.CreateIndex(
                name: "IX_parcels_locker",
                table: "parcels",
                column: "locker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintComplaintReason");

            migrationBuilder.DropTable(
                name: "complaint_reasons");

            migrationBuilder.DropTable(
                name: "complaints");

            migrationBuilder.DropTable(
                name: "parcels");

            migrationBuilder.DropTable(
                name: "lockers");
        }
    }
}
