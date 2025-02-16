namespace Drawing_App_v01
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            btnCreate = new Button();
            btnLoad = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(103, 98);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(120, 23);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create new file";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(258, 98);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 23);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load existing file";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += BtnLoad_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(460, 48);
            label1.TabIndex = 2;
            label1.Text = "Welcome to the Drawing Application";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 161);
            Controls.Add(label1);
            Controls.Add(btnLoad);
            Controls.Add(btnCreate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Drawing App - Create or load file";
            Load += WelcomeForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreate;
        private Button btnLoad;
        private Label label1;
    }
}