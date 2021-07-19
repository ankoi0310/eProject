using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.Models
{
    public class DBContext: DbContext
    {
        private string connectionString;

        public DBContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("MyConnection").ToString();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AuctionRecord>().HasKey(a => new { a.AuctionId, a.CustomerId });
            modelBuilder.Entity<ExArtwork>().HasKey(e => new { e.ArtworkId, e.ExhibitionId });
            modelBuilder.Entity<TransactionDetail>().HasKey(t => new { t.TransactionId, t.ArtworkId });
            modelBuilder.Entity<MyGallery>().HasKey(t => new { t.CustomerId, t.ArtworkId });
        }
        public DbSet<ArtCategory> ArtCategories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionRecord> AuctionRecords { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ExArtwork> ExArtworks { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<MyGallery> MyGalleries { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
