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

        }

        public List<User> UserList { get; set; }

        public string[] dummyUserId = {
            "test001",
            "test002",
            "test003"
        };
        public string[] dummyUserPassword = {
            "pass001",
            "pass002",
            "pass003"
        };

        public User LoginUser { get; set; }

        public User login(String userId, String userPassword)
        {
            this.setDummyUserList();
            var user = UserList.Find(x => x.UserId == userId);

            // 一致したユーザーの場合にユーザー情報を返す
            if (user != null && user.UserPassword == userPassword)
            {
                return user;
            }

            // 一致していなかった場合はnullを返す（ログイン失敗）
            return null;
        }

        private void setDummyUserList()
        {
            UserList = new List<User>();
            for (int i = 0; i < dummyUserId.Length; i++)
            {
                UserList.Add(new User { UserId = dummyUserId[i], UserPassword = dummyUserPassword[i] });
            }
        }

    }

    public class User
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }

    }
}
