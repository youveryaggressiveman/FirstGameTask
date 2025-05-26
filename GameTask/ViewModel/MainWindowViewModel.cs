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
