namespace Drawing_App_v01
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            canvasPanel = new Panel();
            btnClear = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            BtnLine = new Button();
            BtnPoint = new Button();
            BtnRectangle = new Button();
            BtnCircle = new Button();
            BtnRhombus = new Button();
            colorPanel = new Panel();
            CmbLineWidth = new ComboBox();
            CmbNodeSize = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // canvasPanel
            // 
            canvasPanel.BackColor = Color.White;
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;
            canvasPanel.Location = new Point(10, 27);
            canvasPanel.Name = "canvasPanel";
            canvasPanel.Size = new Size(800, 483);
            canvasPanel.TabIndex = 0;
            canvasPanel.Paint += CanvasPanel_Paint;
            canvasPanel.MouseDown += CanvasPanel_MouseDown;
            canvasPanel.MouseMove += CanvasPanel_MouseMove;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(12, 516);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 25);
            btnClear.TabIndex = 0;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(821, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(37, 20);
            fileToolStripMenuItem1.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(112, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(112, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(112, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // BtnLine
            // 
            BtnLine.Location = new Point(174, 516);
            BtnLine.Name = "BtnLine";
            BtnLine.Size = new Size(75, 25);
            BtnLine.TabIndex = 4;
            BtnLine.Text = "Line";
            BtnLine.UseVisualStyleBackColor = true;
            BtnLine.Click += BtnLine_Click;
            // 
            // BtnPoint
            // 
            BtnPoint.Location = new Point(93, 516);
            BtnPoint.Name = "BtnPoint";
            BtnPoint.Size = new Size(75, 25);
            BtnPoint.TabIndex = 5;
            BtnPoint.Text = "Point";
            BtnPoint.UseVisualStyleBackColor = true;
            BtnPoint.Click += BtnPoint_Click;
            // 
            // BtnRectangle
            // 
            BtnRectangle.Location = new Point(255, 516);
            BtnRectangle.Name = "BtnRectangle";
            BtnRectangle.Size = new Size(75, 25);
            BtnRectangle.TabIndex = 6;
            BtnRectangle.Text = "Rectangle";
            BtnRectangle.UseVisualStyleBackColor = true;
            BtnRectangle.Click += BtnRectangle_Click;
            // 
            // BtnCircle
            // 
            BtnCircle.Location = new Point(336, 516);
            BtnCircle.Name = "BtnCircle";
            BtnCircle.Size = new Size(75, 25);
            BtnCircle.TabIndex = 7;
            BtnCircle.Text = "Circle";
            BtnCircle.UseVisualStyleBackColor = true;
            BtnCircle.Click += BtnCircle_Click;
            // 
            // BtnRhombus
            // 
            BtnRhombus.Location = new Point(416, 516);
            BtnRhombus.Name = "BtnRhombus";
            BtnRhombus.Size = new Size(75, 25);
            BtnRhombus.TabIndex = 8;
            BtnRhombus.Text = "Rhombus";
            BtnRhombus.UseVisualStyleBackColor = true;
            BtnRhombus.Click += BtnRhombus_Click;
            // 
            // colorPanel
            // 
            colorPanel.BackColor = Color.Black;
            colorPanel.Location = new Point(565, 516);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(25, 25);
            colorPanel.TabIndex = 10;
            colorPanel.DoubleClick += ColorPanel_DoubleClick;
            // 
            // CmbLineWidth
            // 
            CmbLineWidth.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbLineWidth.FormattingEnabled = true;
            CmbLineWidth.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            CmbLineWidth.Location = new Point(612, 518);
            CmbLineWidth.Name = "CmbLineWidth";
            CmbLineWidth.Size = new Size(51, 23);
            CmbLineWidth.TabIndex = 11;
            CmbLineWidth.SelectedIndexChanged += CmbLineWidth_SelectedIndexChanged;
            // 
            // CmbNodeSize
            // 
            CmbNodeSize.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbNodeSize.FormattingEnabled = true;
            CmbNodeSize.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            CmbNodeSize.Location = new Point(678, 518);
            CmbNodeSize.Name = "CmbNodeSize";
            CmbNodeSize.Size = new Size(51, 23);
            CmbNodeSize.TabIndex = 12;
            CmbNodeSize.SelectedIndexChanged += CmbNodeSize_SelectedIndexChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 553);
            Controls.Add(CmbNodeSize);
            Controls.Add(CmbLineWidth);
            Controls.Add(colorPanel);
            Controls.Add(BtnRhombus);
            Controls.Add(BtnCircle);
            Controls.Add(BtnRectangle);
            Controls.Add(BtnPoint);
            Controls.Add(BtnLine);
            Controls.Add(menuStrip1);
            Controls.Add(btnClear);
            Controls.Add(canvasPanel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Drawing App";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel canvasPanel;
        private Button btnClear;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private Button BtnLine;
        private Button BtnPoint;
        private Button BtnRectangle;
        private Button BtnCircle;
        private Button BtnRhombus;
        private Panel colorPanel;
        private ComboBox CmbLineWidth;
        private ComboBox CmbNodeSize;
    }
}
