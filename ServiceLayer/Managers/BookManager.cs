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

		public List<Book> getBooks(string name)
		{
			BookRepository bookManagerObj = new BookRepository();
			return Mapper.Map<List<Book>>(bookManagerObj.ReadAll(name));
		}

		public List<Book> getAllBooks()
		{
			BookRepository bookManagerObj = new BookRepository();
			return Mapper.Map<List<Book>>(bookManagerObj.List());
		}
	}
}
