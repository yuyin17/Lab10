namespace Lab10
{
    partial class Form1
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
            this.lstIncidents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstIncidents
            // 
            this.lstIncidents.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstIncidents.FormattingEnabled = true;
            this.lstIncidents.ItemHeight = 20;
            this.lstIncidents.Location = new System.Drawing.Point(28, 76);
            this.lstIncidents.Name = "lstIncidents";
            this.lstIncidents.Size = new System.Drawing.Size(760, 304);
            this.lstIncidents.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstIncidents);
            this.Name = "Form1";
            this.Text = "Incidents by Technician";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstIncidents;
    }
}

