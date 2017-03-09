using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using uct.ItemName.Shell;

namespace uct.ItemName
{
    public partial class ViewModelLocator
    {
        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public void RegisterShell() => SimpleIoc.Default.Register<ShellViewModel>();
    }
}