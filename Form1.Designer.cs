namespace gcode_postprocessor
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BrowseInput = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.MidLayerCheck = new System.Windows.Forms.CheckBox();
            this.MidLayerText = new System.Windows.Forms.TextBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrowseInput
            // 
            this.BrowseInput.Location = new System.Drawing.Point(12, 12);
            this.BrowseInput.Name = "BrowseInput";
            this.BrowseInput.Size = new System.Drawing.Size(325, 20);
            this.BrowseInput.TabIndex = 0;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(344, 10);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // MidLayerCheck
            // 
            this.MidLayerCheck.AutoSize = true;
            this.MidLayerCheck.Checked = true;
            this.MidLayerCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MidLayerCheck.Location = new System.Drawing.Point(12, 60);
            this.MidLayerCheck.Name = "MidLayerCheck";
            this.MidLayerCheck.Size = new System.Drawing.Size(154, 17);
            this.MidLayerCheck.TabIndex = 0;
            this.MidLayerCheck.Text = "Add Code between Layers:";
            this.MidLayerCheck.UseVisualStyleBackColor = true;
            this.MidLayerCheck.CheckedChanged += new System.EventHandler(this.MidLayerCheck_CheckedChanged);
            // 
            // MidLayerText
            // 
            this.MidLayerText.Location = new System.Drawing.Point(169, 58);
            this.MidLayerText.Name = "MidLayerText";
            this.MidLayerText.Size = new System.Drawing.Size(100, 20);
            this.MidLayerText.TabIndex = 1;
            this.MidLayerText.Text = "G4 P1";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(344, 76);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Process";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 111);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.MidLayerCheck);
            this.Controls.Add(this.MidLayerText);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.BrowseInput);
            this.Name = "Form1";
            this.Text = "GCODE post processor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox BrowseInput;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.CheckBox MidLayerCheck;
        private System.Windows.Forms.TextBox MidLayerText;
        private System.Windows.Forms.Button RunButton;
    }
}

