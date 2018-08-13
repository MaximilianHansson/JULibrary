using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validation
{
	public class AuthorValidator
	{
		public AuthorValidator() { }

		public List<string> validate(string firstName, string lastName, string birthYear)
		{
			List<string> errors = new List<string>();

			//firstName
			if(firstName=="" || firstName == null)
			{
				errors.Add("First name missing");
			}
			if (!firstName.All(char.IsLetter))
			{
				errors.Add("First name can only have letters");
			}

			//lastName
			if (lastName == "" || lastName == null)
			{
				errors.Add("Last name missing");
			}
			if (!lastName.All(char.IsLetter))
			{
				errors.Add("Last name can only have letters");
			}

			//birthYear
			if (!birthYear.All(char.IsDigit))
			{
				errors.Add("Birth year needs to be a number");
			}

			return errors;
		}
	}
}
