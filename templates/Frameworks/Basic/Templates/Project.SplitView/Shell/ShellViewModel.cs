using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using uct.ItemName.Mvvm;
using uct.ItemName.Services;

namespace uct.ItemName.Shell
{
    public class ShellViewModel : Observable
    {
        #region IsPaneOpen
        private bool _isPaneOpen;
        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }
        #endregion

        #region SelectedItem
        private ShellNavigationItem _selectedItem;
        public ShellNavigationItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(ref _selectedItem, value);
                NavigateToItem(value);
            }
        }

        #endregion

        public ShellViewModel() 
        {
            _navigationItems = new List<ShellNavigationItem>();

            //More on Segoe UI Symbol icons: https://docs.microsoft.com/windows/uwp/style/segoe-ui-symbol-font
            //Edit String/en-US/Resources.resw: Add a menu item title for each page
        }

        private List<ShellNavigationItem> _navigationItems;
        public List<ShellNavigationItem> NavigationItems
        {
            get { return _navigationItems; }
            set { Set(ref _navigationItems, value); }
        }

        

        #region OpenPaneCommand
        private ICommand _openPaneCommand;
        public ICommand OpenPaneCommand
        {
            get
            {
                if(_openPaneCommand == null)
                {
                    _openPaneCommand = new RelayCommand(() => IsPaneOpen = !_isPaneOpen);
                }
                
                return _openPaneCommand;
            }
        }
        #endregion

        public void InitializeNavigationItems(object parameter)
        {
            Type pageType = typeof(HomePage);
            if (parameter != null && !String.IsNullOrEmpty(parameter.ToString()))
            {
                if (parameter is Type)
                {
                    pageType = parameter as Type;
                }
            }
            SelectedItem = NavigationItems.FirstOrDefault(i => i.PageType == pageType);
        }

        private void NavigateToItem(ShellNavigationItem navigationItem) => NavigationService.Navigate(navigationItem?.PageType);
    }
}
