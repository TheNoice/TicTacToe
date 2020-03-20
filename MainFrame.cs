using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class MainFrame : Form
    {
        List<Button> freeButtons;
        List<Button> occupiedButtons = new List<Button>();
        Rules rules = new Rules();
        public MainFrame()
        {
            InitializeComponent();
            CenterToScreen();
            freeButtons = new List<Button>
            {
                buttonTopCenter, buttonTopLeft, buttonTopRight,
                buttonMidCenter, buttonMidLeft, buttonMidRight,
                buttonBotRight, buttonBotLeft, buttonBotCenter
            };
        }

        #region Buttons Clicks
        private void AnyButton_Click(object sender, EventArgs e)
        {
            ButtonChangeText(sender);
        }
        #endregion

        #region Private Helpers
        private void ButtonChangeText(object sender)
        {
            Button b = (Button)sender;
            if (b.Text == string.Empty)
            {
                b.Text = "X";
                freeButtons.Remove(b);
                occupiedButtons.Add(b);

                string checkIfEnd = rules.CheckWinCondition(occupiedButtons, freeButtons);
                if (checkIfEnd == "human")
                {
                    MessageBox.Show("Congratulations, human! You have achieved a glorious victory!");
                    RefreshButtonsState();
                }
                else if (checkIfEnd == "draw")
                {
                    MessageBox.Show("That's a draw! What a pity...");
                    RefreshButtonsState();
                }
                else if (checkIfEnd == "continue" && freeButtons.Any())
                {
                    ComputerTurn();
                    checkIfEnd = rules.CheckWinCondition(occupiedButtons, freeButtons);
                    if (checkIfEnd == "computer")
                    {
                        MessageBox.Show("This AI was too hard for you to handle. Good luck next time!");
                        RefreshButtonsState();
                    }
                }
            }
        }

        private void RefreshButtonsState()
        {
            freeButtons = new List<Button>() {buttonMidCenter, buttonMidLeft, buttonMidRight, buttonTopCenter, buttonTopLeft, buttonTopRight,
            buttonBotRight, buttonBotLeft, buttonBotCenter};
            occupiedButtons = new List<Button>();
            foreach (Button button in freeButtons)
            {
                button.Text = string.Empty;
            }
        }

        private void ComputerTurn()
        {
            ComputerButtonSearch cbs = new ComputerButtonSearch();
            bool turnComplete = false;
            ComputerFirstTurn(cbs, out turnComplete);
            if (turnComplete == true)
            {
                return;
            }
            else
            {
                ComputerFindsBestLine(cbs);
            }

        }

        private void ComputerFindsBestLine(ComputerButtonSearch cbs)
        {
            bool turnComplete = false;
            bool canWin = true;
            List<Button> tmpOccupiedButtons = new List<Button>(occupiedButtons);
            int buttonWithO;
            while (!turnComplete)
            {
                cbs.Text4Search = "O";
                buttonWithO = tmpOccupiedButtons.FindIndex(cbs.TextContainsString);
                if (buttonWithO >= 0 && canWin == true)
                {
                    ComputerFirstOptionTurn(tmpOccupiedButtons, cbs, out turnComplete);
                    if (turnComplete)
                    {
                        return;
                    }
                    else
                    {
                        canWin = false;
                    }
                }
                if (buttonWithO >= 0 && canWin == false)
                {
                    ComputerSecondOptionTurn(tmpOccupiedButtons, buttonWithO, cbs, out turnComplete);
                    if (turnComplete)
                    {
                        return;
                    }
                    tmpOccupiedButtons.Remove(tmpOccupiedButtons[buttonWithO]);
                }
                else
                {
                    Random computerChoice = new Random();
                    int computerTurn = computerChoice.Next(0, freeButtons.Count);
                    freeButtons[computerTurn].Text = "O";
                    occupiedButtons.Add(freeButtons[computerTurn]);
                    freeButtons.Remove(freeButtons[computerTurn]);
                    turnComplete = true;
                }
            }
        }

        private void ComputerFirstOptionTurn(List<Button> tmpOccupiedButtons, ComputerButtonSearch cbs, out bool turnComplete)
        {
            if (ComputerTryWinOrCounter(tmpOccupiedButtons, cbs, "X", "O"))
            {
                turnComplete = true;
            }
            else if (ComputerTryWinOrCounter(tmpOccupiedButtons, cbs, "O", "X"))
            {
                turnComplete = true;
            }
            else
            {
                turnComplete = false;
            }
        }

        private bool ComputerTryWinOrCounter(List<Button> tmpOccupiedButtons, ComputerButtonSearch cbs, string buttonTextexclude, string textForSearch) 
        {
            //buttonTextexclude X - win, O - counter
            //textForSearch O - win, X - counter 
            bool turnComplete = false;
            int buttonWithText = 0;
            List<Button> tmpOccupiedButtons2 = new List<Button>(tmpOccupiedButtons);
            cbs.Text4Search = buttonTextexclude;
            tmpOccupiedButtons2.RemoveAll(cbs.TextContainsString);

            while (tmpOccupiedButtons2.Any())
            {
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Bot"))
                {
                    cbs.Name4Search = "Bot";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Mid"))
                {
                    cbs.Name4Search = "Mid";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Top"))
                {
                    cbs.Name4Search = "Top";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Left"))
                {
                    cbs.Name4Search = "Left";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Center"))
                {
                    cbs.Name4Search = "Center";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2[buttonWithText].Name.Contains("Right"))
                {
                    cbs.Name4Search = "Right";
                    turnComplete = BestHorizontalAndVerticalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (ButtonIsDiagonal(tmpOccupiedButtons2[buttonWithText]))
                {
                    turnComplete = BestDiagonalTurn(cbs, textForSearch);
                    if (turnComplete)
                    {
                        return true;
                    }
                }
                if (tmpOccupiedButtons2.Any())
                {
                    tmpOccupiedButtons2.Remove(tmpOccupiedButtons2[buttonWithText]);
                }
            }
            return false;
        }

        private void ComputerSecondOptionTurn(List<Button> tmpOccupiedButtons, int buttonWithO, ComputerButtonSearch cbs, out bool turnComplete)
        {
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Bot"))
            {
                cbs.Name4Search = "Bot";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Mid"))
            {
                cbs.Name4Search = "Mid";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Top"))
            {
                cbs.Name4Search = "Top";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Left"))
            {
                cbs.Name4Search = "Left";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Center"))
            {
                cbs.Name4Search = "Center";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (tmpOccupiedButtons[buttonWithO].Name.Contains("Right"))
            {
                cbs.Name4Search = "Right";
                turnComplete = HorizontalAndVerticalTurn(cbs);
                if (turnComplete)
                {
                    return;
                }
            }
            if (ButtonIsDiagonal(tmpOccupiedButtons[buttonWithO]))
            {
                turnComplete = DiagonalTurn();
                if (turnComplete)
                {
                    return;
                }
            }
            else
            {
                turnComplete = false;
            }
        }

        private bool HorizontalAndVerticalTurn(ComputerButtonSearch cbs)
        {
            List<Button> rowOrColumnFreeButtons = freeButtons.FindAll(cbs.NameContainsString);
            if (rowOrColumnFreeButtons.Count == 2)
            {
                rowOrColumnFreeButtons[0].Text = "O";
                occupiedButtons.Add(rowOrColumnFreeButtons[0]);
                freeButtons.Remove(rowOrColumnFreeButtons[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool BestHorizontalAndVerticalTurn(ComputerButtonSearch cbs, string textForSearch)
        {
            cbs.Text4Search = textForSearch;
            List<Button> rowOrColumnFreeButtons = freeButtons.FindAll(cbs.NameContainsString); //на условном боте 1 фри кнопка
            List<Button> allOccupiedBySomeoneButtons = occupiedButtons.FindAll(cbs.TextContainsString); //все кнопки с O
            List<Button> rowOrColumnOccupiedBySomeoneButtons = allOccupiedBySomeoneButtons.FindAll(cbs.NameContainsString); //на условном боте 2 кнопки с O
            if (rowOrColumnFreeButtons.Count == 1 && rowOrColumnOccupiedBySomeoneButtons.Count == 2)
            {
                rowOrColumnFreeButtons[0].Text = "O";
                occupiedButtons.Add(rowOrColumnFreeButtons[0]);
                freeButtons.Remove(rowOrColumnFreeButtons[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ButtonIsDiagonal(Button b)
        {
            if (b == buttonBotLeft || b == buttonBotRight || b == buttonTopRight || b == buttonTopLeft || b == buttonMidCenter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool DiagonalTurn()
        {
            if (buttonBotLeft.Text == buttonMidCenter.Text && buttonBotLeft.Text == buttonTopRight.Text && buttonBotLeft.Text == string.Empty)
            {
                buttonMidCenter.Text = "O";
                occupiedButtons.Add(buttonMidCenter);
                freeButtons.Remove(buttonMidCenter);
                return true;
            }
            else if (buttonBotRight.Text == buttonMidCenter.Text && buttonBotRight.Text == buttonTopLeft.Text && buttonBotRight.Text == string.Empty)
            {
                buttonMidCenter.Text = "O";
                occupiedButtons.Add(buttonMidCenter);
                freeButtons.Remove(buttonMidCenter);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool BestDiagonalTurn(ComputerButtonSearch cbs, string textForSearch)
        {
            List<Button> firstDiagonal = new List<Button>() { buttonBotLeft, buttonMidCenter, buttonTopRight };
            List<Button> secondDiagonal = new List<Button>() { buttonBotRight, buttonMidCenter, buttonTopLeft };

            cbs.Text4Search = "";
            List<Button> firstDiagonalFreeButtons = firstDiagonal.FindAll(cbs.TextContainsString);
            List<Button> secondDiagonalFreeButtons = secondDiagonal.FindAll(cbs.TextContainsString);

            cbs.Text4Search = textForSearch;
            List<Button> firstDOccupiedBySomeoneButtons = firstDiagonal.FindAll(cbs.TextContainsString);
            List<Button> secondDOccupiedBySomeoneButtons = secondDiagonal.FindAll(cbs.TextContainsString);

            if (firstDiagonalFreeButtons.Count == 1 && firstDOccupiedBySomeoneButtons.Count == 2)
            {
                firstDiagonalFreeButtons[0].Text = "O";
                occupiedButtons.Add(firstDiagonalFreeButtons[0]);
                freeButtons.Remove(firstDiagonalFreeButtons[0]);
                return true;
            }
            else if (secondDiagonalFreeButtons.Count == 1 && secondDOccupiedBySomeoneButtons.Count == 2)
            {
                secondDiagonalFreeButtons[0].Text = "O";
                occupiedButtons.Add(secondDiagonalFreeButtons[0]);
                freeButtons.Remove(secondDiagonalFreeButtons[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ComputerFirstTurn(ComputerButtonSearch cbs, out bool turnComplete)
        {
            cbs.Text4Search = "O";
            int buttonWithO = occupiedButtons.FindIndex(cbs.TextContainsString);
            if (buttonWithO < 0)
            {
                Random computerChoice = new Random();
                int computerTurn = computerChoice.Next(0, freeButtons.Count);
                freeButtons[computerTurn].Text = "O";
                occupiedButtons.Add(freeButtons[computerTurn]);
                freeButtons.Remove(freeButtons[computerTurn]);
                turnComplete = true;
            }
            else
            {
                turnComplete = false;
            }
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
