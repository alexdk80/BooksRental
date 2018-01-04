namespace BooksRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInBook : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
        }
    }
}
