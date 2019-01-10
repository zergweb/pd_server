using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdApi.Model;

namespace PdApi.Model
{
    public class PdDbContext : DbContext
    {
       // public DbSet<LkProfile> Profiles { get; set; }
        public DbSet<LkStudent> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<LkTeacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FacultySection> FacultySections { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SemesterArchiveItem> SemesterArchive { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectGallery> ProjectGalleries { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ProjectDoc> ProjectDocs { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PublicProfileConfig> PublicProfileConfigs { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SubjectTeacher>()
            //    .HasKey(t => new { t.SubjectId, t.LkTeacherId });
            //modelBuilder.Entity<SubjectTeacher>()
            //    .HasOne(sc => sc.Subject)
            //    .WithMany(s => s.SubjectTeachers)
            //    .HasForeignKey(sc => sc.SubjectId);
            //modelBuilder.Entity<SubjectTeacher>()
            //    .HasOne(sc => sc.LkTeacher)
            //    .WithMany(c => c.SubjectTeachers)
            //    .HasForeignKey(sc => sc.LkTeacherId);
            //modelBuilder.Entity<SubjectTeacher>()
            //    .HasOne(sc => sc.Group)
            //    .WithMany(c => c.Subjects)
            //    .HasForeignKey(sc => sc.GroupId);


            //modelBuilder.Entity<StudentSkill>()
            //    .HasKey(t => new { t.LkStudentId, t.SkillId });
            //modelBuilder.Entity<StudentSkill>()
            //    .HasOne(sc => sc.LkStudent)
            //    .WithMany(s => s.StudentSkills)
            //    .HasForeignKey(sc => sc.LkStudentId);
            //modelBuilder.Entity<StudentSkill>()
            //    .HasOne(sc => sc.Skill)
            //    .WithMany(c => c.StudentSkills)
            //    .HasForeignKey(sc => sc.SkillId);

            //modelBuilder.Entity<GalleryImage>()
            //    .HasKey(t => new { t.LkImageId, t.ProjectGalleryId });
            //modelBuilder.Entity<GalleryImage>()
            //    .HasOne(sc => sc.ProjectGallery)
            //    .WithMany(c => c.GalleryImages)
            //    .HasForeignKey(sc => sc.ProjectGalleryId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var polytech = "server=std-mysql.ist.mospolytech.ru;port=3306;database=std_267;uid=std_267;password=893z106d5732;SSL Mode=None;";
            var local = "server=localhost;port=3306;database=pd;uid=root;password=1234;";
            optionsBuilder
            .UseMySql(polytech,
            b => b.MigrationsAssembly("PdApi")
            );
        }
       
    }
}
