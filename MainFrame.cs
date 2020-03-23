using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TicTacToe.Core.Domain;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;
using TicTacToe.Core.Utils;
using TicTacToe.Extensions;

namespace TicTacToe
{
    public partial class MainFrame : Form
    {
        private readonly IGameService _gameService;
        private readonly IAiPlayerService _aiPlayerService;

        private readonly Dictionary<Position, Button> _positionToButtonMap;
        private readonly Dictionary<Button, Position> _buttonToPositionMap;
        private readonly Mark _playerMark;
        private readonly Mark _aiMark;

        public MainFrame(IGameService gameService, IAiPlayerService aiPlayerService)
        {
            InitializeComponent();
            CenterToScreen();

            _gameService = gameService;
            _aiPlayerService = aiPlayerService;

            _positionToButtonMap = new Dictionary<Position, Button>
            {
                {Position.TopLeft, buttonTopLeft }, {Position.TopCenter, buttonTopCenter}, {Position.TopRight, buttonTopRight},
                {Position.MidLeft, buttonMidLeft }, {Position.MidCenter, buttonMidCenter}, {Position.MidRight, buttonMidRight},
                {Position.BotLeft, buttonBotLeft }, {Position.BotCenter, buttonBotCenter}, {Position.BotRight, buttonBotRight},
            };
            _buttonToPositionMap = _positionToButtonMap.ToDictionary(x => x.Value, x => x.Key);

            _playerMark = Mark.Cross;
            _aiMark = Mark.Circle;

            //_gameService.StartNewGame(); лишний код, тк конструктор сам вызывает этот метод
            DrawCurrentState();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Text == string.Empty)
            {
                var playerMove = _buttonToPositionMap[clickedButton];

                GameStatus playerMoveResult = new GameStatus();

                try
                {
                    playerMoveResult = _gameService.Move(playerMove, _playerMark);
                }
                catch (GameValidityException ex)
                {
                    MessageBox.Show("An error occured. Restarting the game." + ex.Message);
                    File.AppendAllText($"log-{DateTime.Now.Date}.txt", ex.ToString() + ex.Message);
                    _gameService.StartNewGame();
                    DrawCurrentState();
                    return;
                }

                if (CheckIfGameIsFinished(playerMoveResult, out var playerMessage))
                {
                    OnGameEnded(playerMessage);
                    return;
                }

                var aiMove = _aiPlayerService.MakeTurn(_gameService.CurrentGameStatus);

                GameStatus aiMoveResult = new GameStatus();

                try
                {
                    aiMoveResult = _gameService.Move(aiMove, _aiMark);
                }
                catch (GameValidityException ex)
                {
                    MessageBox.Show("An error occured. Restarting the game." + ex.Message);
                    File.AppendAllText($"log-{DateTime.Now.Date}.txt", ex.ToString() + ex.Message);
                    _gameService.StartNewGame();
                    DrawCurrentState();
                    return;
                }

                if (CheckIfGameIsFinished(aiMoveResult, out var aiMessage))
                {
                    OnGameEnded(aiMessage);
                    return;
                }

                DrawCurrentState();
            }
        }

        private void OnGameEnded(string message)
        {
            DrawCurrentState();
            MessageBox.Show(message);
            _gameService.StartNewGame();
            DrawCurrentState();
        }

        private void OnExitMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private bool CheckIfGameIsFinished(GameStatus gameStatus, out string endGameMessage)
        {
            if (gameStatus.IsGameFinished)
            {
                if (gameStatus.Winner == _playerMark)
                    endGameMessage = "Congratulations, human! You have achieved a glorious victory!";
                else if (gameStatus.Winner == _aiMark)
                    endGameMessage = "This AI was too hard for you to handle. Good luck next time!";
                else
                    endGameMessage = "That's a draw! What a pity...";

                return true;
            }

            endGameMessage = string.Empty;
            return false;
        }

        private void DrawCurrentState()
        {
            foreach (var cell in _gameService.CurrentGameStatus.FieldState)
            {
                var button = _positionToButtonMap[cell.Key];
                button.Text = cell.Value.ToText();
            }
        }
    }
}
