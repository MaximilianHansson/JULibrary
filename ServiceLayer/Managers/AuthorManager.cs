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
	public class AuthorManager
	{
		public AuthorManager() { }

		public List<Author> getAuthors(string name)
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
			return Mapper.Map<List<Author>>(authorManagerObj.List());
		}

		public List<Author> getAllAuthors()
		{
			AuthorRepository authorManagerObj = new AuthorRepository();
			return Mapper.Map<List<Author>>(authorManagerObj.List());
		}
	}
}
