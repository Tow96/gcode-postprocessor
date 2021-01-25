using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace gcode_postprocessor.Classes
{
    /// <summary>
    /// Contains the methods and logic to create pauses 
    /// </summary>
    public class Pause
    {

        public static string[] AddPauseCode(string[] Gcode, List<Pause> pPauses)
        {
            // Creates a new list so it's independent from the visual one
            List<Pause> pauses = new List<Pause>(pPauses);

            // Changes all pauses at the end of a layer into Pauses at the begining of the next Layer
            for(int i = 0; i < pauses.Count; i++)
            {
                if (!pauses[i].AtBegining)
                {
                    pauses[i].AtBegining = true;
                    pauses[i].Layer = pauses[i].Layer + 1;
                }
            }

            // Removes Duplicates from List
            List<Pause> uniqueList = pauses.Distinct().ToList();

            // Sorts the list by layer
            uniqueList.Sort((x, y) => x.Layer.CompareTo(y.Layer));

            // Iterator variable, it changes every loop to reduce processing time
            int i_initial = 0;
            
            /// Runs code for every Pause
            foreach(Pause p in uniqueList)
            {
                // Defines the Regex for the layer that will be searched
                Regex rx = new Regex(@";LAYER:"+p.Layer+@"$");

                // Checks all the code to find the correct layer
                for(int i = i_initial; i < Gcode.Length; i++)
                {
                    // If the layer is found, stores the iteration so the next one
                    // starts from this position as all the pauses are sorted
                    if (rx.IsMatch(Gcode[i]))
                    {
                        // Adds a Change filament routine
                        if (p.ChangeFilament) { Gcode[i] = $"{Gcode[i]}\nM600"; }
                        // If the command is just pause, adds the following
                        else 
                        { 
                            // Stores the current position
                            Gcode[i] = $"{Gcode[i]}\nG60 S0";
                            // Parks the nozzle
                            Gcode[i] = $"{Gcode[i]}\nG27 P2";
                            // Pauses the print
                            Gcode[i] = $"{Gcode[i]}\nM0"; 
                            // Restores the Z position
                            Gcode[i] = $"{Gcode[i]}\nG61 X Y Z S0";
                        }

                        // stores the current i-1 as the new start for the next pause
                        i_initial = i - 1;

                        // stops the for loop
                        break;
                    }
                }
                
            }

            // re-joins the gcode and then splits it again in order to have the added instruction separate from the LAYER
            string joinedGcode = string.Join("\n", Gcode);
            Gcode = joinedGcode.Split(
                new[] { "\r\n", "\r", "\n" },
                System.StringSplitOptions.None
                );

            return Gcode;
        }

        #region overrides
        public override bool Equals(object obj)
        {
            Pause other = (Pause)obj;
            if (this.Layer != other.Layer) { return false; }
            
            if (this.AtBegining != other.AtBegining) { return false; }

            if(this.ChangeFilament != other.ChangeFilament) { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Layer.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Layer}, {AtBegining}, {ChangeFilament}";
        }

        #endregion

        #region Properties
        private int _layer;
        private Boolean _atBegining;
        private Boolean _changeFilament;
        #endregion

        /// <summary>
        /// Generates a Pause Element
        /// </summary>
        public Pause()
        {
            this._layer = 0;
            this._atBegining = true;
            this._changeFilament = false;
        }

        #region Parameter encapsulators
        public int Layer { get { return this._layer; } set { _layer = value; } }
        public Boolean AtBegining { get { return this._atBegining; } set { _atBegining = value; } }
        public Boolean ChangeFilament { get { return this._changeFilament; } set { _changeFilament = value; } }
        #endregion
    }
}
