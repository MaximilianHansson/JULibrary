namespace RepositoryLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibDB : DbContext
    {
        public LibDB()
			//Fix from Peter LG
            : base("data source=libdb.cgonxecdluoj.eu-west-1.rds.amazonaws.com;initial catalog=dbGroupDM;persist security info=True;user id=student11;password=sdgfewethyttd;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<AUTHOR> AUTHOR { get; set; }
        public virtual DbSet<BOOK> BOOK { get; set; }
        public virtual DbSet<CLASSIFICATION> CLASSIFICATION { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.BOOK)
                .WithMany(e => e.AUTHOR)
                .Map(m => m.ToTable("BOOK_AUTHOR").MapLeftKey("Aid").MapRightKey("ISBN"));
        }

	}
}
