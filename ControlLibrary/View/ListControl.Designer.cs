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
            this.InputText = new System.Windows.Forms.TextBox();
            this.DisplayText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(34, 68);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(114, 39);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // InputText
            // 
            this.InputText.Location = new System.Drawing.Point(34, 16);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(114, 22);
            this.InputText.TabIndex = 2;
            // 
            // DisplayText
            // 
            this.DisplayText.Location = new System.Drawing.Point(223, 16);
            this.DisplayText.Multiline = true;
            this.DisplayText.Name = "DisplayText";
            this.DisplayText.ReadOnly = true;
            this.DisplayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DisplayText.Size = new System.Drawing.Size(192, 259);
            this.DisplayText.TabIndex = 3;
            // 
            // ListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DisplayText);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.AddBtn);
            this.Name = "ListControl";
            this.Size = new System.Drawing.Size(450, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.TextBox DisplayText;
    }
}
