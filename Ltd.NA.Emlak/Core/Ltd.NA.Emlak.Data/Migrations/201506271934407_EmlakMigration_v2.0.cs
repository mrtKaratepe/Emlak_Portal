namespace Ltd.NA.Emlak.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmlakMigration_v20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Age = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Houses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Price = c.Double(nullable: false),
                        Rent = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        FK_AddressId = c.Guid(),
                        FK_AgentId = c.Guid(),
                        FK_CategoryId = c.Guid(),
                        FK_OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Address", t => t.FK_AddressId)
                .ForeignKey("dbo.tbl_Agent", t => t.FK_AgentId)
                .ForeignKey("dbo.tbl_Categories", t => t.FK_CategoryId)
                .ForeignKey("dbo.tbl_Customer", t => t.FK_OwnerId)
                .Index(t => t.FK_AddressId)
                .Index(t => t.FK_AgentId)
                .Index(t => t.FK_CategoryId)
                .Index(t => t.FK_OwnerId);
            
            CreateTable(
                "dbo.tbl_Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Number = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Entry = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Agent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AgentCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaxNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Person", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Customer", "Id", "dbo.tbl_Person");
            DropForeignKey("dbo.tbl_Agent", "Id", "dbo.tbl_Person");
            DropForeignKey("dbo.tbl_Houses", "FK_OwnerId", "dbo.tbl_Customer");
            DropForeignKey("dbo.tbl_Houses", "FK_CategoryId", "dbo.tbl_Categories");
            DropForeignKey("dbo.tbl_Houses", "FK_AgentId", "dbo.tbl_Agent");
            DropForeignKey("dbo.tbl_Houses", "FK_AddressId", "dbo.tbl_Address");
            DropIndex("dbo.tbl_Customer", new[] { "Id" });
            DropIndex("dbo.tbl_Agent", new[] { "Id" });
            DropIndex("dbo.tbl_Houses", new[] { "FK_OwnerId" });
            DropIndex("dbo.tbl_Houses", new[] { "FK_CategoryId" });
            DropIndex("dbo.tbl_Houses", new[] { "FK_AgentId" });
            DropIndex("dbo.tbl_Houses", new[] { "FK_AddressId" });
            DropTable("dbo.tbl_Customer");
            DropTable("dbo.tbl_Agent");
            DropTable("dbo.tbl_Categories");
            DropTable("dbo.tbl_Address");
            DropTable("dbo.tbl_Houses");
            DropTable("dbo.tbl_Person");
        }
    }
}
