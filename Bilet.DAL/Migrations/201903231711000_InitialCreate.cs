namespace Bilet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiletSatislar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IslemTarihi = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Koltuklar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KoltukNo = c.Int(nullable: false),
                        KoltukTürü = c.String(),
                        Cinsiyet = c.String(),
                        BiletSatisId = c.Int(),
                        OtobusId = c.Int(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiletSatislar", t => t.BiletSatisId)
                .ForeignKey("dbo.Otobusler", t => t.OtobusId)
                .Index(t => t.BiletSatisId)
                .Index(t => t.OtobusId);
            
            CreateTable(
                "dbo.Otobusler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plaka = c.String(maxLength: 7),
                        SeferSaatId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeferSaatler", t => t.SeferSaatId, cascadeDelete: true)
                .Index(t => t.SeferSaatId);
            
            CreateTable(
                "dbo.SeferSaatler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisSaati = c.String(nullable: false),
                        SeferId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seferler", t => t.SeferId, cascadeDelete: true)
                .Index(t => t.SeferId);
            
            CreateTable(
                "dbo.Seferler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisTarihi = c.String(nullable: false),
                        GuzergahId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guzergahlar", t => t.GuzergahId, cascadeDelete: true)
                .Index(t => t.GuzergahId);
            
            CreateTable(
                "dbo.Guzergahlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisYeriId = c.Int(nullable: false),
                        DestinasyonId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinasyonlar", t => t.DestinasyonId, cascadeDelete: true)
                .ForeignKey("dbo.KalkisYerleri", t => t.KalkisYeriId, cascadeDelete: true)
                .Index(t => t.KalkisYeriId)
                .Index(t => t.DestinasyonId);
            
            CreateTable(
                "dbo.Destinasyonlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DestinasyonYer = c.String(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KalkisYerleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisYer = c.String(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        TCKimlikNo = c.String(nullable: false, maxLength: 11),
                        DogumTarihi = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BiletSatislar", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SeferSaatler", "SeferId", "dbo.Seferler");
            DropForeignKey("dbo.Seferler", "GuzergahId", "dbo.Guzergahlar");
            DropForeignKey("dbo.Guzergahlar", "KalkisYeriId", "dbo.KalkisYerleri");
            DropForeignKey("dbo.Guzergahlar", "DestinasyonId", "dbo.Destinasyonlar");
            DropForeignKey("dbo.Otobusler", "SeferSaatId", "dbo.SeferSaatler");
            DropForeignKey("dbo.Koltuklar", "OtobusId", "dbo.Otobusler");
            DropForeignKey("dbo.Koltuklar", "BiletSatisId", "dbo.BiletSatislar");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Guzergahlar", new[] { "DestinasyonId" });
            DropIndex("dbo.Guzergahlar", new[] { "KalkisYeriId" });
            DropIndex("dbo.Seferler", new[] { "GuzergahId" });
            DropIndex("dbo.SeferSaatler", new[] { "SeferId" });
            DropIndex("dbo.Otobusler", new[] { "SeferSaatId" });
            DropIndex("dbo.Koltuklar", new[] { "OtobusId" });
            DropIndex("dbo.Koltuklar", new[] { "BiletSatisId" });
            DropIndex("dbo.BiletSatislar", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.KalkisYerleri");
            DropTable("dbo.Destinasyonlar");
            DropTable("dbo.Guzergahlar");
            DropTable("dbo.Seferler");
            DropTable("dbo.SeferSaatler");
            DropTable("dbo.Otobusler");
            DropTable("dbo.Koltuklar");
            DropTable("dbo.BiletSatislar");
        }
    }
}
