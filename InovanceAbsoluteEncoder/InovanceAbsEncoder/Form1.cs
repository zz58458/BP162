using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InovanceAbsoluteEncoder;

namespace InovanceAbsEncoder
{
    public partial class Form1 : Form
    {
        InovanceAbsEncoderReader encoder = new InovanceAbsEncoderReader();
        public Form1()
        {
            InitializeComponent();
            //encoder.OpenSerialPort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = encoder.GetMotorAbsEncoderValue(1);
            int value2 = encoder.GetMotorAbsEncoderValue(2);


        }
    }
}
