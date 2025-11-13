using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

class Program
{
    [STAThread] // Required for using file dialogs
    static void Main()
    {
        OpenFileDialog openDialog = new OpenFileDialog
        {
            Title = "Select a text file to read",
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openDialog.FileName;
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            Console.WriteLine("\n--- File Contents (Table Format) ---\n");
            Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                "First", "Last", "Birth Date", "Phone", "Address", "City", "State", "Zip");
            Console.WriteLine(new string('-', 120));

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

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