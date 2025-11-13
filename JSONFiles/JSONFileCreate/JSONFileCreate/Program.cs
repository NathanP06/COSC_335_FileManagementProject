using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        // Creates a file dialog to allow user to select where to save the generated text file
        SaveFileDialog saveDialog = new SaveFileDialog
        {
            Title = "Save your records file",
            Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
            FileName = "records.json"
        };

        // Creates a string to store the file path selected by the user
        string filePath = string.Empty;

        // Starts the dialog and checks if the user selected a file path
        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            filePath = saveDialog.FileName;
        }
        else
        {
            Console.WriteLine("No file selected. Exiting...");
            return;
        }
    }
}