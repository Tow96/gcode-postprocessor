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
            this.PauseCheck = new System.Windows.Forms.CheckBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.PauseGrid = new System.Windows.Forms.DataGridView();
            this.AddPauseBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PauseGrid)).BeginInit();
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
            this.BrowseButton.Location = new System.Drawing.Point(344, 11);
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
            // PauseCheck
            // 
            this.PauseCheck.AutoSize = true;
            this.PauseCheck.Location = new System.Drawing.Point(12, 88);
            this.PauseCheck.Name = "PauseCheck";
            this.PauseCheck.Size = new System.Drawing.Size(144, 17);
            this.PauseCheck.TabIndex = 3;
            this.PauseCheck.Text = "Add pauses in the layers:";
            this.PauseCheck.UseVisualStyleBackColor = true;
            this.PauseCheck.CheckedChanged += new System.EventHandler(this.PauseCheck_CheckedChanged);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(344, 288);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Process";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // PauseGrid
            // 
            this.PauseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PauseGrid.Location = new System.Drawing.Point(12, 116);
            this.PauseGrid.Name = "PauseGrid";
            this.PauseGrid.Size = new System.Drawing.Size(407, 166);
            this.PauseGrid.TabIndex = 5;
            this.PauseGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PauseGrid_Click);
            // 
            // AddPauseBttn
            // 
            this.AddPauseBttn.Location = new System.Drawing.Point(169, 88);
            this.AddPauseBttn.Name = "AddPauseBttn";
            this.AddPauseBttn.Size = new System.Drawing.Size(75, 23);
            this.AddPauseBttn.TabIndex = 6;
            this.AddPauseBttn.Text = "Add Pause";
            this.AddPauseBttn.UseVisualStyleBackColor = true;
            this.AddPauseBttn.Click += new System.EventHandler(this.AddPauseBttn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 321);
            this.Controls.Add(this.AddPauseBttn);
            this.Controls.Add(this.PauseGrid);
            this.Controls.Add(this.PauseCheck);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.MidLayerCheck);
            this.Controls.Add(this.MidLayerText);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.BrowseInput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCODE post processor";
            ((System.ComponentModel.ISupportInitialize)(this.PauseGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox BrowseInput;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.CheckBox MidLayerCheck;
        private System.Windows.Forms.TextBox MidLayerText;
        private System.Windows.Forms.CheckBox PauseCheck;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.DataGridView PauseGrid;
        private System.Windows.Forms.Button AddPauseBttn;
    }
}

