using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularMovieAPI2.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats");

            migrationBuilder.AlterColumn<int>(
                name: "ShowID",
                table: "ShowSeats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ShowID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats");

            migrationBuilder.AlterColumn<int>(
                name: "ShowID",
                table: "ShowSeats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowSeats_Shows_ShowID",
                table: "ShowSeats",
                column: "ShowID",
                principalTable: "Shows",
                principalColumn: "ShowID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
