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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            editUserDataToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Location = new Point(10, 446);
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
            menuStrip1.Size = new Size(834, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem, openToolStripMenuItem, editUserDataToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(37, 20);
            fileToolStripMenuItem1.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // BtnLine
            // 
            BtnLine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnLine.Location = new Point(174, 446);
            BtnLine.Name = "BtnLine";
            BtnLine.Size = new Size(75, 25);
            BtnLine.TabIndex = 4;
            BtnLine.Text = "Line";
            BtnLine.UseVisualStyleBackColor = true;
            BtnLine.Click += BtnLine_Click;
            // 
            // BtnPoint
            // 
            BtnPoint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnPoint.Location = new Point(93, 446);
            BtnPoint.Name = "BtnPoint";
            BtnPoint.Size = new Size(75, 25);
            BtnPoint.TabIndex = 5;
            BtnPoint.Text = "Point";
            BtnPoint.UseVisualStyleBackColor = true;
            BtnPoint.Click += BtnPoint_Click;
            // 
            // BtnRectangle
            // 
            BtnRectangle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnRectangle.Location = new Point(255, 446);
            BtnRectangle.Name = "BtnRectangle";
            BtnRectangle.Size = new Size(75, 25);
            BtnRectangle.TabIndex = 6;
            BtnRectangle.Text = "Rectangle";
            BtnRectangle.UseVisualStyleBackColor = true;
            BtnRectangle.Click += BtnRectangle_Click;
            // 
            // BtnCircle
            // 
            BtnCircle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnCircle.Location = new Point(336, 446);
            BtnCircle.Name = "BtnCircle";
            BtnCircle.Size = new Size(75, 25);
            BtnCircle.TabIndex = 7;
            BtnCircle.Text = "Circle";
            BtnCircle.UseVisualStyleBackColor = true;
            BtnCircle.Click += BtnCircle_Click;
            // 
            // BtnRhombus
            // 
            BtnRhombus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnRhombus.Location = new Point(416, 446);
            BtnRhombus.Name = "BtnRhombus";
            BtnRhombus.Size = new Size(75, 25);
            BtnRhombus.TabIndex = 8;
            BtnRhombus.Text = "Rhombus";
            BtnRhombus.UseVisualStyleBackColor = true;
            BtnRhombus.Click += BtnRhombus_Click;
            // 
            // colorPanel
            // 
            colorPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            colorPanel.BackColor = Color.Black;
            colorPanel.Location = new Point(542, 446);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(25, 25);
            colorPanel.TabIndex = 10;
            colorPanel.DoubleClick += ColorPanel_DoubleClick;
            // 
            // CmbLineWidth
            // 
            CmbLineWidth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CmbLineWidth.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbLineWidth.FormattingEnabled = true;
            CmbLineWidth.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            CmbLineWidth.Location = new Point(644, 448);
            CmbLineWidth.Name = "CmbLineWidth";
            CmbLineWidth.Size = new Size(51, 23);
            CmbLineWidth.TabIndex = 11;
            CmbLineWidth.SelectedIndexChanged += CmbLineWidth_SelectedIndexChanged;
            // 
            // CmbNodeSize
            // 
            CmbNodeSize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CmbNodeSize.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbNodeSize.FormattingEnabled = true;
            CmbNodeSize.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            CmbNodeSize.Location = new Point(772, 448);
            CmbNodeSize.Name = "CmbNodeSize";
            CmbNodeSize.Size = new Size(51, 23);
            CmbNodeSize.TabIndex = 12;
            CmbNodeSize.SelectedIndexChanged += CmbNodeSize_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(497, 451);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 13;
            label1.Text = "Color:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(573, 451);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 14;
            label2.Text = "Line width:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(701, 451);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 15;
            label3.Text = "Point size:";
            // 
            // editUserDataToolStripMenuItem
            // 
            editUserDataToolStripMenuItem.Name = "editUserDataToolStripMenuItem";
            editUserDataToolStripMenuItem.Size = new Size(180, 22);
            editUserDataToolStripMenuItem.Text = "Edit User Data";
            editUserDataToolStripMenuItem.Click += editUserDataToolStripMenuItem_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 481);
            Controls.Add(label3);
            Controls.Add(btnClear);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CmbNodeSize);
            Controls.Add(CmbLineWidth);
            Controls.Add(colorPanel);
            Controls.Add(BtnRhombus);
            Controls.Add(BtnCircle);
            Controls.Add(BtnRectangle);
            Controls.Add(BtnPoint);
            Controls.Add(BtnLine);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
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
        private Label label1;
        private Label label2;
        private Label label3;
        private ToolStripMenuItem editUserDataToolStripMenuItem;
    }
}
