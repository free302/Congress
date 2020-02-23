using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DrBAE.Congress.Common;
using DrBAE.Congress.Driver;

namespace DrBAE.Congress.Tester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        void log(object message)
        {
            var time = DateTime.Now.ToString("HH:mm:ss.fff");
            uiLog.AppendText($"[{time}] {message}\r\n");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var driver = new DriverLogic();

            log("--- 정당 목록 ----");
            var parties = driver.GetPartyData(true);
            Array.ForEach(parties, x => log(x));

            log("--- 투표 결과 ----");
            var votes = driver.GetVoteData(true);
            Array.ForEach(votes, x => log(x));
        }

    }
}
