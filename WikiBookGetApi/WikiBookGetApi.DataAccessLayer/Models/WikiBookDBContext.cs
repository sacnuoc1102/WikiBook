using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WikiBookGetApi.DataAccessLayer.Models
{
    public partial class WikiBookDBContext : DbContext
    {
        public WikiBookDBContext()
        {
        }

        public WikiBookDBContext(DbContextOptions<WikiBookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookTag> BookTags { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<LikedBookByUser> LikedBookByUser { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ToRead> ToRead { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=WikiBookDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BookTag>(entity =>
            {
                entity.ToTable("book_tags");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.GoodreadsBookId).HasColumnName("goodreads_book_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("books");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Authors)
                    .IsRequired()
                    .HasColumnName("authors")
                    .HasMaxLength(150);

                entity.Property(e => e.AverageRating).HasColumnName("average_rating");

                entity.Property(e => e.BestBookId).HasColumnName("best_book_id");

                entity.Property(e => e.BooksCount).HasColumnName("books_count");

                entity.Property(e => e.GoodreadsBookId).HasColumnName("goodreads_book_id");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("image_url")
                    .HasMaxLength(100);

                entity.Property(e => e.Isbn)
                    .HasColumnName("isbn")
                    .HasMaxLength(50);

                entity.Property(e => e.Isbn13).HasColumnName("isbn13");

                entity.Property(e => e.LanguageCode)
                    .HasColumnName("language_code")
                    .HasMaxLength(50);

                entity.Property(e => e.OriginalPublicationYear).HasColumnName("original_publication_year");

                entity.Property(e => e.OriginalTitle)
                    .HasColumnName("original_title")
                    .HasMaxLength(150);

                entity.Property(e => e.Ratings1).HasColumnName("ratings_1");

                entity.Property(e => e.Ratings2).HasColumnName("ratings_2");

                entity.Property(e => e.Ratings3).HasColumnName("ratings_3");

                entity.Property(e => e.Ratings4).HasColumnName("ratings_4");

                entity.Property(e => e.Ratings5).HasColumnName("ratings_5");

                entity.Property(e => e.RatingsCount).HasColumnName("ratings_count");

                entity.Property(e => e.SmallImageUrl)
                    .IsRequired()
                    .HasColumnName("small_image_url")
                    .HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(200);

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.Property(e => e.WorkRatingsCount).HasColumnName("work_ratings_count");

                entity.Property(e => e.WorkTextReviewsCount).HasColumnName("work_text_reviews_count");
            });

            modelBuilder.Entity<LikedBookByUser>(entity =>
            {
                entity.HasKey(e => new { e.UserIdentity, e.BookId });

                entity.Property(e => e.UserIdentity).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.LikedBookByUser)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikedBookByUser_books");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId });

                entity.ToTable("ratings");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.RatingValue).HasColumnName("rating");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.ToTable("tags");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasColumnName("tag_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ToRead>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BookId });

                entity.ToTable("to_read");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");
            });
        }
    }
}
