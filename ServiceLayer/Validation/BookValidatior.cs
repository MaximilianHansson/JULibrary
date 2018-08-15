using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using RepositoryLayer.RepositoryManagers;
using RepositoryLayer;

namespace ServiceLayer.Validation
{
    public class BookValidatior
    {
        public BookValidatior() { }

        public List<string> validate(string title, string ISBN, string pages, string publicationInfo, List<string> authors)
        {
            List<string> errors = new List<string>();
            BookRepository bookTester = new BookRepository();
            AuthorRepository authortester = new AuthorRepository();

            //Title
            if (title == "" || title == null) { errors.Add("Title missing"); }

            //ISBN
            if (!(ISBN == "" || ISBN == null))
            {
				if (!ISBN.All(char.IsDigit))
				{
					errors.Add("ISBN needs to be a number");
				}

                if (bookTester.Read(ISBN) != null)
                {
                    errors.Add("ISBN taken");
                }
            }
            else { errors.Add("ISBN missing"); }

            //Pages
            if (!(pages == "" || pages == null)) {              
                if(!pages.All(char.IsDigit))
                {
                    errors.Add("Pages not a number");
                }
            }
            else
            {
                errors.Add("Pages missing");
            }

            //PublicationInfo
            if (publicationInfo == "" || publicationInfo == null) { errors.Add("PublicationInfo missing"); }

            //Authors
            if (!(authors.Count == 0 || authors == null)) {
                foreach (var author in authors)
                {
                    var grabbedAuthor = authortester.ReadUninclude(Convert.ToInt32(author));
                    if (grabbedAuthor == null)
                    {
                        errors.Add(string.Format("{0} is not an authors id",author));
                    }
                }
            }
            else { errors.Add("Authors missing"); }
            

            return errors;
        }
    }
}
