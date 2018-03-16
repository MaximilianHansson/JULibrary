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

		public BookRepository(int bookID)
		{
			_bookObj = this.Read(bookID);
		}

		public BOOK Read(int id)
		{
			using(var db = new LibDB())
			{
				return db.BOOK.FirstOrDefault(x => x.ISBN.Equals(id));
			}
		}

		public List<BOOK> ReadAll(string name)
		{
			using (var db = new LibDB())
			{
				var query = db.BOOK.Where(b => b.Title.Contains(name)).OrderBy(b => b.PublicationYear).ToList();
				return query;
			}
		}

		public List<BOOK> List()
		{
			using(var db = new LibDB())
			{
				return db.BOOK.ToList();
			}
		}

		private BOOK _bookObj = null;
	}
}
