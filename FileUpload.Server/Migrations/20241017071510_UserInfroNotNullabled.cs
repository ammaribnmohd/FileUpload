using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUpload.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserInfroNotNullabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_UserInfos_UserInfoId",
                table: "FileAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoId",
                table: "FileAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_UserInfos_UserInfoId",
                table: "FileAttachments",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_UserInfos_UserInfoId",
                table: "FileAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoId",
                table: "FileAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_UserInfos_UserInfoId",
                table: "FileAttachments",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }
    }
}
