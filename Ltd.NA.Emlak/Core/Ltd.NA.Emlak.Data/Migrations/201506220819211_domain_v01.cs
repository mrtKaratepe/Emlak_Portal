namespace Ltd.NA.Emlak.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class domain_v01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_Agent", "HouseInCharge_Id", "dbo.tbl_Houses");
            DropForeignKey("dbo.tbl_Customer", "House_Id", "dbo.tbl_Houses");
            DropIndex("dbo.tbl_Agent", new[] { "HouseInCharge_Id" });
            DropIndex("dbo.tbl_Customer", new[] { "House_Id" });
            AddColumn("dbo.tbl_Agent", "AgentCode", c => c.String());
            AddColumn("dbo.tbl_Customer", "TaxNumber", c => c.String());
            AddColumn("dbo.tbl_Person", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Houses", "FK_AgentId", c => c.Guid());
            AddColumn("dbo.tbl_Houses", "FK_OwnerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.tbl_Houses", "FK_AgentId");
            CreateIndex("dbo.tbl_Houses", "FK_OwnerId");
            AddForeignKey("dbo.tbl_Houses", "FK_AgentId", "dbo.tbl_Agent", "Id");
            AddForeignKey("dbo.tbl_Houses", "FK_OwnerId", "dbo.tbl_Customer", "Id");
            DropColumn("dbo.tbl_Agent", "HouseInCharge_Id");
            DropColumn("dbo.tbl_Agent", "agentName");
            DropColumn("dbo.tbl_Customer", "House_Id");
            DropColumn("dbo.tbl_Customer", "TcNo");
            DropColumn("dbo.tbl_Customer", "active");
            DropColumn("dbo.tbl_Customer", "Rent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Customer", "Rent", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Customer", "active", c => c.Boolean(nullable: false));
            AddColumn("dbo.tbl_Customer", "TcNo", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_Customer", "House_Id", c => c.Guid());
            AddColumn("dbo.tbl_Agent", "agentName", c => c.String());
            AddColumn("dbo.tbl_Agent", "HouseInCharge_Id", c => c.Guid());
            DropForeignKey("dbo.tbl_Houses", "FK_OwnerId", "dbo.tbl_Customer");
            DropForeignKey("dbo.tbl_Houses", "FK_AgentId", "dbo.tbl_Agent");
            DropIndex("dbo.tbl_Houses", new[] { "FK_OwnerId" });
            DropIndex("dbo.tbl_Houses", new[] { "FK_AgentId" });
            DropColumn("dbo.tbl_Houses", "FK_OwnerId");
            DropColumn("dbo.tbl_Houses", "FK_AgentId");
            DropColumn("dbo.tbl_Person", "Active");
            DropColumn("dbo.tbl_Customer", "TaxNumber");
            DropColumn("dbo.tbl_Agent", "AgentCode");
            CreateIndex("dbo.tbl_Customer", "House_Id");
            CreateIndex("dbo.tbl_Agent", "HouseInCharge_Id");
            AddForeignKey("dbo.tbl_Customer", "House_Id", "dbo.tbl_Houses", "Id");
            AddForeignKey("dbo.tbl_Agent", "HouseInCharge_Id", "dbo.tbl_Houses", "Id");
        }
    }
}
