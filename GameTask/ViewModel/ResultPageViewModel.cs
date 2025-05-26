using GameTask.Core;
using GameTask.Model;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTask.ViewModel
{
    public class ResultPageViewModel: BaseViewModel
    {
        private readonly FileManager _fileManager;
        private ObservableCollection<GameResult> _gameResult;

        public ObservableCollection<GameResult> GameResults
        {
            get => _gameResult;
            set
            {
                _gameResult = value;
                OnPropertyChanged(nameof(GameResults));
            }
        }

        public ResultPageViewModel() 
        {
            _fileManager = new();
            GameResults = new();

            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                var results = await _fileManager.ReadFile("Results");

                if (!string.IsNullOrEmpty(results))
                {
                    var splitedData = results.Split("\r\n");
                    splitedData = splitedData.Take(splitedData.Length - 1).ToArray();

                    foreach (var result in splitedData)
                    {
                        var splitedResult = result.Split(", ");

                        GameResults.Add(new GameResult
                        {
                            PlayerName = splitedResult[0],
                            Attempts = int.Parse(splitedResult[1]),
                            Date = DateTime.Parse(splitedResult[2])
                        });
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Warning("При чтении данных произошла ошибка.");
            }
        }
    }
}
