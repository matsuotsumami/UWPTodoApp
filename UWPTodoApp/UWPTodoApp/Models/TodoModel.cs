using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTodoApp.Components;

namespace UWPTodoApp.Models
{
    public class TodoModel
    {
        public ObservableCollection<TodoTextItem> TodoItemList { get; set; } = new ObservableCollection<TodoTextItem>();

        public void Todo_Delete()
        {

        }
    }
}
