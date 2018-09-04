using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace RepositoryLayer.RepositoryManagers
{
	public class AuthorRepository
	{
		public AuthorRepository() { }

		public AUTHOR Read(int Aid)
		{
			using (var db = new LibDB())
			{
				db.Configuration.LazyLoadingEnabled = false;
				return db.AUTHOR.Include(x => x.BOOK).FirstOrDefault(x => x.Aid.Equals(Aid));

            }
        }
        public AUTHOR ReadUninclude(int Aid)
        {
            using (var db = new LibDB())
            {
                db.Configuration.LazyLoadingEnabled = false;
                try { return db.AUTHOR.FirstOrDefault(x => x.Aid.Equals(Aid)); }
                catch { return null; }
                
            }
        }
        public List<AUTHOR> ReadAll(string name)
		{
			using (var db = new LibDB())
			{
				db.Configuration.LazyLoadingEnabled = false;
				var query = db.AUTHOR.Where(a => a.LastName.Contains(name) || a.FirstName.Contains(name)).OrderBy(a => a.LastName).ToList();
				return query;
			}
		}
		public List<AUTHOR> List()
		{
			using (var db = new LibDB())
			{
				db.Configuration.LazyLoadingEnabled = false;
				var query = db.AUTHOR.ToList();
				return query;
			}
		}

		public void CreateNew(AUTHOR author)
		{
			using (var db = new LibDB())
			{

				db.AUTHOR.Add(author);
                db.SaveChanges();
			}

		}

		public void Delete(int Aid)
		{
			using (var db = new LibDB())
			{ 
				//var author = this.Read(Aid);
				//db.AUTHOR.Remove(author);
				//db.SaveChanges();
				db.Configuration.LazyLoadingEnabled = false;
				//This line is the same as int "Read", will get error if i try to call it as commented out bellow
				//var author = db.AUTHOR.Include(x => x.BOOK).FirstOrDefault(x => x.Aid.Equals(Aid));
				var author = db.AUTHOR.SingleOrDefault(a => a.Aid == Aid);
				db.AUTHOR.Remove(author);
				db.SaveChanges();
			}
		}

		public void Edit(AUTHOR newAuthor)
		{
			using(var db = new LibDB())
			{

				//Remove author all together from database
				db.Configuration.LazyLoadingEnabled = false;
				var editedAuthor = db.AUTHOR.FirstOrDefault(x => x.Aid.Equals(newAuthor.Aid));
				db.AUTHOR.Remove(editedAuthor);
                //this.Delete(oldAuthor.Aid);
                editedAuthor.FirstName = newAuthor.FirstName;
                editedAuthor.LastName = newAuthor.LastName;
                editedAuthor.BirthYear = newAuthor.BirthYear;

				db.Entry(editedAuthor).State = EntityState.Modified;
				db.SaveChanges();
			}
		}
	}
}
