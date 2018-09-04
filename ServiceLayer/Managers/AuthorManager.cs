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
	public class AuthorManager
	{
		public AuthorManager() { }

		public Author getAuthor(int Aid)
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
			return Mapper.Map<Author>(authorManagerObj.Read(Aid));
		}

		public List<Author> getAuthors(string name)
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
			return Mapper.Map<List<Author>>(authorManagerObj.ReadAll(name));
		}

		public List<Author> getAllAuthors()
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
			return Mapper.Map<List<Author>>(authorManagerObj.List());
		}

		public void createAuthor(string firstName, string lastName, string birthYear)
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
            AUTHOR author = new AUTHOR();
            author.FirstName = firstName;
            author.LastName = lastName;
            author.BirthYear = birthYear;
			authorManagerObj.CreateNew(author);
		}

		public void deleteAuthor(int Aid)
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
			authorManagerObj.Delete(Aid);
		}

		public void editAuthor(string firstName, string lastName, string birthYear, int Aid)
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
            AUTHOR author = new AUTHOR();
            author.FirstName = firstName;
            author.LastName = lastName;
            author.BirthYear = birthYear;
            author.Aid = Aid;
            authorManagerObj.Edit(author);
		}
	}
}
