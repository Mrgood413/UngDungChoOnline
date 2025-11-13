using Microsoft.EntityFrameworkCore;

namespace ChoOnlineAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<TrustHistory> TrustHistories { get; set; }
        public DbSet<AdminAction> AdminActions { get; set; }
        public DbSet<BanRecord> BanRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Role).IsRequired().HasConversion<string>();
                entity.Property(e => e.AccountStatus).IsRequired().HasConversion<string>();
                entity.Property(e => e.TrustScore).IsRequired();
                entity.HasCheckConstraint("CK_User_TrustScore", "TrustScore >= 0 AND TrustScore <= 100");
                entity.HasIndex(e => e.Email).IsUnique();
            });

            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Condition).IsRequired().HasConversion<string>();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.HasOne(e => e.Seller)
                    .WithMany(u => u.Products)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure ProductImage
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("Product_Images");
                entity.HasKey(e => e.ImageId);
                entity.Property(e => e.ImageUrl).IsRequired().HasMaxLength(500);
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.HasOne(e => e.Parent)
                    .WithMany(c => c.Children)
                    .HasForeignKey(e => e.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Review
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Reviews");
                entity.HasKey(e => e.ReviewId);
                entity.Property(e => e.Rating).IsRequired();
                entity.HasCheckConstraint("CK_Review_Rating", "Rating >= 1 AND Rating <= 5");
                entity.HasOne(e => e.Reviewer)
                    .WithMany(u => u.ReviewsGiven)
                    .HasForeignKey(e => e.ReviewerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Reviewee)
                    .WithMany(u => u.ReviewsReceived)
                    .HasForeignKey(e => e.RevieweeId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Transaction)
                    .WithMany(t => t.Reviews)
                    .HasForeignKey(e => e.TransactionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Comment
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comments");
                entity.HasKey(e => e.CommentId);
                entity.Property(e => e.Content).IsRequired();
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ParentComment)
                    .WithMany(c => c.Replies)
                    .HasForeignKey(e => e.ParentCommentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Transaction
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(e => e.TransactionId);
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Buyer)
                    .WithMany(u => u.TransactionsAsBuyer)
                    .HasForeignKey(e => e.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Seller)
                    .WithMany(u => u.TransactionsAsSeller)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Report
            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Reports");
                entity.HasKey(e => e.ReportId);
                entity.Property(e => e.ReportType).IsRequired().HasConversion<string>();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.Property(e => e.Priority).IsRequired().HasConversion<string>();
                entity.Property(e => e.ResolutionAction).HasConversion<string>();
                entity.HasOne(e => e.Reporter)
                    .WithMany(u => u.ReportsMade)
                    .HasForeignKey(e => e.ReporterId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ReportedUser)
                    .WithMany(u => u.ReportsReceived)
                    .HasForeignKey(e => e.ReportedUserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ReportedProduct)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(e => e.ReportedProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ReportedComment)
                    .WithMany()
                    .HasForeignKey(e => e.ReportedCommentId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Resolver)
                    .WithMany()
                    .HasForeignKey(e => e.ResolvedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Message
            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Messages");
                entity.HasKey(e => e.MessageId);
                entity.Property(e => e.Content).IsRequired();
                entity.HasOne(e => e.Conversation)
                    .WithMany(c => c.Messages)
                    .HasForeignKey(e => e.ConversationId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Sender)
                    .WithMany(u => u.Messages)
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Conversation
            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.ToTable("Conversations");
                entity.HasKey(e => e.ConversationId);
                entity.HasOne(e => e.Buyer)
                    .WithMany(u => u.ConversationsAsBuyer)
                    .HasForeignKey(e => e.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Seller)
                    .WithMany(u => u.ConversationsAsSeller)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Favorite
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.ToTable("Favorites");
                entity.HasKey(e => e.FavoriteId);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Favorites)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => new { e.UserId, e.ProductId }).IsUnique();
            });

            // Configure TrustHistory
            modelBuilder.Entity<TrustHistory>(entity =>
            {
                entity.ToTable("Trust_History");
                entity.HasKey(e => e.HistoryId);
                entity.Property(e => e.Reason).IsRequired().HasConversion<string>();
                entity.HasOne(e => e.User)
                    .WithMany(u => u.TrustHistories)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure AdminAction
            modelBuilder.Entity<AdminAction>(entity =>
            {
                entity.ToTable("Admin_Actions");
                entity.HasKey(e => e.ActionId);
                entity.Property(e => e.ActionType).IsRequired().HasConversion<string>();
                entity.Property(e => e.Reason).IsRequired();
                entity.HasOne(e => e.Admin)
                    .WithMany(u => u.AdminActionsPerformed)
                    .HasForeignKey(e => e.AdminId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.TargetUser)
                    .WithMany(u => u.AdminActionsReceived)
                    .HasForeignKey(e => e.TargetUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure BanRecord
            modelBuilder.Entity<BanRecord>(entity =>
            {
                entity.ToTable("Ban_Records");
                entity.HasKey(e => e.BanId);
                entity.Property(e => e.BanType).IsRequired().HasConversion<string>();
                entity.Property(e => e.Reason).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Notes).HasMaxLength(1000);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.BanRecords)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Report)
                    .WithMany(r => r.BanRecords)
                    .HasForeignKey(e => e.ReportId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.Admin)
                    .WithMany(u => u.BansIssued)
                    .HasForeignKey(e => e.BannedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
