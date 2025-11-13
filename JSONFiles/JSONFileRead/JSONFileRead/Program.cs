using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

class Program
{
    [STAThread]
    static void Main()
    {
        OpenFileDialog openDialog = new OpenFileDialog
        {
            Title = "Select a text or JSON file to read",
            Filter = "Text Files (*.txt)|*.txt|JSON Files (*.json)|*.json|All Files (*.*)|*.*"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openDialog.FileName;
            string extension = Path.GetExtension(filePath).ToLower();

            Console.WriteLine("\n--- File Contents (Table Format) ---\n");
            Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                "First", "Last", "Birth Date", "Phone", "Address", "City", "State", "Zip");
            Console.WriteLine(new string('-', 120));

            if (extension == ".txt")
            {
                List<string> lines = new List<string>(File.ReadAllLines(filePath));
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
            else if (extension == ".json")
            {
                string json = File.ReadAllText(filePath);
                try
                {
                    List<Person> people = JsonSerializer.Deserialize<List<Person>>(json);
                    if (people != null)
                    {
                        foreach (var p in people)
                        {
                            Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                                p.FirstName, p.LastName, p.DateOfBirth, p.PhoneNumber,
                                p.Address?.Street, p.Address?.City, p.Address?.State, p.Address?.ZipCode);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading JSON file: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Unsupported file type.");
            }
        }
        else
        {
            Console.WriteLine("No file selected.");
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }

    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}