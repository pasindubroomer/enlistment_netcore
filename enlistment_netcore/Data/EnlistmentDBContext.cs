using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using enlistment_netcore.Models;

#nullable disable

namespace enlistment_netcore.Data
{
    public partial class EnlistmentDBContext : DbContext
    {
        public EnlistmentDBContext(DbContextOptions<EnlistmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eligibilty> Eligibilties { get; set; }
        public virtual DbSet<MstAgeCalculateDate> MstAgeCalculateDates { get; set; }
        public virtual DbSet<MstAlsubject> MstAlsubjects { get; set; }
        public virtual DbSet<MstSport> MstSports { get; set; }
        public virtual DbSet<MstStudentAldetail> MstStudentAldetails { get; set; }
        public virtual DbSet<MstStudentCadetScoutingDetail> MstStudentCadetScoutingDetails { get; set; }
        public virtual DbSet<MstStudentOldetail> MstStudentOldetails { get; set; }
        public virtual DbSet<MstStudentParentGuardianDetail> MstStudentParentGuardianDetails { get; set; }
        public virtual DbSet<MstStudentPersonalDetail> MstStudentPersonalDetails { get; set; }
        public virtual DbSet<MstStudentSportsDetail> MstStudentSportsDetails { get; set; }
        public virtual DbSet<SpecialRequirement> SpecialRequirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=enlistment;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Eligibilty>(entity =>
            {
                entity.HasKey(e => e.DegreeCode)
                    .HasName("PK_eligibilty");

                entity.ToTable("Eligibilty");

                entity.Property(e => e.DegreeCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AlminimumSpasses).HasColumnName("ALMinimumSPasses");

                entity.Property(e => e.Alyear)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALYear");

                entity.Property(e => e.DegreeName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.OlmathsMinPass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OLMathsMinPass")
                    .IsFixedLength(true);

                entity.Property(e => e.OlscienceMinPass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OLScienceMinPass")
                    .IsFixedLength(true);

                entity.Property(e => e.OlsinhalaMinPass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OLSinhalaMinPass")
                    .IsFixedLength(true);

                entity.Property(e => e.Stream).IsUnicode(false);

                entity.Property(e => e.StudentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstAgeCalculateDate>(entity =>
            {
                entity.ToTable("MstAgeCalculateDate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<MstAlsubject>(entity =>
            {
                entity.ToTable("MstALSubject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alstream)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALStream");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstSport>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.Property(e => e.SportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStudentAldetail>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("MstStudentALDetail");

                entity.Property(e => e.Attemp1IndexNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attemp1Year)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attemp2IndexNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attemp2Year)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attemp3IndexNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Attemp3Year)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EnglishGrade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralTest)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassedAttempt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassedIndexNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassedYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QualifiedForUniversity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Subject1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject1Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject2Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject3Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zscore)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZScore");
            });

            modelBuilder.Entity<MstStudentCadetScoutingDetail>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("MstStudentCadetScoutingDetail");

                entity.Property(e => e.Band)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cadeting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CcCcAwards)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CubScoutWithStar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstAid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_aid");

                entity.Property(e => e.HouseCaptain)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("House_captain");

                entity.Property(e => e.Juo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lcpl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prefect)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PresScouts)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pte)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pte");

                entity.Property(e => e.SchoolCaptain)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("School_captain");

                entity.Property(e => e.Scouting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Scouts)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScoutsAward)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sgt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Societies)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStudentOldetail>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("MstStudentOLDetail");

                entity.Property(e => e.IndexNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Subject1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject1Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject2Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject3Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject4Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject5Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject6Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject7Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject8Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject9Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStudentParentGuardianDetail>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("MstStudentParentGuardianDetail");

                entity.Property(e => e.FatherAddress).IsUnicode(false);

                entity.Property(e => e.FatherFullName).IsUnicode(false);

                entity.Property(e => e.FatherMobileNo).IsUnicode(false);

                entity.Property(e => e.FatherPresentEmployment).IsUnicode(false);

                entity.Property(e => e.FatherPreviousEmployment).IsUnicode(false);

                entity.Property(e => e.FatherResidenceTel).IsUnicode(false);

                entity.Property(e => e.ForceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuardianAddress).IsUnicode(false);

                entity.Property(e => e.GuardianFullName).IsUnicode(false);

                entity.Property(e => e.GuardianMobileNo).IsUnicode(false);

                entity.Property(e => e.GuardianRelationship).IsUnicode(false);

                entity.Property(e => e.GuardianResidenceTel).IsUnicode(false);

                entity.Property(e => e.MotherAddress).IsUnicode(false);

                entity.Property(e => e.MotherFullName).IsUnicode(false);

                entity.Property(e => e.MotherMobileNo).IsUnicode(false);

                entity.Property(e => e.MotherPresentEmployment).IsUnicode(false);

                entity.Property(e => e.MotherPreviousEmployment).IsUnicode(false);

                entity.Property(e => e.MotherResidenceTel).IsUnicode(false);

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStudentPersonalDetail>(entity =>
            {
                entity.HasKey(e => e.NicNo)
                    .HasName("PK_MstStudentPersonalDetails");

                entity.ToTable("MstStudentPersonalDetail");

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Citizenship)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CivilStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameWithInitial).IsUnicode(false);

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermanentAddress).IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelResidence)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStudentSportsDetail>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("MstStudentSportsDetail");

                entity.Property(e => e.Dl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DL");

                entity.Property(e => e.Nc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NC");

                entity.Property(e => e.NicNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PL");

                entity.Property(e => e.PlinNl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLInNL");

                entity.Property(e => e.Pnl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PNL");

                entity.Property(e => e.RslofO)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RSLOfO");

                entity.Property(e => e.Sc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SC");

                entity.Property(e => e.Sl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SL");

                entity.Property(e => e.SportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZL");
            });

            modelBuilder.Entity<SpecialRequirement>(entity =>
            {
                entity.ToTable("SpecialRequirement");

                entity.Property(e => e.AlcompulsarySubjects)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ALCompulsarySubjects");

                entity.Property(e => e.AlminimumCreditPassesCount)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ALMinimumCreditPassesCount");

                entity.Property(e => e.AlminimumCreditPassesSubjects)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ALMinimumCreditPassesSubjects");

                entity.Property(e => e.AlminimumSimplePassesCount)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ALMinimumSimplePassesCount");

                entity.Property(e => e.AlminimumSimplePassesSubjects)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ALMinimumSimplePassesSubjects");

                entity.Property(e => e.DegreeCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.OlminimumCreditPassesCount)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("OLMinimumCreditPassesCount");

                entity.Property(e => e.OlminimumCreditPassesSubjects)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("OLMinimumCreditPassesSubjects");

                entity.Property(e => e.OlminimumSimplePassesCount)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("OLMinimumSimplePassesCount");

                entity.Property(e => e.OlminimumSimplePassesSubjects)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("OLMinimumSimplePassesSubjects");

                entity.HasOne(d => d.DegreeCodeNavigation)
                    .WithMany(p => p.SpecialRequirements)
                    .HasForeignKey(d => d.DegreeCode)
                    .HasConstraintName("FK_SpecialRequirements_eligibilty");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
