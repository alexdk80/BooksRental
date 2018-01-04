namespace BooksRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredToNameAndAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
        }
    }
}
