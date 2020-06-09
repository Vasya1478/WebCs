using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicalJournal2.Models
{
    public partial class stomatologyContext : DbContext
    {
        public stomatologyContext()
        {
        }

        public stomatologyContext(DbContextOptions<stomatologyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<NameOfPosition> NameOfPosition { get; set; }
        public virtual DbSet<NameOfService> NameOfService { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=stomatology;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.ToTable("doctors");

                entity.HasIndex(e => e.EmployeeCode)
                    .HasName("UQ__doctors__B0AA734596F907B3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CabinetNumber).HasColumnName("cabinet_number");

                entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.TimeOfReceiptId).HasColumnName("time_of_receipt_id");

                entity.Property(e => e.TypeOfServiceId).HasColumnName("type_of_service_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_doctors_name_of_position");

                entity.HasOne(d => d.TimeOfReceipt)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.TimeOfReceiptId)
                    .HasConstraintName("FK_doctors_schedule");

                entity.HasOne(d => d.TypeOfService)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.TypeOfServiceId)
                    .HasConstraintName("FK_doctors_name_of_service");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("journal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardNumberId).HasColumnName("card_number_id");

                entity.Property(e => e.DateOfReceipt)
                    .HasColumnName("date_of_receipt")
                    .HasColumnType("datetime");

                entity.Property(e => e.DoctorNameId).HasColumnName("doctor_name_id");

                entity.Property(e => e.DoctorPost).HasColumnName("doctor_post");

                entity.Property(e => e.PatientName)
                    .HasColumnName("patient_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.CardNumber)
                    .WithMany(p => p.Journal)
                    .HasForeignKey(d => d.CardNumberId)
                    .HasConstraintName("FK_journal_patient");

                entity.HasOne(d => d.DoctorName)
                    .WithMany(p => p.Journal)
                    .HasForeignKey(d => d.DoctorNameId)
                    .HasConstraintName("FK_journal_doctors_name");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Journal)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_journal_services");
            });

            modelBuilder.Entity<NameOfPosition>(entity =>
            {
                entity.ToTable("name_of_position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Premium)
                    .HasColumnName("premium")
                    .HasColumnType("money");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<NameOfService>(entity =>
            {
                entity.ToTable("name_of_service");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeOfService)
                    .HasColumnName("type_of_service")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.ToTable("patients");

                entity.HasIndex(e => e.CardNumber)
                    .HasName("UQ__patients__1E6E0AF4DDF3C2E2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CardNumber).HasColumnName("card_number");

                entity.Property(e => e.InsuranceNumber)
                    .HasColumnName("insurance_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.TimeOfReceipt)
                    .HasColumnName("time_of_receipt")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.ToTable("services");

                entity.HasIndex(e => e.Number)
                    .HasName("UQ__services__FD291E411E6D5759")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.ServiceName)
                    .HasColumnName("service_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfServiceId).HasColumnName("type_of_service_id");

                entity.HasOne(d => d.TypeOfService)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TypeOfServiceId)
                    .HasConstraintName("FK_services_name_of_service");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
