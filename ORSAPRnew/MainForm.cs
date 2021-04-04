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
        double length = Convert.ToDouble(LengthTextBox.Text);
        double width = Convert.ToDouble(WidthTextBox.Text);
        double height = Convert.ToDouble(HeightTextBox.Text);
        double lengthCompartment = Convert.ToDouble(LengthCompartmentTextBox.Text);
        int widthCompartment = Convert.ToInt32(LengthCompartmentTextBox.Text);

        try
        {
        var planeParameters = new PlaneParameters(length, width, height, lengthCompartment, widthCompartment);
        _builder.StartKompas();
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
