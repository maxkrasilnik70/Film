using Film.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.Context
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }

        public FilmContext()
        {
        }

        private bool disposed = false;

        public DbSet<Watchlist> Watchlist { get; set; }
        public DbSet<LastView> LastView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Watchlist>().HasKey(w => w.Id);
            modelBuilder.Entity<Watchlist>().HasIndex(w => new { w.UserId, w.FilmId }).IsUnique();

            modelBuilder.Entity<LastView>().HasKey(l => l.Id);

            modelBuilder.Entity<LastView>()
                .HasOne<Watchlist>(l => l.Watchlist)
                .WithMany(w => w.LastViews)
                .HasForeignKey(l => l.WatchlistId);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Dispose();
                }
            }
            this.disposed = true;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

