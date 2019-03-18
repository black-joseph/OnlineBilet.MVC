namespace Bilet.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiletSatisDetaylar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KoltukNo = c.Int(nullable: false),
                        KoltukTürü = c.String(),
                        Cinsiyet = c.String(),
                        BiletSatisId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiletSatislar", t => t.BiletSatisId, cascadeDelete: true)
                .Index(t => t.BiletSatisId);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        TCKimlikNo = c.String(nullable: false, maxLength: 11),
                        DogumTarihi = c.DateTime(nullable: false),
                        KrediKartNo = c.String(maxLength: 16),
                        KrediKartAdSoyad = c.String(),
                        SonKullanmaTarihi = c.DateTime(nullable: false),
                        CVC2 = c.String(maxLength: 3),
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
                "dbo.Otobusler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plaka = c.String(maxLength: 7),
                        SeferProgramId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeferProgramlar", t => t.SeferProgramId, cascadeDelete: true)
                .Index(t => t.SeferProgramId);
            
            CreateTable(
                "dbo.SeferProgramlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisTarihVeSaat = c.DateTime(nullable: false),
                        VarisTarihVeSaat = c.DateTime(nullable: false),
                        SeferId = c.Int(nullable: false),
                        BiletSatisId = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiletSatislar", t => t.BiletSatisId, cascadeDelete: true)
                .ForeignKey("dbo.Seferler", t => t.SeferId, cascadeDelete: true)
                .Index(t => t.SeferId)
                .Index(t => t.BiletSatisId);
            
            CreateTable(
                "dbo.Seferler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KalkisYeri = c.String(nullable: false),
                        Destinasyon = c.String(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Otobusler", "SeferProgramId", "dbo.SeferProgramlar");
            DropForeignKey("dbo.SeferProgramlar", "SeferId", "dbo.Seferler");
            DropForeignKey("dbo.SeferProgramlar", "BiletSatisId", "dbo.BiletSatislar");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BiletSatislar", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BiletSatisDetaylar", "BiletSatisId", "dbo.BiletSatislar");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SeferProgramlar", new[] { "BiletSatisId" });
            DropIndex("dbo.SeferProgramlar", new[] { "SeferId" });
            DropIndex("dbo.Otobusler", new[] { "SeferProgramId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BiletSatislar", new[] { "UserId" });
            DropIndex("dbo.BiletSatisDetaylar", new[] { "BiletSatisId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Seferler");
            DropTable("dbo.SeferProgramlar");
            DropTable("dbo.Otobusler");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BiletSatislar");
            DropTable("dbo.BiletSatisDetaylar");
        }
    }
}
