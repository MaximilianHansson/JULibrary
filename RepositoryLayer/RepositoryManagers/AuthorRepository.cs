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

		public AuthorRepository(int authorID)
		{
			_authorObj = this.Read(authorID);
		}

        public AUTHOR Read(int Aid)
        {
            using (var db = new LibDB())
            {
				db.Configuration.LazyLoadingEnabled = false;
				return db.AUTHOR.FirstOrDefault(x => x.Aid.Equals(Aid));
            }
        }
		public List<AUTHOR> ReadAll(string name)
		{
			using (var db = new LibDB())
			{
				db.Configuration.LazyLoadingEnabled = false;
				//Only last name for now
				var query = db.AUTHOR.Where(a => a.LastName.Contains(name)).OrderBy(a => a.LastName).ToList();
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

		private AUTHOR _authorObj = null;


	}
}
