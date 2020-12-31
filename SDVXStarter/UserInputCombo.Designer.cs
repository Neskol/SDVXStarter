
namespace SDVXStarter
{
    partial class UserInputCombo
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
            this.hintLabel = new System.Windows.Forms.Label();
            this.bConfirm = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.inputCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // hintLabel
            // 
            this.hintLabel.Location = new System.Drawing.Point(16, 18);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(343, 44);
            this.hintLabel.TabIndex = 0;
            this.hintLabel.Text = "Simple hint message goes here";
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(365, 9);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(95, 48);
            this.bConfirm.TabIndex = 2;
            this.bConfirm.Text = "&OK";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(365, 66);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(94, 45);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // inputCombo
            // 
            this.inputCombo.FormattingEnabled = true;
            this.inputCombo.Location = new System.Drawing.Point(19, 78);
            this.inputCombo.Name = "inputCombo";
            this.inputCombo.Size = new System.Drawing.Size(274, 23);
            this.inputCombo.TabIndex = 4;
            // 
            // UserInputCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 127);
            this.Controls.Add(this.inputCombo);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.hintLabel);
            this.Name = "UserInputCombo";
            this.Text = "SDVXStarter - User Input";
            this.Load += new System.EventHandler(this.UserInputCombo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ComboBox inputCombo;
    }
}