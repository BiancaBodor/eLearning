namespace eLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        Text = c.String(nullable: false),
                        PostatLa = c.DateTime(),
                        StudentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Replay",
                c => new
                    {
                        ReplayId = c.Guid(nullable: false),
                        Text = c.String(nullable: false),
                        PostatLa = c.DateTime(),
                        StudentId = c.Guid(nullable: false),
                        CommentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReplayId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Guid(nullable: false),
                        NumeStudent = c.String(nullable: false),
                        PrenumeStudent = c.String(nullable: false),
                        NivelStudii = c.Int(nullable: false),
                        Image = c.String(),
                        PostatLa = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Resurse",
                c => new
                    {
                        ResurseId = c.Guid(nullable: false),
                        Subiect = c.String(),
                        Continut = c.String(),
                        Comentarii = c.String(),
                        Mentors_MentorId = c.Guid(),
                        Students_StudentId = c.Guid(),
                    })
                .PrimaryKey(t => t.ResurseId)
                .ForeignKey("dbo.Mentor", t => t.Mentors_MentorId)
                .ForeignKey("dbo.Student", t => t.Students_StudentId)
                .Index(t => t.Mentors_MentorId)
                .Index(t => t.Students_StudentId);
            
            CreateTable(
                "dbo.Mentor",
                c => new
                    {
                        MentorId = c.Guid(nullable: false),
                        NumeMentor = c.String(),
                        PrenumeMentor = c.String(),
                        Nivel = c.Int(nullable: false),
                        Email = c.String(),
                        Telefon = c.String(),
                        Descriere = c.String(),
                    })
                .PrimaryKey(t => t.MentorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Replay", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Resurse", "Students_StudentId", "dbo.Student");
            DropForeignKey("dbo.Resurse", "Mentors_MentorId", "dbo.Mentor");
            DropForeignKey("dbo.Replay", "CommentId", "dbo.Comment");
            DropIndex("dbo.Resurse", new[] { "Students_StudentId" });
            DropIndex("dbo.Resurse", new[] { "Mentors_MentorId" });
            DropIndex("dbo.Replay", new[] { "CommentId" });
            DropIndex("dbo.Replay", new[] { "StudentId" });
            DropIndex("dbo.Comment", new[] { "StudentId" });
            DropTable("dbo.Mentor");
            DropTable("dbo.Resurse");
            DropTable("dbo.Student");
            DropTable("dbo.Replay");
            DropTable("dbo.Comment");
        }
    }
}
