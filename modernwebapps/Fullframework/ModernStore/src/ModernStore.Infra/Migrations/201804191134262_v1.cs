namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        //Name_Field = c.String(),
                        //Name_Message = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Email = c.String(nullable: false, maxLength: 160),
                        //Email_Field = c.String(),
                        //Email_Message = c.String(),
                        Cpf = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        //Document_Field = c.String(),
                        //Document_Message = c.String(),
                        //Field = c.String(),
                        //Message = c.String(),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        //Password_Field = c.String(),
                        //Password_Message = c.String(),
                        Active = c.Boolean(nullable: false),
                        //Field = c.String(),
                        //Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Number = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        Status = c.Int(nullable: false),
                        DeliverFee = c.Decimal(nullable: false, storeType: "money"),
                        Discount = c.Decimal(nullable: false, storeType: "money"),
                        //Field = c.String(),
                        //Message = c.String(),
                        Customer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        //Field = c.String(),
                        Message = c.String(),
                        Product_Id = c.Guid(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 80),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Image = c.String(nullable: false, maxLength: 1021),
                        QuantityOnHand = c.Int(nullable: false),
                        //Field = c.String(),
                        //Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.Customer", "User_Id", "dbo.User");
            DropIndex("dbo.OrderItem", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "Product_Id" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropIndex("dbo.Customer", new[] { "User_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.User");
            DropTable("dbo.Customer");
        }
    }
}
