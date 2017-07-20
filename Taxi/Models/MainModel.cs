namespace Taxi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MainModel : DbContext
    {
        public MainModel()
            : base("name=MainModel")
        {
        }

        public virtual DbSet<tblCar> tblCars { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblMessage> tblMessages { get; set; }
        public virtual DbSet<tblRoute> tblRoutes { get; set; }
        public virtual DbSet<tblServiceCar> tblServiceCars { get; set; }
        public virtual DbSet<tblService> tblServices { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCar>()
                .HasMany(e => e.tblServiceCars)
                .WithRequired(e => e.tblCar)
                .HasForeignKey(e => e.CarID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblServices)
                .WithOptional(e => e.tblCustomer)
                .HasForeignKey(e => e.CustomerID);

            modelBuilder.Entity<tblRoute>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblRoute>()
                .HasMany(e => e.tblServiceCars)
                .WithRequired(e => e.tblRoute)
                .HasForeignKey(e => e.RouteID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblService>()
                .HasMany(e => e.tblMessages)
                .WithOptional(e => e.tblService)
                .HasForeignKey(e => e.ServiceID);

            modelBuilder.Entity<tblService>()
                .HasMany(e => e.tblServiceCars)
                .WithRequired(e => e.tblService)
                .HasForeignKey(e => e.ServiceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblCars)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.DriverID);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblServices)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.OperatorID);
        }
    }
}
