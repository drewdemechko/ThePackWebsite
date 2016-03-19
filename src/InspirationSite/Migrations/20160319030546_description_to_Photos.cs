using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace InspirationSite.Migrations
{
    public partial class description_to_Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Photos_PackMembers_PhotoOfMemberId", table: "Photos");
            migrationBuilder.DropColumn(name: "PhotoOfMemberId", table: "Photos");
            migrationBuilder.AddColumn<int>(
                name: "PackMembersMemberId",
                table: "Photos",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Photos",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Photos_PackMembers_PackMembersMemberId",
                table: "Photos",
                column: "PackMembersMemberId",
                principalTable: "PackMembers",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Photos_PackMembers_PackMembersMemberId", table: "Photos");
            migrationBuilder.DropColumn(name: "PackMembersMemberId", table: "Photos");
            migrationBuilder.DropColumn(name: "description", table: "Photos");
            migrationBuilder.AddColumn<int>(
                name: "PhotoOfMemberId",
                table: "Photos",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Photos_PackMembers_PhotoOfMemberId",
                table: "Photos",
                column: "PhotoOfMemberId",
                principalTable: "PackMembers",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
