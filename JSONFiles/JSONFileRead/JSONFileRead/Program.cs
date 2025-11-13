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
            Title = "Select a JSON file to read",
            Filter = "JSON Files (*.json)|*.json"
        };

        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openDialog.FileName;

            Console.WriteLine("\n--- JSON File Contents (Table Format) ---\n");
            Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                "First", "Last", "Birth Date", "Phone", "Address", "City", "State", "Zip");
            Console.WriteLine(new string('-', 120));

            try
            {
                string json = File.ReadAllText(filePath);
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
                else
                {
                    Console.WriteLine("No data found in JSON file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading JSON file: " + ex.Message);
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