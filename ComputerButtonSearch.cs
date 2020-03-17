using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class ComputerButtonSearch
    {
        public string Name4Search { get; set; }
        public string Text4Search { get; set; }

        public bool NameContainsString(Button button)
        {
            return button.Name.Contains(Name4Search);
        }
        public bool TextContainsString(Button button)
        {
            if (Text4Search == "")
            {
                return button.Text == string.Empty;
            }
            else
            {
                return button.Text.Contains(Text4Search);
            }
        }
    }
}
