using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Yaziji.LED;

namespace Yaziji
{
    public partial class FrmMain : Form
    {
        LEDHelper led;

        public FrmMain()
        {
            //实例化
            led = new LEDHelper();
            led.OnFindDevice += new LEDHelper.OnFindDeviceHandler(led_OnFindDevice);

            InitializeComponent();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确实要退出吗?", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        //查找设备
        private void toolFindDevices_Click(object sender, EventArgs e)
        {
            led.FindDevices();
            //List<LEDController> devices = 
            //if (devices.Count > 0)
            //{

            //}

        }

        void led_OnFindDevice(object sender, EventArgs e)
        {
            LEDHelper led = sender as LEDHelper;
            MessageBox.Show(led.Devices[led.Devices.Count - 1].IPAddress.ToString());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //发送测试
            //led.SendMessage("192.168.1.181");

            LEDSendPackage sp = new LEDSendPackage(LEDCommandType.Clear);
            sp.Content = "Test";
            led.SendMessage("192.168.1.181", sp);
        }
    }
}
