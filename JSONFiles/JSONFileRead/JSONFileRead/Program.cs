using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

class Program
{
    // Required for Windows Forms dialogs | STA = Single Threaded Apartment. Necessary for GUI components to execute
    [STAThread]
    static void Main()
    {
        // Creates a file dialog to allow user to select a JSON file to read w/ a JSON file filter
        OpenFileDialog openDialog = new OpenFileDialog
        {
            Title = "Select a JSON file to read",
            Filter = "JSON Files (*.json)|*.json"
        };

        // Starts the dialog and checks if the user selected a file path, else returns and quits the program.
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openDialog.FileName;

            // Formats the heading to display the data in a table format
            Console.WriteLine("\n--- JSON File Contents (Table Format) ---\n");
            Console.WriteLine("{0,-10} {1,-12} {2,-12} {3,-15} {4,-30} {5,-18} {6,-5} {7,-6}",
                "First", "Last", "Birth Date", "Phone", "Address", "City", "State", "Zip");
            Console.WriteLine(new string('-', 120));

            // Try catch statement to read and deserialize the JSON file contents
            try
            {
                string json = File.ReadAllText(filePath);
                List<Person> people = JsonSerializer.Deserialize<List<Person>>(json);

                // Checks if people is not null before attempting to display data
                if (people != null)
                {
                    // Loops through each person in the list and displays their data in a table format
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

    // Person and Address classes to structure the data
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