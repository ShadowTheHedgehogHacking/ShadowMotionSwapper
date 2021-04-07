
namespace ShadowMotionSwapper {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBoxTarget = new System.Windows.Forms.ListBox();
            this.listBoxDonor = new System.Windows.Forms.ListBox();
            this.buttonMap = new System.Windows.Forms.Button();
            this.checkBoxCopyProps = new System.Windows.Forms.CheckBox();
            this.buttonOpenTarget = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonOpenDonor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTarget
            // 
            this.listBoxTarget.FormattingEnabled = true;
            this.listBoxTarget.ItemHeight = 15;
            this.listBoxTarget.Location = new System.Drawing.Point(12, 33);
            this.listBoxTarget.Name = "listBoxTarget";
            this.listBoxTarget.Size = new System.Drawing.Size(223, 274);
            this.listBoxTarget.TabIndex = 0;
            // 
            // listBoxDonor
            // 
            this.listBoxDonor.FormattingEnabled = true;
            this.listBoxDonor.ItemHeight = 15;
            this.listBoxDonor.Location = new System.Drawing.Point(400, 33);
            this.listBoxDonor.Name = "listBoxDonor";
            this.listBoxDonor.Size = new System.Drawing.Size(237, 274);
            this.listBoxDonor.TabIndex = 1;
            // 
            // buttonMap
            // 
            this.buttonMap.Location = new System.Drawing.Point(270, 96);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(75, 23);
            this.buttonMap.TabIndex = 2;
            this.buttonMap.Text = "Map";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // checkBoxCopyProps
            // 
            this.checkBoxCopyProps.AutoSize = true;
            this.checkBoxCopyProps.Location = new System.Drawing.Point(270, 145);
            this.checkBoxCopyProps.Name = "checkBoxCopyProps";
            this.checkBoxCopyProps.Size = new System.Drawing.Size(87, 19);
            this.checkBoxCopyProps.TabIndex = 3;
            this.checkBoxCopyProps.Text = "Copy Props";
            this.checkBoxCopyProps.UseVisualStyleBackColor = true;
            // 
            // buttonOpenTarget
            // 
            this.buttonOpenTarget.Location = new System.Drawing.Point(63, 355);
            this.buttonOpenTarget.Name = "buttonOpenTarget";
            this.buttonOpenTarget.Size = new System.Drawing.Size(108, 24);
            this.buttonOpenTarget.TabIndex = 4;
            this.buttonOpenTarget.Text = "Open Target";
            this.buttonOpenTarget.UseVisualStyleBackColor = true;
            this.buttonOpenTarget.Click += new System.EventHandler(this.buttonOpenTarget_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(258, 355);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonOpenDonor
            // 
            this.buttonOpenDonor.Location = new System.Drawing.Point(419, 355);
            this.buttonOpenDonor.Name = "buttonOpenDonor";
            this.buttonOpenDonor.Size = new System.Drawing.Size(98, 23);
            this.buttonOpenDonor.TabIndex = 6;
            this.buttonOpenDonor.Text = "Open Donor";
            this.buttonOpenDonor.UseVisualStyleBackColor = true;
            this.buttonOpenDonor.Click += new System.EventHandler(this.buttonOpenDonor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 450);
            this.Controls.Add(this.buttonOpenDonor);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonOpenTarget);
            this.Controls.Add(this.checkBoxCopyProps);
            this.Controls.Add(this.buttonMap);
            this.Controls.Add(this.listBoxDonor);
            this.Controls.Add(this.listBoxTarget);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTarget;
        private System.Windows.Forms.ListBox listBoxDonor;
        private System.Windows.Forms.Button buttonMap;
        private System.Windows.Forms.CheckBox checkBoxCopyProps;
        private System.Windows.Forms.Button buttonOpenTarget;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonOpenDonor;
    }
}

