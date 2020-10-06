using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTodoApp.Models;

namespace UWPTodoApp.Services
{
    public sealed class DataModelService
    {
        private static DataModelService _instance = new DataModelService();

        public static DataModelService Instance()
        {
            return _instance;
        }

        public void Initialize()
        {
            UserModel = new UserModel();
        }

        public UserModel UserModel { get; private set; }
    }
}
