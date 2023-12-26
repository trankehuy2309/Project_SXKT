
namespace ClientApp
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
            this.dataGridViewTick = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.session = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeedit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtlotnum = new System.Windows.Forms.NumericUpDown();
            this.btnput = new System.Windows.Forms.Button();
            this.cbsession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_reloaddata = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbinf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlotnum)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTick
            // 
            this.dataGridViewTick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTick.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.session,
            this.date,
            this.lotnum,
            this.result,
            this.timeedit});
            this.dataGridViewTick.Location = new System.Drawing.Point(376, 52);
            this.dataGridViewTick.Name = "dataGridViewTick";
            this.dataGridViewTick.Size = new System.Drawing.Size(644, 386);
            this.dataGridViewTick.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // session
            // 
            this.session.HeaderText = "Phiên";
            this.session.Name = "session";
            this.session.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Ngày";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // lotnum
            // 
            this.lotnum.HeaderText = "Số đặt";
            this.lotnum.Name = "lotnum";
            this.lotnum.ReadOnly = true;
            // 
            // result
            // 
            this.result.HeaderText = "Kết quả";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            // 
            // timeedit
            // 
            this.timeedit.HeaderText = "TG đặt";
            this.timeedit.Name = "timeedit";
            this.timeedit.ReadOnly = true;
            // 
            // txtlotnum
            // 
            this.txtlotnum.Location = new System.Drawing.Point(111, 78);
            this.txtlotnum.Name = "txtlotnum";
            this.txtlotnum.Size = new System.Drawing.Size(120, 20);
            this.txtlotnum.TabIndex = 1;
            // 
            // btnput
            // 
            this.btnput.Location = new System.Drawing.Point(101, 174);
            this.btnput.Name = "btnput";
            this.btnput.Size = new System.Drawing.Size(75, 23);
            this.btnput.TabIndex = 2;
            this.btnput.Text = "Đặt";
            this.btnput.UseVisualStyleBackColor = true;
            this.btnput.Click += new System.EventHandler(this.btnput_Click);
            // 
            // cbsession
            // 
            this.cbsession.FormattingEnabled = true;
            this.cbsession.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbsession.Location = new System.Drawing.Point(111, 131);
            this.cbsession.Name = "cbsession";
            this.cbsession.Size = new System.Drawing.Size(121, 21);
            this.cbsession.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số đặt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phiên:";
            // 
            // timer_reloaddata
            // 
            this.timer_reloaddata.Enabled = true;
            this.timer_reloaddata.Interval = 120000;
            this.timer_reloaddata.Tick += new System.EventHandler(this.timer_reloaddata_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(83, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "ĐẶT SỐ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(580, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "LỊCH SỬ ĐẶT SỐ";
            // 
            // lbinf
            // 
            this.lbinf.AutoSize = true;
            this.lbinf.Location = new System.Drawing.Point(13, 424);
            this.lbinf.Name = "lbinf";
            this.lbinf.Size = new System.Drawing.Size(35, 13);
            this.lbinf.TabIndex = 6;
            this.lbinf.Text = "label5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 450);
            this.Controls.Add(this.lbinf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbsession);
            this.Controls.Add(this.btnput);
            this.Controls.Add(this.txtlotnum);
            this.Controls.Add(this.dataGridViewTick);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlotnum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTick;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn session;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeedit;
        private System.Windows.Forms.NumericUpDown txtlotnum;
        private System.Windows.Forms.Button btnput;
        private System.Windows.Forms.ComboBox cbsession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_reloaddata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbinf;
    }
}