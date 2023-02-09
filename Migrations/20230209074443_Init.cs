using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkflowCore.Persistence.Oracle.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HLV_EMAIL_PRO");

            migrationBuilder.CreateTable(
                name: "WF_EVENT",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EVENTID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    EVENTNAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EVENTKEY = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EVENTDATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EVENTTIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ISPROCESSED = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_EVENT", x => x.PERSISTENCEID);
                });

            migrationBuilder.CreateTable(
                name: "WF_EXECUTIONERROR",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    WORKFLOWID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    EXECUTIONPOINTERID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ERRORTIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MESSAGE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_EXECUTIONERROR", x => x.PERSISTENCEID);
                });

            migrationBuilder.CreateTable(
                name: "WF_SCHEDULEDCOMMAND",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    COMMANDNAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    DATAVALUE = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    EXECUTETIME = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_SCHEDULEDCOMMAND", x => x.PERSISTENCEID);
                });

            migrationBuilder.CreateTable(
                name: "WF_SUBSCRIPTION",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SUBSCRIPTIONID = table.Column<Guid>(type: "RAW(16)", maxLength: 200, nullable: false),
                    WORKFLOWID = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    STEPID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EXECUTIONPOINTERID = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EVENTNAME = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EVENTKEY = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    SUBSCRIBEASOF = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SUBSCRIPTIONDATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EXTERNALTOKEN = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EXTERNALWORKERID = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EXTERNALTOKENEXPIRY = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_SUBSCRIPTION", x => x.PERSISTENCEID);
                });

            migrationBuilder.CreateTable(
                name: "WF_WORKFLOW",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    INSTANCEID = table.Column<Guid>(type: "RAW(16)", maxLength: 200, nullable: false),
                    WORKFLOWDEFINITIONID = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    VERSION = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    REFERENCE = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    NEXTEXECUTION = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DATAVALUE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CREATETIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    COMPLETETIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_WORKFLOW", x => x.PERSISTENCEID);
                });

            migrationBuilder.CreateTable(
                name: "WF_EXECUTIONPOINTER",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    WORKFLOWID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    STEPID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SLEEPUNTIL = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    PERSISTENCEDATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STARTTIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ENDTIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EVENTNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    EVENTKEY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    EVENTPUBLISHED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    EVENTDATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STEPNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    RETRYCOUNT = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CHILDREN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CONTEXTITEM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PREDECESSORID = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    OUTCOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SCOPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_EXECUTIONPOINTER", x => x.PERSISTENCEID);
                    table.ForeignKey(
                        name: "FK_WF_001",
                        column: x => x.WORKFLOWID,
                        principalSchema: "HLV_EMAIL_PRO",
                        principalTable: "WF_WORKFLOW",
                        principalColumn: "PERSISTENCEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WF_EXTENSIONATTRIBUTE",
                schema: "HLV_EMAIL_PRO",
                columns: table => new
                {
                    PERSISTENCEID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EXECUTIONPOINTERID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ATTRIBUTEKEY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ATTRIBUTEVALUE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WF_EXTENSIONATTRIBUTE", x => x.PERSISTENCEID);
                    table.ForeignKey(
                        name: "FK_WF_002",
                        column: x => x.EXECUTIONPOINTERID,
                        principalSchema: "HLV_EMAIL_PRO",
                        principalTable: "WF_EXECUTIONPOINTER",
                        principalColumn: "PERSISTENCEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WF_001",
                schema: "HLV_EMAIL_PRO",
                table: "WF_EVENT",
                column: "EVENTID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WF_002",
                schema: "HLV_EMAIL_PRO",
                table: "WF_EVENT",
                columns: new[] { "EVENTNAME", "EVENTKEY" });

            migrationBuilder.CreateIndex(
                name: "IX_WF_003",
                schema: "HLV_EMAIL_PRO",
                table: "WF_EVENT",
                column: "EVENTTIME");

            migrationBuilder.CreateIndex(
                name: "IX_WF_004",
                schema: "HLV_EMAIL_PRO",
                table: "WF_EVENT",
                column: "ISPROCESSED");

            migrationBuilder.CreateIndex(
                name: "IX_WF_005",
                schema: "HLV_EMAIL_PRO",
                table: "WF_EXECUTIONPOINTER",
                column: "WORKFLOWID");

            migrationBuilder.CreateIndex(
                name: "IX_WF_006",
                schema: "HLV_EMAIL_PRO",
                table: "WF_EXTENSIONATTRIBUTE",
                column: "EXECUTIONPOINTERID");

            migrationBuilder.CreateIndex(
                name: "IX_WF_007",
                schema: "HLV_EMAIL_PRO",
                table: "WF_SCHEDULEDCOMMAND",
                columns: new[] { "COMMANDNAME", "DATAVALUE" },
                unique: true,
                filter: "\"COMMANDNAME\" IS NOT NULL AND \"DATAVALUE\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WF_008",
                schema: "HLV_EMAIL_PRO",
                table: "WF_SCHEDULEDCOMMAND",
                column: "EXECUTETIME");

            migrationBuilder.CreateIndex(
                name: "IX_WF_009",
                schema: "HLV_EMAIL_PRO",
                table: "WF_SUBSCRIPTION",
                column: "EVENTKEY");

            migrationBuilder.CreateIndex(
                name: "IX_WF_010",
                schema: "HLV_EMAIL_PRO",
                table: "WF_SUBSCRIPTION",
                column: "EVENTNAME");

            migrationBuilder.CreateIndex(
                name: "IX_WF_011",
                schema: "HLV_EMAIL_PRO",
                table: "WF_SUBSCRIPTION",
                column: "SUBSCRIPTIONID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WF_012",
                schema: "HLV_EMAIL_PRO",
                table: "WF_WORKFLOW",
                column: "INSTANCEID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WF_013",
                schema: "HLV_EMAIL_PRO",
                table: "WF_WORKFLOW",
                column: "NEXTEXECUTION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WF_EVENT",
                schema: "HLV_EMAIL_PRO");

            migrationBuilder.DropTable(
                name: "WF_EXECUTIONERROR",
                schema: "HLV_EMAIL_PRO");

            migrationBuilder.DropTable(
                name: "WF_EXTENSIONATTRIBUTE",
                schema: "HLV_EMAIL_PRO");

            migrationBuilder.DropTable(
                name: "WF_SCHEDULEDCOMMAND",
                schema: "HLV_EMAIL_PRO");

            migrationBuilder.DropTable(
                name: "WF_SUBSCRIPTION",
                schema: "HLV_EMAIL_PRO");

            migrationBuilder.DropTable(
                name: "WF_EXECUTIONPOINTER",
                schema: "HLV_EMAIL_PRO");

            migrationBuilder.DropTable(
                name: "WF_WORKFLOW",
                schema: "HLV_EMAIL_PRO");
        }
    }
}
