using GameTask.Command;
using GameTask.Core;
using GameTask.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameTask.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _nick;

        public string Nick
        {
            get => _nick;
            set
            {
                _nick = value;
                OnPropertyChanged(nameof(Nick));
            }
        }

        public ICommand Game { get; }
        public ICommand Results { get; }

        public MainWindowViewModel()
        {
            Game = new DelegateCommand(GameCommand);
            Results = new DelegateCommand(ResultsCommand);
        }

        private void ResultsCommand(object obj)
        {
            FrameManager.SetSource(new ResultsPage());
        }

        private void GameCommand(object obj)
        {
            FrameManager.SetSource(new GamePage());
        }
    }
}
