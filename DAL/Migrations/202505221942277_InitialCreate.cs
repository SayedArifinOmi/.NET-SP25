namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Qty = c.Int(),
                        Price = c.Double(nullable: false),
                        CatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CatId, cascadeDelete: true)
                .Index(t => t.CatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CatId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
