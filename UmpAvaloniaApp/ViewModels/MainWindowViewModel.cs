using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace UmpAvaloniaApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _greetingText = "Hello World";

        public string GreetingText
        {
            get => _greetingText;
            set
            {
                _greetingText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangeTextCommand { get; }

        public MainWindowViewModel()
        {
            ChangeTextCommand = new RelayCommand(ChangeText);
        }

        private void ChangeText()
        {
            GreetingText = "Button Clicked!";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;
        private EventHandler? _canExecuteChanged;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object? parameter) => _execute();

        public event EventHandler? CanExecuteChanged
        {
            add => _canExecuteChanged += value;
            remove => _canExecuteChanged -= value;
        }

        public void RaiseCanExecuteChanged()
        {
            _canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}