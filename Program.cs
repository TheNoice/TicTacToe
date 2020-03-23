using System;
using System.Windows.Forms;
using TicTacToe.Core.Services.Implementations;

namespace TicTacToe
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var gameService = new GameService();
            var aiService = new SmartAiPlayerService(gameService.WinConditions);
            Application.Run(new MainFrame(gameService, aiService));
        }
    }
}
