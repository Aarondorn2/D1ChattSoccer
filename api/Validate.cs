using System.Text.RegularExpressions;

namespace D1SoccerApi {
	public static class Validate {
		const string EMAIL = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
		const string PASSWORD = @"^((?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]))";

		public static bool IsValidEmail(string email) {
			return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EMAIL);
		}
		
		public static bool IsValidPassword(string password) {
			return !string.IsNullOrWhiteSpace(password)
				   && password.Length > 6 && password.Length < 150
			       && Regex.IsMatch(password, PASSWORD);
		}
	}
}
