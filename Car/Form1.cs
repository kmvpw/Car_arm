using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace Car
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circularGauge1.Needles[0].Value += 3;
          
           // MessageBox.Show(gaugeControl1.Gauges[0].Name.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SerialPort mySerialPort = new SerialPort();
            mySerialPort.PortName = "COM3";
            mySerialPort.BaudRate = 115200;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
           // mySerialPort.DataReceived += new SerialDataReceivedEventHandler(mySerialPort_DataReceived);
            mySerialPort.RtsEnable = false;
            mySerialPort.DtrEnable = false;
            mySerialPort.DataReceived += mySerialPort_DataReceived;
            mySerialPort.ReadTimeout = 10000;
            mySerialPort.Open();
        }

        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string s = sp.ReadLine();
            string karen = (s.Split(',')[2]).Remove(0, 2).Replace("\r", "").Replace("=","");
            string armen = (s.Split(',')[0]).Remove(0, 2).Replace("\r", "").Replace("=", "");
            string vartan = (s.Split(',')[1]).Remove(0, 2).Replace("\r", "").Replace("=", "").Replace(".",",");
            circularGauge1.Needles[0].Value = float.Parse(karen);
            circularGauge2.Needles[0].Value = float.Parse(armen);
            circularGauge3.Needles[0].Value = float.Parse(vartan);
            Debug.Print(s);
        }
    }
}
