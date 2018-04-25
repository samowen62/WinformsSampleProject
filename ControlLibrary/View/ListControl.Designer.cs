namespace ControlLibrary.View
{
    partial class ListControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddBtn = new System.Windows.Forms.Button();
            this.ListText = new System.Windows.Forms.Label();
            this.InputText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(207, 326);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(114, 39);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // ListText
            // 
            this.ListText.AutoSize = true;
            this.ListText.Location = new System.Drawing.Point(204, 160);
            this.ListText.Name = "ListText";
            this.ListText.Size = new System.Drawing.Size(49, 17);
            this.ListText.TabIndex = 1;
            this.ListText.Text = "";
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(207, 264);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(114, 22);
            this.InputText.TabIndex = 2;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.ListText);
            this.Controls.Add(this.AddBtn);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(528, 510);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label ListText;
        private System.Windows.Forms.TextBox InputText;
    }
}
