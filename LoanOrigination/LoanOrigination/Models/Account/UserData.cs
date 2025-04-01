using System.Security.Cryptography.X509Certificates;

namespace LoanOrigination.Models.Account
{
    public class UserData : IUsersData
    {
        private readonly UserDB userDB;
        public UserData(UserDB userDB)
        {
            this.userDB = userDB;
        }
        public Users GetUser(string username)
        {
            try
            {
                var record = userDB.User.FirstOrDefault(x => x.Username == username);
                if (record == null)
                {
                    throw new Exception("You are not authenticated to use");
                }
                else
                {
                    return record;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Server Error");
            }
        }
    }
}
