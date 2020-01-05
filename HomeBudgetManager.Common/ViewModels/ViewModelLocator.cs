using HomeBudgetManager.Common.IoC;
using Ninject;

namespace HomeBudgetManager.Common.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IKernel kernel;

        public ViewModelLocator()
        {
            kernel = new StandardKernel(new Bindings());
        }

        public MainWindowViewModel Main
        {
            get
            {
                return kernel.Get<MainWindowViewModel>();
            }
        }
    }
}
