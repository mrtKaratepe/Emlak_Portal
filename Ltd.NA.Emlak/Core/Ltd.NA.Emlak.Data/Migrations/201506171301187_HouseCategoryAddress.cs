namespace Ltd.NA.Emlak.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HouseCategoryAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Houses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        FK_CategoryId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Categories", t => t.FK_CategoryId)
                .Index(t => t.FK_CategoryId);
            
            CreateTable(
                "dbo.tbl_Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Entry = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Houses", "FK_CategoryId", "dbo.tbl_Categories");
            DropIndex("dbo.tbl_Houses", new[] { "FK_CategoryId" });
            DropTable("dbo.tbl_Categories");
            DropTable("dbo.tbl_Houses");
        }
    }
}
