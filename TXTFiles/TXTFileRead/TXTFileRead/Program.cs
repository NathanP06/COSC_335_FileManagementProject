using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

class Program
{
    // Required for Windows Forms dialogs | STA = Single Threaded Apartment. Necessary for GUI components to execute
    [STAThread]
    static void Main()
    {
        // Creates a file dialog to allow user to select an existing text file to read
        OpenFileDialog openDialog = new OpenFileDialog
        {
            Title = "Select a text file to read",
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        };

        // Starts the dialog and checks if the user selected a file path
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openDialog.FileName;

            // Reads all lines from the selected file into a list of strings
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            // Table Formatting: Heading
            Console.WriteLine("\n--- File Contents (Table Format) ---\n");
            Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                "First", "Last", "Birth Date", "Phone", "Address", "City", "State", "Zip");
            Console.WriteLine(new string('-', 120));

            // Loops through list "lines", splits each line into parts, and prints them in a formatted table
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                // Formats and prints each part of the record in aligned columns
                if (parts.Length >= 8)
                {
                    Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                        parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), parts[3].Trim(),
                        parts[4].Trim(), parts[5].Trim(), parts[6].Trim(), parts[7].Trim());
                }
            }
        }
        else
        {
            Console.WriteLine("No file selected.");
        }
    }
}