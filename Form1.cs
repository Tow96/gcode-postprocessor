using System;
using System.IO;
using System.Windows.Forms;
using gcode_postprocessor.Classes;

namespace gcode_postprocessor
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Starts the App
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the file dialog Box
        /// </summary>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Open Gcode",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "gcode",
                Filter = "gcode files (*.gcode)|*.gcode|All files|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                BrowseInput.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// Changes the "enable" value of the mid layer options
        /// </summary>
        private void MidLayerCheck_CheckedChanged(object sender, EventArgs e)
        {
            MidLayerText.Enabled = MidLayerCheck.Checked;
        }

        /// <summary>
        /// Starts the post-processing
        /// </summary>
        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                #region File 
                string[] gcode = FileManager.ReadGcode(BrowseInput.Text);
                #endregion

                #region Post processing
                // TODO: Inject midLayer code
                if (MidLayerCheck.Checked)
                {
                    gcode = MidLayer.AddMidLayerCode(gcode, MidLayerText.Text);
                }
                // TODO: Add Pause in X layers
                // TODO: Add file merge
                #endregion

                #region File write
                // Opens the save file dialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Title = "Save Gcode";
                saveDialog.DefaultExt = "gcode";
                saveDialog.Filter = "gcode files (*.gcode)|*.gcode";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Saves file
                    FileManager.WriteGcode(saveDialog.FileName, gcode);

                    // Sends success message
                    MessageBox.Show("File created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                #endregion
            }
            catch(IOException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
