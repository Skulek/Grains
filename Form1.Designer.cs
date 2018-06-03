namespace Grains
{
    partial class Form1
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
            this.btnInit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Sasiedztwo = new System.Windows.Forms.ComboBox();
            this.paintArea = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.PanelThread = new System.Windows.Forms.Panel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnStopDraw = new System.Windows.Forms.Button();
            this.LabelAction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHeight = new Grains.NumberBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdoAbsorb = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoEven = new System.Windows.Forms.RadioButton();
            this.rdoRandom = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLayerGerne = new Grains.NumberBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLayerHeight = new Grains.NumberBox();
            this.TbWidth = new Grains.NumberBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paintArea)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.PanelThread.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(96, 65);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(93, 26);
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "Inicjuj";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Typ sąsiedztwa";
            // 
            // Sasiedztwo
            // 
            this.Sasiedztwo.FormattingEnabled = true;
            this.Sasiedztwo.Items.AddRange(new object[] {
            "Moore",
            "VonNeumann",
            "HeksagonalneLewe",
            "HeksagonalnePrawe"});
            this.Sasiedztwo.Location = new System.Drawing.Point(38, 249);
            this.Sasiedztwo.Name = "Sasiedztwo";
            this.Sasiedztwo.Size = new System.Drawing.Size(138, 21);
            this.Sasiedztwo.TabIndex = 9;
            // 
            // paintArea
            // 
            this.paintArea.BackColor = System.Drawing.Color.Black;
            this.paintArea.Location = new System.Drawing.Point(471, 35);
            this.paintArea.Name = "paintArea";
            this.paintArea.Size = new System.Drawing.Size(100, 50);
            this.paintArea.TabIndex = 22;
            this.paintArea.TabStop = false;
            this.paintArea.Visible = false;
            this.paintArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.paintArea_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(95, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 27);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Zapisz do pliku";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 543);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 26);
            this.btnClear.TabIndex = 98;
            this.btnClear.Text = "Wyczyść";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.PanelThread);
            this.groupBox1.Controls.Add(this.LabelAction);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbHeight);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.TbWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 596);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(70, 524);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 102;
            // 
            // PanelThread
            // 
            this.PanelThread.Controls.Add(this.btnDraw);
            this.PanelThread.Controls.Add(this.btnStopDraw);
            this.PanelThread.Location = new System.Drawing.Point(74, 97);
            this.PanelThread.Name = "PanelThread";
            this.PanelThread.Size = new System.Drawing.Size(129, 75);
            this.PanelThread.TabIndex = 101;
            // 
            // btnDraw
            // 
            this.btnDraw.Enabled = false;
            this.btnDraw.Location = new System.Drawing.Point(22, 3);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(93, 26);
            this.btnDraw.TabIndex = 35;
            this.btnDraw.Text = "Rysuj";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw2_Click);
            // 
            // btnStopDraw
            // 
            this.btnStopDraw.Enabled = false;
            this.btnStopDraw.Location = new System.Drawing.Point(22, 32);
            this.btnStopDraw.Name = "btnStopDraw";
            this.btnStopDraw.Size = new System.Drawing.Size(93, 37);
            this.btnStopDraw.TabIndex = 32;
            this.btnStopDraw.Text = "Zatrzymaj rysowanie";
            this.btnStopDraw.UseVisualStyleBackColor = true;
            this.btnStopDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // LabelAction
            // 
            this.LabelAction.AutoSize = true;
            this.LabelAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAction.Location = new System.Drawing.Point(18, 522);
            this.LabelAction.Name = "LabelAction";
            this.LabelAction.Size = new System.Drawing.Size(0, 24);
            this.LabelAction.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Wysokosc";
            // 
            // tbHeight
            // 
            this.tbHeight.AllowSpace = false;
            this.tbHeight.Location = new System.Drawing.Point(152, 39);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(36, 20);
            this.tbHeight.TabIndex = 3;
            this.tbHeight.Text = "600";
            this.tbHeight.TextChanged += new System.EventHandler(this.CheckTextBoxesWidthHeight);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbLayerGerne);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbLayerHeight);
            this.groupBox2.Controls.Add(this.Sasiedztwo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 313);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dodaj nową  warstwę";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.rdoAbsorb);
            this.groupBox4.Location = new System.Drawing.Point(38, 157);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 71);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Warunki brzegowe";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(48, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "periodyczne";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rdoAbsorb
            // 
            this.rdoAbsorb.AutoSize = true;
            this.rdoAbsorb.Checked = true;
            this.rdoAbsorb.Location = new System.Drawing.Point(47, 19);
            this.rdoAbsorb.Name = "rdoAbsorb";
            this.rdoAbsorb.Size = new System.Drawing.Size(83, 17);
            this.rdoAbsorb.TabIndex = 0;
            this.rdoAbsorb.TabStop = true;
            this.rdoAbsorb.Text = "absorbujące";
            this.rdoAbsorb.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoEven);
            this.groupBox3.Controls.Add(this.rdoRandom);
            this.groupBox3.Location = new System.Drawing.Point(61, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 65);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rozmieszczenie";
            // 
            // rdoEven
            // 
            this.rdoEven.AutoSize = true;
            this.rdoEven.Location = new System.Drawing.Point(27, 42);
            this.rdoEven.Name = "rdoEven";
            this.rdoEven.Size = new System.Drawing.Size(87, 17);
            this.rdoEven.TabIndex = 8;
            this.rdoEven.Text = "równomiernie";
            this.rdoEven.UseVisualStyleBackColor = true;
            // 
            // rdoRandom
            // 
            this.rdoRandom.AutoSize = true;
            this.rdoRandom.Checked = true;
            this.rdoRandom.Location = new System.Drawing.Point(56, 19);
            this.rdoRandom.Name = "rdoRandom";
            this.rdoRandom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdoRandom.Size = new System.Drawing.Size(58, 17);
            this.rdoRandom.TabIndex = 7;
            this.rdoRandom.TabStop = true;
            this.rdoRandom.Text = "losowo";
            this.rdoRandom.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Ilosc ziaren ";
            // 
            // tbLayerGerne
            // 
            this.tbLayerGerne.AllowSpace = false;
            this.tbLayerGerne.Location = new System.Drawing.Point(140, 41);
            this.tbLayerGerne.Name = "tbLayerGerne";
            this.tbLayerGerne.Size = new System.Drawing.Size(36, 20);
            this.tbLayerGerne.TabIndex = 6;
            this.tbLayerGerne.Text = "5";
            this.tbLayerGerne.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInsert
            // 
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(105, 276);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(71, 31);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Dodaj";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Wysokość";
            // 
            // tbLayerHeight
            // 
            this.tbLayerHeight.AllowSpace = false;
            this.tbLayerHeight.Location = new System.Drawing.Point(139, 15);
            this.tbLayerHeight.Name = "tbLayerHeight";
            this.tbLayerHeight.Size = new System.Drawing.Size(36, 20);
            this.tbLayerHeight.TabIndex = 5;
            this.tbLayerHeight.Text = "200";
            this.tbLayerHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TbWidth
            // 
            this.TbWidth.AllowSpace = false;
            this.TbWidth.Location = new System.Drawing.Point(152, 13);
            this.TbWidth.Name = "TbWidth";
            this.TbWidth.Size = new System.Drawing.Size(36, 20);
            this.TbWidth.TabIndex = 2;
            this.TbWidth.Text = "800";
            this.TbWidth.TextChanged += new System.EventHandler(this.CheckTextBoxesWidthHeight);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Szerokość ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.paintArea);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.paintArea)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelThread.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Sasiedztwo;
        private System.Windows.Forms.PictureBox paintArea;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStopDraw;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoRandom;
        private System.Windows.Forms.RadioButton rdoEven;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label LabelAction;
        
        private NumberBox TbWidth;
        private NumberBox tbLayerHeight;
        private NumberBox tbLayerGerne;
        private NumberBox tbHeight;
        private System.Windows.Forms.Panel PanelThread;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rdoAbsorb;
    }
}

