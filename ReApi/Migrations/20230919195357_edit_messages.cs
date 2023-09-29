using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReApi.Migrations
{
    /// <inheritdoc />
    public partial class edit_messages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Messagess",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "Emaail",
                table: "Messagess",
                newName: "MessageDescription");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Messagess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Messagess");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Messagess",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "MessageDescription",
                table: "Messagess",
                newName: "Emaail");
        }
    }
}
