using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using gcode_postprocessor.Classes;

namespace gcode_postprocessor
{
    public partial class Form1 : Form
    {
        private List<Pause> Pauses { get; set; }

        /// <summary>
        /// Starts the App
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // MidLayer
            this.enableMidLayer(MidLayerCheck.Checked); // Sets the correct state of the midlayer mode

            // Pause
            this.resizePauseBox(PauseCheck.Checked); // Sets the window size depending if the Pause Mode is enabled or not
            this.updatePauseGridView(true);               // Starts the gridView
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

        #region MidLayer Functions

        /// <summary>
        ///  Sets the view when the MidLayer mode is enabled
        /// </summary>
        /// <param name="state"></param>
        private void enableMidLayer(Boolean state)
        {
            MidLayerText.Enabled = state;
        }
        
        /// <summary>
        /// Changes the "enable" value of the mid layer options
        /// </summary>
        private void MidLayerCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.enableMidLayer(MidLayerCheck.Checked);
        }

        #endregion

        #region Pause Functions

        /// <summary>
        /// When called changes the size of the window to fit the Pause Box
        /// </summary>
        /// <param name="state"></param>
        private void resizePauseBox(Boolean state)
        {
            if (state)
            {
                PauseGrid.Visible = true;
                AddPauseBttn.Enabled = true;
                AddPauseBttn.Visible = true;
                RunButton.Location = new System.Drawing.Point(344, 288);
                this.ClientSize = new System.Drawing.Size(431, 316);
            }
            else
            {
                PauseGrid.Visible = false;
                AddPauseBttn.Enabled = false;
                AddPauseBttn.Visible = false;
                RunButton.Location = new System.Drawing.Point(344, 105);
                this.ClientSize = new System.Drawing.Size(431, 135);
            }
        }

        /// <summary>
        /// Updates the control
        /// </summary>
        /// <param name="reset">If true, erases the view</param>
        private void updatePauseGridView(Boolean reset = false)
        {
            if (reset)
            {
                Pauses = new List<Pause>(); // Clears the List
            }

            if (Pauses.Count == 0)
            {
                Pauses.Add(new Pause());    // Adds a new Pause
            }
            PauseGrid.DataSource = null;
            PauseGrid.DataSource = Pauses; // Relinks the grid

            // Sets the names of the columns
            PauseGrid.Columns[0].HeaderText = "Layer";
            PauseGrid.Columns[1].HeaderText = "Pause at Start";
            PauseGrid.Columns[1].ToolTipText = "Setting to false will pause at the end of the layer";
            PauseGrid.Columns[2].HeaderText = "Change filament";

            // Sets the sizes of the columns to fit all the width
            PauseGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PauseGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            PauseGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        /// <summary>
        /// Shows the Pauses Box and resizes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.resizePauseBox(PauseCheck.Checked);
        }
        
        /// <summary>
        /// Adds a Pause Cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPauseBttn_Click(object sender, EventArgs e)
        {
            Pauses.Add(new Pause());
            updatePauseGridView();
        }

        /// <summary>
        /// Deletes all selected Rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePause_Click(object sender, EventArgs e)
        {
            // The array already goes from biggest index to lowest, so deletion is easy
            foreach (DataGridViewRow row in PauseGrid.SelectedRows)
            {
                Pauses.RemoveAt(row.Index);
            }

            this.updatePauseGridView();
        }

        /// <summary>
        /// Shows the context menu for a cell of the grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseGrid_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Dose nothing if it wasn't a right click
            if (e.Button != MouseButtons.Right) { return; }

            // If the select index is lesser than 0 does nothing
            if (e.RowIndex < 0) { return; }

            // Selects the row
            PauseGrid.Rows[e.RowIndex].Selected = true;

            // Makes the context menu
            ContextMenu m = new ContextMenu();
            m.MenuItems.Add(new MenuItem("Delete", deletePause_Click));

            m.Show(PauseGrid, new System.Drawing.Point(e.X, e.Y));

        }

        #endregion

        /// <summary>
        /// Starts the post-processing
        /// </summary>
        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                #region File Read
                string[] gcode = FileManager.ReadGcode(BrowseInput.Text);
                #endregion

                #region Post processing
                // Inject midLayer code
                if (MidLayerCheck.Checked)
                {
                    gcode = MidLayer.AddMidLayerCode(gcode, MidLayerText.Text);
                }
                // Add Pause in X layers
                if (PauseCheck.Checked)
                {
                    gcode = Pause.AddPauseCode(gcode, Pauses);
                }
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
