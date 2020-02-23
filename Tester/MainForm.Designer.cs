using System.Windows.Forms;
using System.Drawing;

namespace DrBAE.Congress.Tester
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Text = "MainForm";
            this.Font = new System.Drawing.Font("Consolas", 12F);

            Controls.Add(uiStatus = new StatusBar());

            Controls.Add(uiSplitMain = new SplitContainer());
            this.uiSplitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.uiSplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.uiSplitMain.SplitterDistance = 100;

            uiSplitMain.Panel2.Controls.Add(uiSplitContent = new SplitContainer());
            this.uiSplitContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.uiSplitContent.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.uiSplitContent.SplitterDistance = 400;

            uiSplitContent.Panel1.Controls.Add(uiLog = new RichTextBox());
            uiLog.Dock = DockStyle.Fill;

            uiSplitContent.Panel2.Controls.Add(uiGrid = new DataGridView());
            uiGrid.Dock = DockStyle.Fill;
            uiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uiGrid.ColumnHeadersVisible = true;
            uiGrid.RowHeadersVisible = false;
            uiGrid.RowTemplate.Height = 40;
            uiGrid.Font = new Font("Noto Sans CJK KR (TTF)", 12, FontStyle.Regular);
            uiGrid.AllowUserToAddRows = false;
        }

        RichTextBox uiLog;
        SplitContainer uiSplitMain;
        SplitContainer uiSplitContent;
        DataGridView uiGrid;
        StatusBar uiStatus;
        

        #endregion
    }
}