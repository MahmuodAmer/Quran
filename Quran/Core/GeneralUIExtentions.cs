using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quran.Core
{
    public static class GeneralUIExtentions
    {
        /// <summary>
        /// Append text to RichTextBox with Color
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;

            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
