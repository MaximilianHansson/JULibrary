using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validation
{
	public class SignUpValidator
	{
		public SignUpValidator() { }

		public List<string> validate(string username, string password)
		{
			List<string> errors = new List<string>();

			//username
			if(username == null || username == "")
			{
				errors.Add("Username can't be empty");
			}
			if (!username.All(char.IsLetterOrDigit))
			{
				errors.Add("Username can only contain of letters and digits");
			}

			//password
			if(password == null || password == "")
			{
				errors.Add("Password can't be left empty");
			}
			if(!password.Any(char.IsUpper))
			{
				errors.Add("Password needs to have atleast one upper letter");
			}
			if (!password.Any(char.IsNumber))
			{
				errors.Add("Password needs to have atleast one number");
			}
			if(!(password.Length > 4))
			{
				errors.Add("Password needs to be atleast 5 characters long");
			}

			return errors;
		}
	}
}
