using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace RepositoryLayer.RepositoryManagers
{
	public class BookRepository
	{
		public BookRepository() { }

		public BookRepository(string isbn)
		{
			_bookObj = this.Read(isbn);
		}

		public BOOK Read(string isbn)
		{
			using(var db = new LibDB())
			{
                db.Configuration.LazyLoadingEnabled = false;
                var query = db.BOOK.Include(b => b.AUTHOR).First(b => b.ISBN.Equals(isbn));
                return query;
			}
		}

		public List<BOOK> ReadAll(string name)
		{
			using (var db = new LibDB())
			{
                db.Configuration.LazyLoadingEnabled = false;
                var query = db.BOOK.Include(x => x.AUTHOR).Where(b => b.Title.Contains(name)).OrderBy(b => b.PublicationYear).ToList();
				return query;
			}
		}
        public List<BOOK> ReadAllByIsbn(string isbn)
        {
            using (var db = new LibDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var query = db.BOOK.Include(x => x.AUTHOR).Where(b => b.ISBN.Contains(isbn)).OrderBy(b => b.PublicationYear).ToList();
                return query;
            }
        }
        public List<BOOK> ReadAllByClassi(string classi)
        {
            using (var db = new LibDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var query = db.BOOK.Include(x => x.AUTHOR).Where(b => b.CLASSIFICATION.ToString().Contains(classi)).OrderBy(b => b.PublicationYear).ToList();
                return query;
            }
        }

        public List<BOOK> List()
		{
			using(var db = new LibDB())
			{
                db.Configuration.LazyLoadingEnabled = false;
                var query = db.BOOK.Include(x => x.AUTHOR).ToList();
                return query;
			}
		}

        public void CreateNew(BOOK book)
        {
            using(var db = new LibDB())
            {
                db.BOOK.Add(book);
                db.SaveChanges();
            }
        }

		private BOOK _bookObj = null;
	}
}
