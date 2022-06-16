using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TargetWarmBuyerss",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    received_at_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    received_at_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeadSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentofInterest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepAssignedto_simplelendrep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastactivityat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Howsoonareyoulookingtopurchase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreyoulookingtoFinanceorPayCash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatisyourbudget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whereareyoulocated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationpurchaseavailability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestTimetoCall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Howsoonareyoulookingtosell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentLocated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anyaccidents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankruptcyoraconsumerproposalinthelast2years = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anyactivelawsuits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Howlonghaveyoubeeninbusiness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doyouownorrentwhereyoucurrentlylive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Howmanymilesorhours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredService = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetWarmBuyerss", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TargetWarmBuyerss");
        }
    }
}
