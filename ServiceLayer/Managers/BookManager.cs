using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceLayer.Models;
using RepositoryLayer.RepositoryManagers;
using RepositoryLayer;

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

        public void createBook(string title, string ISBN, string pages, string publicationInfo, string signId, List<string> authors)
        {
            BookRepository bookManagerObj = new BookRepository();
            Book newBook = new Book();
            newBook.Title = title;
            newBook.ISBN = ISBN;
            newBook.pages = Convert.ToInt16(pages);
            newBook.publicationinfo = publicationInfo;
            newBook.SignId = Convert.ToInt32(signId);
            AuthorRepository authorGrabber = new AuthorRepository();
            List<AUTHOR> authorList = new List<AUTHOR>();
            foreach (var author in authors)
            {
                var grabbedAuthor = authorGrabber.ReadUninclude(Convert.ToInt32(author));
                authorList.Add(grabbedAuthor);
            }
            newBook.Author = Mapper.Map<List<Author>>(authorList);

            bookManagerObj.CreateNew(Mapper.Map<BOOK>(newBook));
        }

        public void editBook(string title, string ISBN, string pages, string publicationInfo, List<string> authors, string oldISBN)
        {
            BookRepository bookManagerObj = new BookRepository();
            Book newBook = new Book();
            newBook.Title = title;
            newBook.ISBN = ISBN;
            newBook.pages = Convert.ToInt16(pages);
            newBook.publicationinfo = publicationInfo;
            AuthorRepository authorGrabber = new AuthorRepository();
            List<AUTHOR> authorList = new List<AUTHOR>();
            foreach (var author in authors)
            {
                var grabbedAuthor = authorGrabber.ReadUninclude(Convert.ToInt32(author));
                authorList.Add(grabbedAuthor);
            }
            newBook.Author = Mapper.Map<List<Author>>(authorList);

            bookManagerObj.Edit(Mapper.Map<BOOK>(newBook), oldISBN);
        }
    }	
}
