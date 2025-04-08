namespace Drawing_App_v01.View
{
    partial class UserDataForm
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
            txtName = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtAddress = new TextBox();
            label5 = new Label();
            txtPostalCode = new TextBox();
            dtpDateOfBirth = new DateTimePicker();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(94, 6);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(94, 151);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(219, 151);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 5;
            label2.Text = "E-mail:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(94, 35);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 7;
            label3.Text = "Date of birth:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 9;
            label4.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(94, 93);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 23);
            txtAddress.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 125);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 11;
            label5.Text = "Postal code:";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(94, 122);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(200, 23);
            txtPostalCode.TabIndex = 10;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CustomFormat = "";
            dtpDateOfBirth.Location = new Point(94, 64);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(200, 23);
            dtpDateOfBirth.TabIndex = 12;
            dtpDateOfBirth.Value = new DateTime(2025, 3, 14, 7, 50, 41, 0);
            // 
            // UserDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 186);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(label5);
            Controls.Add(txtPostalCode);
            Controls.Add(label4);
            Controls.Add(txtAddress);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(txtName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UserDataForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserDataForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private Button btnSave;
        private Button btnCancel;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private Label label4;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtPostalCode;
        private DateTimePicker dtpDateOfBirth;
    }
}