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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // canvasPanel
            // 
            canvasPanel.BackColor = Color.White;
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;
            canvasPanel.Location = new Point(11, 36);
            canvasPanel.Margin = new Padding(3, 4, 3, 4);
            canvasPanel.Name = "canvasPanel";
            canvasPanel.Size = new Size(914, 643);
            canvasPanel.TabIndex = 0;
            canvasPanel.Paint += CanvasPanel_Paint;
            canvasPanel.MouseDown += CanvasPanel_MouseDown;
            canvasPanel.MouseMove += CanvasPanel_MouseMove;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(14, 688);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 33);
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
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(938, 30);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(46, 24);
            fileToolStripMenuItem1.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(141, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(141, 26);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(141, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // BtnLine
            // 
            BtnLine.Location = new Point(199, 688);
            BtnLine.Margin = new Padding(3, 4, 3, 4);
            BtnLine.Name = "BtnLine";
            BtnLine.Size = new Size(86, 33);
            BtnLine.TabIndex = 4;
            BtnLine.Text = "Line";
            BtnLine.UseVisualStyleBackColor = true;
            BtnLine.Click += BtnLine_Click;
            // 
            // BtnPoint
            // 
            BtnPoint.Location = new Point(106, 688);
            BtnPoint.Margin = new Padding(3, 4, 3, 4);
            BtnPoint.Name = "BtnPoint";
            BtnPoint.Size = new Size(86, 33);
            BtnPoint.TabIndex = 5;
            BtnPoint.Text = "Point";
            BtnPoint.UseVisualStyleBackColor = true;
            BtnPoint.Click += BtnPoint_Click;
            // 
            // BtnRectangle
            // 
            BtnRectangle.Location = new Point(291, 688);
            BtnRectangle.Margin = new Padding(3, 4, 3, 4);
            BtnRectangle.Name = "BtnRectangle";
            BtnRectangle.Size = new Size(86, 33);
            BtnRectangle.TabIndex = 6;
            BtnRectangle.Text = "Rectangle";
            BtnRectangle.UseVisualStyleBackColor = true;
            BtnRectangle.Click += BtnRectangle_Click;
            // 
            // BtnCircle
            // 
            BtnCircle.Location = new Point(384, 688);
            BtnCircle.Margin = new Padding(3, 4, 3, 4);
            BtnCircle.Name = "BtnCircle";
            BtnCircle.Size = new Size(86, 33);
            BtnCircle.TabIndex = 7;
            BtnCircle.Text = "Circle";
            BtnCircle.UseVisualStyleBackColor = true;
            BtnCircle.Click += BtnCircle_Click;
            // 
            // BtnRhombus
            // 
            BtnRhombus.Location = new Point(476, 688);
            BtnRhombus.Margin = new Padding(3, 4, 3, 4);
            BtnRhombus.Name = "BtnRhombus";
            BtnRhombus.Size = new Size(86, 33);
            BtnRhombus.TabIndex = 8;
            BtnRhombus.Text = "Rhombus";
            BtnRhombus.UseVisualStyleBackColor = true;
            BtnRhombus.Click += BtnRhombus_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 737);
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
            Margin = new Padding(3, 4, 3, 4);
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
    }
}
