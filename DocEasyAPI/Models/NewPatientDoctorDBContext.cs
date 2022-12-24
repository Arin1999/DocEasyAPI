using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DocEasyAPI.Models
{
    public partial class NewPatientDoctorDBContext : DbContext
    {
        public NewPatientDoctorDBContext()
        {
        }

        public NewPatientDoctorDBContext(DbContextOptions<NewPatientDoctorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NewPatientDoctorDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasIndex(e => e.DoctorId, "IX_Appointments_DoctorId");

                entity.HasIndex(e => e.PatientId, "IX_Appointments_PatientId");

                entity.HasIndex(e => e.ShopId, "IX_Appointments_ShopId");

                entity.Property(e => e.AppointmentDateTime).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Degrees).IsRequired();

                entity.Property(e => e.EmploymentHistory).IsRequired();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SpecializesIn).IsRequired();
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasIndex(e => e.AppointmentId, "IX_Medicines_AppointmentId");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.MedicineName).IsRequired();

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.AppointmentId);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.OwnerName).IsRequired();

                entity.Property(e => e.OwnerPassword).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
