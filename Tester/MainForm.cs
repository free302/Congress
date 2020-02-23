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
        static bool _UseServer = false;

        public MainForm()
        {
            InitializeComponent();

            initGrid();
            initDt();
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
            var parties = driver.GetPartyData(_UseServer);
            Array.ForEach(parties, x => log(x));
            Array.ForEach(parties, x => _dt.Rows.Add(x.Id, x.Name, x.PropVoteRate, x.NumDistrictSeat));
            //_dt.Select()
            _dt.Rows.Add(0, "합계", 0m, 0m, 0m);

            log("--- 투표 결과 ----");
            var votes = driver.GetVoteData(_UseServer);
            Array.ForEach(votes, x => log(x));
        }

        #region ---- Grid ----

        void initGrid()
        {
            var g = uiGrid;

            for (int i = 0; i < colHeaders.Length; i++)
            {
                var j = g.Columns.Add(colHeaders[i], colHeaders[i]);
                var c = g.Columns[j];
                c.Width = colWidths[i];
                c.DataPropertyName = colHeaders[i];
                if (i == 1) continue;
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                c.DefaultCellStyle.Font = new Font("Consolas", g.Font.Size, FontStyle.Bold);
                c.DefaultCellStyle.Padding = new Padding() { Right = 5 };
            }
        }

        string[] colHeaders = new[] { "#", "정당", "득표율", "지역구", "비례의석" };
        int[] colWidths = new[] { 50, 150, 100, 100, 100 };
        Type[] colTypes = new[] { typeof(int), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal) };
        DataTable _dt;
        BindingSource _bs;
        void initDt()
        {
            _dt = new DataTable("Vote");
            _bs = new BindingSource();
            _bs.DataSource = _dt;
            uiGrid.DataSource = _bs;

            for (int i = 0; i < colHeaders.Length; i++)
            {
                var c = _dt.Columns.Add(colHeaders[i], colTypes[i]);
            }
        }
        void saveDt()
        {
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                var r = _dt.Rows[i];
                var v = new Party(r[0], r[1], r[2], r[3])
            }
        }

        #endregion
    }
}
