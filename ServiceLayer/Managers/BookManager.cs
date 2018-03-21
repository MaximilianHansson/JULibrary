using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceLayer.Models;
using RepositoryLayer.RepositoryManagers;

namespace ServiceLayer.Managers
{
	public class BookManager
	{
		public BookManager() { }

        public Book getBook(string isbn)
        {
            BookRepository bookManagerObj = new BookRepository();
            var temp = Mapper.Map<Book>(bookManagerObj.Read(isbn));
            return temp;
        }
		public List<Book> getBooks(string name)
		{
			BookRepository bookManagerObj = new BookRepository();
			return Mapper.Map<List<Book>>(bookManagerObj.ReadAll(name));
		}
        public List<Book> getBooksByIsbn(string isbn)
        {
            BookRepository bookManagerObj = new BookRepository();
            return Mapper.Map<List<Book>>(bookManagerObj.ReadAllByIsbn(isbn));
        }
        public List<Book> getBooksByClassi(string classi)
        {
            BookRepository bookManagerObj = new BookRepository();
            return Mapper.Map<List<Book>>(bookManagerObj.ReadAllByClassi(classi));
        }


        public List<Book> getAllBooks()
		{
			BookRepository bookManagerObj = new BookRepository();
			return Mapper.Map<List<Book>>(bookManagerObj.List());
		}
	}	
}
