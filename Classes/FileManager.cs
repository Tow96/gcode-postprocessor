using System;
using System.IO;

namespace gcode_postprocessor.Classes
{
    /// <summary>
    /// Contains the methods for the Read/Write of GCODE files
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Obtains the contents of a file
        /// </summary>
        /// <param name="Path">Path to the File</param>
        /// <returns>String containing the whole file</returns>
        public static string[] ReadGcode(string Path)
        {
            // Returns error if the given path is null or empty
            if (Path == null || Path.Trim() == "") { throw new IOException("No file selected"); }

            string output = null;
            try
            {
                using (var sr = new StreamReader(Path)){
                    output = sr.ReadToEnd();
                }
            }
            catch (IOException e) { throw e; }

            string[] lines = output.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
                );
            return lines;
        }

        /// <summary>
        /// Writes the given GCODE as a file
        /// </summary>
        /// <param name="Path">Path of the file</param>
        /// <param name="Payload">Array containing all the commands</param>
        public static void WriteGcode(string Path, string[] Payload)
        {
            // Returns error if the given path is null or empty
            if (Path == null || Path.Trim() == "") { throw new IOException("No file selected"); }

            try
            {
                StreamWriter writer = new StreamWriter(Path);
                
                foreach(string line in Payload)
                {
                    writer.WriteLine(line);  // writes the line
                }
                writer.Close();         // Closes the file
                writer.Dispose();       // Clears the writer from memory
                
            }
            catch (IOException e) { throw e; }

        }
    }
}
