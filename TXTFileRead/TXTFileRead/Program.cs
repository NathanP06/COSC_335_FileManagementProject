using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

class Program
{
    [STAThread] // Required for using file dialogs
    static void Main()
    {
        // Create and configure the OpenFileDialog
        OpenFileDialog openDialog = new OpenFileDialog
        {
            Title = "Select a text file to read",
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        };

        string filePath = string.Empty;

        // Show the file selection dialog
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            filePath = openDialog.FileName;

            // Create a list to store file contents
            List<string> lines = new List<string>();

            // Read all lines from the file
            foreach (string line in File.ReadAllLines(filePath))
            {
                lines.Add(line);
            }

            // Print out all the data
            Console.WriteLine("\n--- File Contents ---");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("No file selected.");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}