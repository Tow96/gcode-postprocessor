using System.IO;
using System.Text.RegularExpressions;

namespace gcode_postprocessor.Classes
{
    /// <summary>
    /// Contains the methods to add GCODE on every layer
    /// </summary>
    class MidLayer
    {
        /// <summary>
        /// Adds a given instruction every time it finds the line ;LAYER: X
        /// </summary>
        /// <param name="Gcode">Contents of a gcode splitted in lines</param>
        /// <param name="Instruction">Instruction to be added</param>
        /// <returns>Gcode divided in lines <returns>
        public static string[] AddMidLayerCode(string[] Gcode, string Instruction)
        {
            // Returns error if the given instruction is null or empty
            if (Instruction == null || Instruction.Trim() == "") throw new IOException("No instruction between layers given");

            // Defines the Regex pattern to identify a layer change
            Regex rx = new Regex(@";LAYER:[0-9]");

            for (int i = 0; i < Gcode.Length; i++)
            {
                // If a line change is found, adds the instruction
                if (rx.IsMatch(Gcode[i])) { Gcode[i] = $"{Gcode[i]}\n{Instruction}"; }
            }

            return Gcode;
        }
    }
}
