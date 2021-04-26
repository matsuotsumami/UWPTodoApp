using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPTodoApp.Helper;
using UWPTodoApp.Services;
using UWPTodoApp.Models;
using Windows.UI.Xaml;
using UWPTodoApp.Components;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.System;

namespace UWPTodoApp.ViewModels
{
    public class TodoViewModel : Observable
    {
        private UserModel userModel = DataModelService.Instance().UserModel;

        private TodoModel todoModel = DataModelService.Instance().TodoModel;

        public void Initialize()
        {

        }

        public void GoSigninPage()
        {
            NavigateService.GoSignIn();
        }

        public void GoTopPage()
        {
            NavigateService.GoTopView();
        }

        private string _todoText;
        public string TodoText
        {
            get { return _todoText; }
            set { Set(ref _todoText, value); }
        }

        public ObservableCollection<TodoTextItem> TodoItemList { get; set; } = new ObservableCollection<TodoTextItem>();

        /// <summary>
        /// Todo追加ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async Task Todo_Add()
        {
            TodoTextItem todoTextItem = new TodoTextItem();

            if (string.IsNullOrEmpty(TodoText) || string.IsNullOrWhiteSpace(TodoText))
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "エラー",
                    Content = "追加するTodoがありません。",
                    CloseButtonText = "閉じる"
                };

                ContentDialogResult result = await dialog.ShowAsync();

                return;
            }

            // 追加したいTodoがすでにあるかチェック
            for (int i = 0; i < TodoItemList.Count; i++)
            {
                // 同じTodoがあったら
                if (TodoItemList[i].Text == TodoText)
                {
                    ContentDialog dialog = new ContentDialog
                    { 
                        Title = "確認",
                        Content = "同じTodoがありますが追加しますか？",
                        PrimaryButtonText = "OK",
                        CloseButtonText = "キャンセル"
                    };

                    ContentDialogResult result = await dialog.ShowAsync();

                    // 閉じるを押下したとき
                    if (result == ContentDialogResult.None)
                    {
                        return;
                    }
                    else if (result == ContentDialogResult.Primary)
                    {
                        break;
                    }
                }
            }

            todoTextItem.Text = TodoText;

            todoTextItem.Click += TodoItemInList_Delete;

            TodoItemList.Add(todoTextItem);

            todoModel.TodoItemList = TodoItemList;
        }

        public async void TodoTextBoxEnterKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                await Todo_Add();
            }
        }

        /// <summary>
        /// ×ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TodoItemInList_Delete(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var grid = (Grid)button.Parent;
            var todoTextItem = (TodoTextItem)grid.Parent;

            TodoItemList.Remove(todoTextItem);
        }

        /// <summary>
        /// Checkが付いたTodoを削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void AllTodoIsChecked_Delete(object sender, RoutedEventArgs e)
        {
            if (TodoItemList.Count != 0)
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "確認",
                    Content = "Checkが付いたTodoをすべて削除します。よろしいですか？",
                    PrimaryButtonText = "OK",
                    CloseButtonText = "キャンセル"
                };

                ContentDialogResult result = await dialog.ShowAsync();

                // OKのとき
                if (result == ContentDialogResult.Primary)
                {

                    for (int i = TodoItemList.Count - 1; i >= 0; i--)
                    {
                        if (TodoItemList[i].IsChecked == true)
                        {
                            TodoItemList.RemoveAt(i);
                        }
                    }

                    // ObservableCollectionは↓はない
                    //TodoItemList.RemoveAll(s => s.IsChecked == true);
                }

                todoModel.TodoItemList = TodoItemList;
            }
        }

    }
}
