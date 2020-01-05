
namespace HomeBudgetManager
{
    public class MessagerListener
    {
        public bool BindableProperty => true;

        public MessagerListener()
        {
            Init();
        }

        private void Init()
        {
            //Messenger.Default.Register<OpenGroupManageWindow>(this, msg =>
            //{
            //    var window = new GroupManageWindow();
            //    var model = window.DataContext as GroupManageViewModel;
            //    window.ShowDialog();
            //});
        }
    }
}
