using CRUDWithCache.Entities;
using CRUDWithCache.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace CRUDWithCache
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AuthorEntity> Authors { get; set; }

        public DbSet<BookEntity> Books { get; set; }

        public DbSet<AuthorOfBookEntity> AuthorsOfBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AuthorOfBookEntity>().HasOne<AuthorEntity>(p => p.RelatedAuthor).WithMany(b => b.RelatedAauthorOfBookEntities)
            //                                                                    .HasForeignKey(p => p.RelatedAuthorId)
            //                                                                        ;


            //modelBuilder.Entity<AuthorOfBookEntity>().HasOne<BookEntity>(p => p.RelatedBook).WithMany(b => b.RelatedAauthorOfBookEntities)
            //                                                                    .HasForeignKey(p => p.RelatedBookId)
            //                                                                        .OnDelete(DeleteBehavior.Cascade);

        }


    }

}
