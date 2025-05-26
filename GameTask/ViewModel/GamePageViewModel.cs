using GameTask.Command;
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
        }


        private void CheckCommand(object obj)
        {
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

            }
        }
    }
}
