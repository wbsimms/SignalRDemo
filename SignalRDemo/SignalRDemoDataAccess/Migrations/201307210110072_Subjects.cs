namespace SignalRDemoDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subjects : DbMigration
    {
        public override void Up()
        {
            this.Sql("alter table Subjects add constraint UC_Subjects_Name unique (Name)");
        }

        public override void Down()
        {
            this.Sql("alter table Subjects drop constraint IX_Subjects_Name");
        }
    }
}
