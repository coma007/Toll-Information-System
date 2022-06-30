using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TollSystem.Infrastructure.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Damage> Damage { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Policereport> Policereport { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Pricelist> Pricelist { get; set; }
        public virtual DbSet<Salesplace> Salesplace { get; set; }
        public virtual DbSet<Scanner> Scanner { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Tollbooth> Tollbooth { get; set; }
        public virtual DbSet<Tollstation> Tollstation { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Transit> Transit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User ID=TollSystem;Password=ftn;Persist Security Info=True",
                    options => options.UseOracleSQLCompatibility("11"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "TOLLSYSTEM");

            modelBuilder.Entity<Damage>(entity =>
            {
                entity.HasKey(e => e.Deviceid)
                    .HasName("DAMAGE_DEVICEID_PK");

                entity.ToTable("DAMAGE");

                entity.Property(e => e.Deviceid)
                    .HasColumnName("DEVICEID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.HasOne(d => d.Device)
                    .WithOne(p => p.Damage)
                    .HasForeignKey<Damage>(d => d.Deviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DAMAGE_DEVICEID_FK");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("DEVICE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Devicetype)
                    .IsRequired()
                    .HasColumnName("DEVICETYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdamaged)
                    .HasColumnName("ISDAMAGED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Stationid)
                    .HasColumnName("STATIONID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Tollboothnumber)
                    .HasColumnName("TOLLBOOTHNUMBER")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Tollbooth)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => new { d.Stationid, d.Tollboothnumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DEVICE_FK");
            });

            modelBuilder.Entity<Policereport>(entity =>
            {
                entity.ToTable("POLICEREPORT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Licenseplate)
                    .IsRequired()
                    .HasColumnName("LICENSEPLATE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Reportdate)
                    .HasColumnName("REPORTDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Speed)
                    .HasColumnName("SPEED")
                    .HasColumnType("NUMBER(4,1)");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.Pricelistid, e.Ordinalnumber })
                    .HasName("PRICE_PK");

                entity.ToTable("PRICE");

                entity.Property(e => e.Pricelistid)
                    .HasColumnName("PRICELISTID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Ordinalnumber)
                    .HasColumnName("ORDINALNUMBER")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Priceeur)
                    .HasColumnName("PRICEEUR")
                    .HasColumnType("NUMBER(5,2)");

                entity.Property(e => e.Pricersd)
                    .HasColumnName("PRICERSD")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Sectionid)
                    .HasColumnName("SECTIONID")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Pricelist)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.Pricelistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PRICE_PRICELIST_FK");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.Sectionid)
                    .HasConstraintName("PRICE_SECTION_FK");
            });

            modelBuilder.Entity<Pricelist>(entity =>
            {
                entity.ToTable("PRICELIST");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Isactive)
                    .HasColumnName("ISACTIVE")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Validfrom)
                    .HasColumnName("VALIDFROM")
                    .HasColumnType("DATE");

                entity.Property(e => e.Validto)
                    .HasColumnName("VALIDTO")
                    .HasColumnType("DATE");
            });

            modelBuilder.Entity<Salesplace>(entity =>
            {
                entity.ToTable("SALESPLACE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Availabletags)
                    .HasColumnName("AVAILABLETAGS")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Scanner>(entity =>
            {
                entity.ToTable("SCANNER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Scannertype)
                    .IsRequired()
                    .HasColumnName("SCANNERTYPE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Scanner)
                    .HasForeignKey<Scanner>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SCANNER_FK");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("SECTION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Length)
                    .HasColumnName("LENGTH")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Tollstation1id)
                    .HasColumnName("TOLLSTATION1ID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Tollstation2id)
                    .HasColumnName("TOLLSTATION2ID")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Tollstation1)
                    .WithMany(p => p.SectionTollstation1)
                    .HasForeignKey(d => d.Tollstation1id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SECTION_FK1");

                entity.HasOne(d => d.Tollstation2)
                    .WithMany(p => p.SectionTollstation2)
                    .HasForeignKey(d => d.Tollstation2id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SECTION_FK2");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("STAFF_PK");

                entity.ToTable("STAFF");

                entity.Property(e => e.Userid)
                    .HasColumnName("USERID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("ROLE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Stationid)
                    .HasColumnName("STATIONID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Validfrom)
                    .HasColumnName("VALIDFROM")
                    .HasColumnType("DATE");

                entity.Property(e => e.Validto)
                    .HasColumnName("VALIDTO")
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.Stationid)
                    .HasConstraintName("STAFF_FK");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("TAG");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Currentbalance)
                    .HasColumnName("CURRENTBALANCE")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Expirationdate)
                    .HasColumnName("EXPIRATIONDATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Licenseplate)
                    .IsRequired()
                    .HasColumnName("LICENSEPLATE")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("TICKET");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Licenseplate)
                    .IsRequired()
                    .HasColumnName("LICENSEPLATE")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tollbooth>(entity =>
            {
                entity.HasKey(e => new { e.Stationid, e.Ordinalnumber })
                    .HasName("TOLLBOOTH_PK");

                entity.ToTable("TOLLBOOTH");

                entity.Property(e => e.Stationid)
                    .HasColumnName("STATIONID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Ordinalnumber)
                    .HasColumnName("ORDINALNUMBER")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Tollbooth)
                    .HasForeignKey(d => d.Stationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TOLLBOOTH_FK");
            });

            modelBuilder.Entity<Tollstation>(entity =>
            {
                entity.ToTable("TOLLSTATION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("TRANSACTION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("CURRENCY")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(10,2)");

                entity.Property(e => e.Transitid)
                    .HasColumnName("TRANSITID")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Transit)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Transitid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSACTIONTRANSIT_FK");
            });

            modelBuilder.Entity<Transit>(entity =>
            {
                entity.ToTable("TRANSIT");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Entrancestationboothid)
                    .HasColumnName("ENTRANCESTATIONBOOTHID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Entrancestationid)
                    .HasColumnName("ENTRANCESTATIONID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Entrancetime)
                    .HasColumnName("ENTRANCETIME")
                    .HasColumnType("DATE");

                entity.Property(e => e.Exitstationboothid)
                    .HasColumnName("EXITSTATIONBOOTHID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Exitstationid)
                    .HasColumnName("EXITSTATIONID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Exittime)
                    .HasColumnName("EXITTIME")
                    .HasColumnType("DATE");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("ISDELETED")
                    .HasColumnType("NUMBER(38)")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Tagid)
                    .HasColumnName("TAGID")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Ticketid)
                    .HasColumnName("TICKETID")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Transit)
                    .HasForeignKey(d => d.Tagid)
                    .HasConstraintName("TRANSITTAG_FK");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Transit)
                    .HasForeignKey(d => d.Ticketid)
                    .HasConstraintName("TRANSITTICKET_FK");

                entity.HasOne(d => d.Entrancestation)
                    .WithMany(p => p.TransitEntrancestation)
                    .HasForeignKey(d => new { d.Entrancestationid, d.Entrancestationboothid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TRANSITENTRANCE_FK");

                entity.HasOne(d => d.Exitstation)
                    .WithMany(p => p.TransitExitstation)
                    .HasForeignKey(d => new { d.Exitstationid, d.Exitstationboothid })
                    .HasConstraintName("TRANSITEXIT_FK");
            });

            modelBuilder.HasSequence("ID_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
