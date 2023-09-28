using System.Windows;
using System.Windows.Input;
using WindowsRegistry.Componentes.Core;

namespace WindowsRegistry.MVVM.ViewModel
{
  class MainViewModel : ObservableObject
  {
    //>> ATTRIBUTE
    public RelayCommand DiffViewCommand { get; set; }
    public RelayCommand HomeViewCommand { get; set; }
    public RelayCommand RegistryViewCommand { get; set; }
    public RelayCommand SettingsViewCommand { get; set; }
    public RelayCommand ShowViewCommand { get; set; }
    public RelayCommand WatcherViewCommand { get; set; }
    public DiffViewModel DiffVM { get; set; }
    public HomeViewModel HomeVM { get; set; }
    public RegistryViewModel RegistryVM { get; set; }
    public SettingsViewModel SettingsVM { get; set; }
    public ShowViewModel ShowVM { get; set; }
    public WatcherViewModel WatcherVM { get; set; }

    private object _currentView;
    public object CurrentView
    {
      get { return _currentView; }
      set
      {
        _currentView = value;
        OnPropertyChanged();
      }
    }

    private RelayCommand minimizeCommand;
    public ICommand MinimizeCommand
    {
      get
      {
        if (minimizeCommand == null)
        {
          minimizeCommand = new RelayCommand(param => MinimizeWindow());
        }
        return minimizeCommand;
      }
    }

    private RelayCommand maximizeCommand;
    public ICommand MaximizeCommand
    {
      get
      {
        if (maximizeCommand == null)
        {
          maximizeCommand = new RelayCommand(param => MaximizeWindow());
        }
        return maximizeCommand;
      }
    }

    private RelayCommand closeCommand;
    public ICommand CloseCommand
    {
      get
      {
        if (closeCommand == null)
        {
          closeCommand = new RelayCommand(param => CloseWindow());
        }
        return closeCommand;
      }
    }
    private void MinimizeWindow()
    {
      Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void MaximizeWindow()
    {
      if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
      {
        Application.Current.MainWindow.WindowState = WindowState.Normal;
      }
      else
      {
        Application.Current.MainWindow.WindowState = WindowState.Maximized;
      }
    }

    private void CloseWindow()
    {
      Application.Current.MainWindow.Close();
    }


    public MainViewModel()
    {
      DiffVM = new DiffViewModel();
      HomeVM = new HomeViewModel();
      RegistryVM = new RegistryViewModel();
      SettingsVM = new SettingsViewModel();
      ShowVM = new ShowViewModel();
      WatcherVM = new WatcherViewModel();
      CurrentView = HomeVM;

      DiffViewCommand = new RelayCommand(o =>
      {
        CurrentView = DiffVM;
      });

      HomeViewCommand = new RelayCommand(o =>
      {
        CurrentView = HomeVM;
      });

      RegistryViewCommand = new RelayCommand(o =>
      {
        CurrentView = RegistryVM;
      });

      SettingsViewCommand = new RelayCommand(o =>
      {
        CurrentView = SettingsVM;
      });

      ShowViewCommand = new RelayCommand(o =>
      {
        CurrentView = ShowVM;
      });

      WatcherViewCommand = new RelayCommand(o =>
      {
        CurrentView = WatcherVM;
      });
    }
  }
}
