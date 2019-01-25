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
            : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Serverside;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        public virtual DbSet<AUTHOR> AUTHOR { get; set; }
        public virtual DbSet<BOOK> BOOK { get; set; }
        public virtual DbSet<CLASSIFICATION> CLASSIFICATION { get; set; }
        public virtual DbSet<ADMINISTARTOR> ADMINISTARTOR { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.BOOK)
                .WithMany(e => e.AUTHOR)
                .Map(m => m.ToTable("BOOK_AUTHOR").MapLeftKey("Aid").MapRightKey("ISBN"));
        }

	}
}
