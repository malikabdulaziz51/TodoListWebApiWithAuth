namespace TodoListApiWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserResponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        PasswordHash = c.Binary(),
                        PasswrodSalt = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserResponses");
        }
    }
}
