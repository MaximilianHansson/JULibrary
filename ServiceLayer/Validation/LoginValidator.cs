using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Validation
{
	public class LoginValidator
	{
		public LoginValidator() { }

		public List<string> validate(string username, string password)
		{
			List<string> errors = new List<string>();

			//username
			if (username == null || username == "")
			{
				errors.Add("Username cant be left empty");
			}

			//password
			if(password == null || password == "")
			{
				errors.Add("Please input your password");
			}

			return errors;
		}
	}
}
