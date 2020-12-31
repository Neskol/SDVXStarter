
namespace SDVXStarter
{
    partial class UserMassInput
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
            this.inputBox = new System.Windows.Forms.TextBox();
            this.bConfirm = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hintLabel
            // 
            this.hintLabel.AutoEllipsis = true;
            this.hintLabel.Location = new System.Drawing.Point(24, 24);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(293, 49);
            this.hintLabel.TabIndex = 0;
            this.hintLabel.Text = "Sample hint goes here";
            // 
            // inputBox
            // 
            this.inputBox.AllowDrop = true;
            this.inputBox.CausesValidation = false;
            this.inputBox.Location = new System.Drawing.Point(24, 89);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(317, 157);
            this.inputBox.TabIndex = 1;
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(360, 89);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(113, 70);
            this.bConfirm.TabIndex = 2;
            this.bConfirm.Text = "&OK";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(360, 176);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(113, 70);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "&Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // UserMassInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 273);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.hintLabel);
            this.Name = "UserMassInput";
            this.Text = "SDVX Starter - User Mass Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hintLabel;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.Button bCancel;
    }
}