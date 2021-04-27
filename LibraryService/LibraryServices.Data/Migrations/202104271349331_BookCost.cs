namespace LibraryServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookCost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        PublicationYear = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CallNumber = c.String(),
                        CostId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Costs", t => t.CostId)
                .Index(t => t.CostId);
            
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        CostId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        DiscountCode = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CostId", "dbo.Costs");
            DropIndex("dbo.Books", new[] { "CostId" });
            DropTable("dbo.Costs");
            DropTable("dbo.Books");
        }
    }
}
