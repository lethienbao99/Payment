using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MerchantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MerchantWebLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MerchantIpnUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MerchantReturnUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SerectKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Merchant__3214EC07E6617C1B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDestination",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DesLogo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DesShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DesName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DesSortIndex = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentD__3214EC071CEF14AC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDestination_ParentID",
                        column: x => x.ParentId,
                        principalTable: "PaymentDestination",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentContent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PaymentContent2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCurrency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentRefId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequiredAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentLanguage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentDestinationId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PaymentLastMessage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__3214EC071C987700", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Payment__Merchan__33D4B598",
                        column: x => x.MerchantId,
                        principalTable: "Merchant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Payment__Payment__32E0915F",
                        column: x => x.PaymentDestinationId,
                        principalTable: "PaymentDestination",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentNotification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentRefId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiContent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiMessage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiSignature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MerchantId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NotiResDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentN__3214EC078A1D9815", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PaymentNo__Merch__44FF419A",
                        column: x => x.MerchantId,
                        principalTable: "Merchant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PaymentNo__Payme__440B1D61",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentSignature",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SignValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SignAlgo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SignOwn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentS__3214EC07758AD836", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PaymentSi__Payme__412EB0B6",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TranMessage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TranPayload = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TranStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TranAmount = table.Column<decimal>(type: "decimal(19,2)", nullable: true),
                    TranDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentT__3214EC07B6A13815", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PaymentTr__Payme__300424B4",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_MerchantId",
                table: "Payment",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentDestinationId",
                table: "Payment",
                column: "PaymentDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDestination_ParentId",
                table: "PaymentDestination",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentNotification_MerchantId",
                table: "PaymentNotification",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentNotification_PaymentId",
                table: "PaymentNotification",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSignature_PaymentId",
                table: "PaymentSignature",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentId",
                table: "PaymentTransaction",
                column: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentNotification");

            migrationBuilder.DropTable(
                name: "PaymentSignature");

            migrationBuilder.DropTable(
                name: "PaymentTransaction");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Merchant");

            migrationBuilder.DropTable(
                name: "PaymentDestination");
        }
    }
}
