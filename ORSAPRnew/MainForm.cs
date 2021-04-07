using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Box.KompasWrapper;
using Box.Model;
using static ORSAPRnew.FormTools;



namespace ORSAPRnew
{
    public partial class MainForm : Form
    {
        #region Readonly fields

        private readonly Builder _builder = new Builder();

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///     Обработчик события нажатия на кнопку построить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     

        private void BuildButton_Click(object sender, EventArgs e)
        {
            double length = 0;
            double width = 0;
            double height = 0;
            double lengthCompartment = 0;
            int widthCompartment = 0;

            try
            {
                length = Convert.ToDouble(LengthTextBox.Text);
                width = Convert.ToDouble(WidthTextBox.Text);
                height = Convert.ToDouble(HeightTextBox.Text);
                lengthCompartment = Convert.ToDouble(LengthCompartmentTextBox.Text);
                widthCompartment = Convert.ToInt32(WidthCompartmentTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Значения введены некорректно. Поля должны содержать только цифры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var planeParameters = new PlaneParameters(length, width, height, lengthCompartment, widthCompartment);
                _builder.StartKompas();
                _builder.Box = planeParameters;
                _builder.BuildBox();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LengthCompartmentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WidthCompartmentTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
