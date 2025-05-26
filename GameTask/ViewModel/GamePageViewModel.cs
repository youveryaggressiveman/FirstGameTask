using GameTask.Command;
using GameTask.Core;
using GameTask.Model;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameTask.ViewModel
{
    public class GamePageViewModel: BaseViewModel
    {
        private readonly FileManager _fileManager;
        private readonly Random _random;

        private int _attempt;

        public int Attempt
        {
            get => _attempt;
            set
            {
                _attempt = value;
                OnPropertyChanged(nameof(Attempt));
            }
        }

        private int _number;

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private int _variable;
        public int Variable
        {
            get => _variable;
            set
            {
                _variable = value;
                OnPropertyChanged(nameof(Variable));
            }
        }

        public ICommand Check { get; }

        public GamePageViewModel()
        {
            _fileManager = new();
            _random = new();

            Check = new DelegateCommand(CheckCommand);

            GenerateData();
        }

        private void GenerateData()
        {
            Number = _random.Next(1, 101);
            Attempt = 0;
            Variable = 1;
        }


        private async void CheckCommand(object obj)
        {
            Attempt++;

            if(Number > Variable)
            {
                MessageBox.Info("Загаданное число больше.");
            }
            else if(Number < Variable)
            {
                MessageBox.Info("Загаданное число меньше.");
            }
            else
            {
                var result = System.Windows.MessageBox.Show("Вы хотите сохранить результат?", "Подтверждение", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);

                var nick = ((System.Windows.Application.Current.MainWindow as MainWindow).DataContext as MainWindowViewModel).Nick;

                if (result == System.Windows.MessageBoxResult.Yes)
                {
                    try
                    {
                        await _fileManager.WriteFile(new GameResult()
                        {
                            Attempts = Attempt,
                            PlayerName = !string.IsNullOrEmpty(nick) ? nick : "Гость",
                            Date = DateTime.Now,
                        }, "Results");
                    }
                    catch (Exception)
                    {
                        MessageBox.Warning("При сохранении произошла ошибка.");
                    }
                   
                }
                
                GenerateData();

                MessageBox.Info("Данные были сброшены!\nМожете играть снова.");
            }
        }
    }
}
