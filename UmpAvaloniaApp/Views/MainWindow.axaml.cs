using Avalonia.Controls;
using UmpAvaloniaApp.ViewModels;

namespace UmpAvaloniaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}