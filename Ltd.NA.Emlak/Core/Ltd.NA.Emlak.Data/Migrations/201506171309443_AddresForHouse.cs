namespace Ltd.NA.Emlak.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddresForHouse : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.tbl_Houses", "FK_AddressId", c => c.Guid());
            CreateIndex("dbo.tbl_Houses", "FK_AddressId");
            AddForeignKey("dbo.tbl_Houses", "FK_AddressId", "dbo.tbl_Address", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Houses", "FK_AddressId", "dbo.tbl_Address");
            DropIndex("dbo.tbl_Houses", new[] { "FK_AddressId" });
            DropColumn("dbo.tbl_Houses", "FK_AddressId");
            DropTable("dbo.tbl_Address");
        }
    }
}
