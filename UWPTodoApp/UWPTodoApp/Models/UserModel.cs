using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPTodoApp.Models
{
    public class UserModel
    {
        public UserModel()
        {
            UserList = new List<User>
            {
                new User { UserId = User1Id, UserPassword = User1Password },
                new User { UserId = User2Id, UserPassword = User2Password },
                new User { UserId = User3Id, UserPassword = User3Password }
            };


        }

        public List<User> UserList { get; set; }

        public string[] UserId = { User1Id, User2Id, User3Id };

        private const string User1Id = "test001";

        private const string User2Id = "test002";

        private const string User3Id = "test003";

        public string[] UserPassword = { User1Password, User2Password, User3Password };

        private const string User1Password = "pass001";

        private const string User2Password = "pass002";

        private const string User3Password = "pass003";

        public string LoginUser { get; set; }

    }

    public class User
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }

    }
}
