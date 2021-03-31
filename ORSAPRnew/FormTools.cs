using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ORSAPRnew
    internal class FormTools
    {
        #region Public methods

        /// <summary>
        ///     Метод проверки введёного в TextBox значени
        ///     на корректность для Convert.ToDouble
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckStringForDouble(string text)
        {
            if (text == null)
            {
                return true;
            }

            return Regex.IsMatch(text, @"^([0-9]*|[0-9]*[,][0-9]*)$");
        }

        /// <summary>
        ///     Проверка ввода корректного Double в TextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="e"></param>
        public static void TextBoxCheck(TextBox textBox, CancelEventArgs e)
        {
            if (textBox.Text != "")
            {
                e.Cancel = !CheckStringForDouble(textBox.Text);

                textBox.ForeColor = e.Cancel ? Color.Red : Color.Black;
            }
        }

        #endregion
    }
}