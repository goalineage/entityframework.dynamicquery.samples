namespace EntityFrameworkDynamicQuerySamples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        City = c.String(maxLength: 20),
                        District = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.City)
                .Index(t => t.District);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "District" });
            DropIndex("dbo.Customers", new[] { "City" });
            DropTable("dbo.Customers");
        }
    }
}
