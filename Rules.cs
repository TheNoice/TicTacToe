using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class Rules
    {
        public string Turn { get; set; }

        public string CheckWinCondition(List<Button> occupiedButtons, List<Button> freeButtons)
        {
            bool humanWin = CheckExecute(occupiedButtons, "X");
            if (humanWin)
            {
                return "human";
            }
            else
            {
                bool computerWin = CheckExecute(occupiedButtons, "O");
                if (computerWin)
                {
                    return "computer";
                }
            }
            if (!freeButtons.Any())
            {
                return "draw";
            }
            return "continue";
        }

        private bool CheckExecute(List<Button> occupiedButtons, string textForSearch)
        {
            ComputerButtonSearch cbs = new ComputerButtonSearch();
            cbs.Text4Search = textForSearch; //X - human, O - computer
            List<Button> buttonsOccupiedBySomeone = occupiedButtons.FindAll(cbs.TextContainsString);
            if (buttonsOccupiedBySomeone.Count < 3)
            {
                return false;
            }
            else
            {
                cbs.Name4Search = "Bot";
                List<Button> botButtonsOccupied = buttonsOccupiedBySomeone.FindAll(cbs.NameContainsString);
                if (botButtonsOccupied.Count == 3)
                {
                    return true;
                }
                else
                {
                    cbs.Name4Search = "Mid";
                    List<Button> midButtonsOccupied = buttonsOccupiedBySomeone.FindAll(cbs.NameContainsString);
                    if (midButtonsOccupied.Count == 3)
                    {
                        return true;
                    }
                    else
                    {
                        cbs.Name4Search = "Top";
                        List<Button> topButtonsOccupied = buttonsOccupiedBySomeone.FindAll(cbs.NameContainsString);
                        if (topButtonsOccupied.Count == 3)
                        {
                            return true;
                        }
                        else
                        {
                            cbs.Name4Search = "Left";
                            List<Button> leftButtonsOccupied = buttonsOccupiedBySomeone.FindAll(cbs.NameContainsString);
                            if (leftButtonsOccupied.Count == 3)
                            {
                                return true;
                            }
                            else
                            {
                                cbs.Name4Search = "Center";
                                List<Button> centerButtonsOccupied = buttonsOccupiedBySomeone.FindAll(cbs.NameContainsString);
                                if (centerButtonsOccupied.Count == 3)
                                {
                                    return true;
                                }
                                else
                                {
                                    cbs.Name4Search = "Right";
                                    List<Button> rightButtonsOccupied = buttonsOccupiedBySomeone.FindAll(cbs.NameContainsString);
                                    if (rightButtonsOccupied.Count == 3)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        cbs.Text4Search = textForSearch;
                                        bool botLeftTaken = false;
                                        bool midCenterTaken = false;
                                        bool topRightTaken = false;

                                        bool botRightTaken = false;
                                        bool topLeftTaken = false;

                                        for (int i = 0; i < buttonsOccupiedBySomeone.Count; i++)
                                        {
                                            if (buttonsOccupiedBySomeone[i].Name.Contains("BotLeft"))
                                            {
                                                botLeftTaken = true;
                                            }
                                            if (buttonsOccupiedBySomeone[i].Name.Contains("MidCenter"))
                                            {
                                                midCenterTaken = true;
                                            }
                                            if (buttonsOccupiedBySomeone[i].Name.Contains("TopRight"))
                                            {
                                                topRightTaken = true;
                                            }

                                            if (buttonsOccupiedBySomeone[i].Name.Contains("BotRight"))
                                            {
                                                botRightTaken = true;
                                            }
                                            if (buttonsOccupiedBySomeone[i].Name.Contains("TopLeft"))
                                            {
                                                topLeftTaken = true;
                                            }
                                        }

                                        if ((botLeftTaken == true && midCenterTaken == true && topRightTaken == true) || (botRightTaken == true && midCenterTaken == true && topLeftTaken == true))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
