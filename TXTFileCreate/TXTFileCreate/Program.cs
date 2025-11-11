using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

class Program
{
    // Required for Windows Forms dialogs | STA = Single Threaded Apartment. Necessary for GUI components to execute
    [STAThread]
    static void Main()
    {
        // Creates a file dialog to allow user to select where to save the generated text file
        SaveFileDialog saveDialog = new SaveFileDialog
        {
            Title = "Save your records file",
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            FileName = "records.txt"
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

        // Data creation lists and logic (Uses random for phone numbers & Dates, and lists of string for names/addresses)
        Random random = new Random();
        List<string> firstNames = new List<string> { "Garth", "Olin", "Andre", "Lori", "Karla", "Harriet", "Cecilia", "Becky", "Merle", "Sydney", "Esmeralda", "Riley", "Elroy", "Huey", "Whitney", "Pat", "Melissa", "Viola", "Callie", "Roxie", "Lesa", "Derick", "Numbers", "Earnest", "Van", "Guadalupe", "Julius", "Rosa", "Gay", "Dollie", "Ashlee", "Karen", "Burl", "Roger", "Abigail", "Ramona", "Patsy", "Carlos", "Nolan", "Krista", "Lee", "Alvaro", "Terra", "Ramon", "Lino", "Diana", "Kathrine", "Theron", "Dalton", "Myra" };
        List<string> lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };
        List<string> cities = new List<string> { "Homewood, AL, 35229", "Anchorage, AK, 99501", "Phoenix, AZ, 85003", "Little Rock, AR, 72201", "Los Angeles, CA, 90012", "Denver, CO, 80202", "Bridgeport, CT, 06604", "Wilmington, DE, 19801", "Tampa, FL, 33626", "Atlanta, GA, 30303", "Honolulu, HI, 96813", "Boise, ID, 83702", "Chicago, IL, 60601", "Indianapolis, IN, 46204", "Des Moines, IA, 50309", "Wichita, KS, 67202", "Louisville, KY, 40202", "New Orleans, LA, 70112", "Portland, ME, 04101", "Baltimore, MD, 21201", "Boston, MA, 02108", "Detroit, MI, 48226", "Minneapolis, MN, 55401", "Jackson, MS, 39201", "Kansas City, MO, 64106", "Billings, MT, 59101", "Omaha, NE, 68102", "Las Vegas, NV, 89101", "Manchester, NH, 03101", "Newark, NJ, 07102", "Albuquerque, NM, 87102", "New York City, NY, 10001", "Charlotte, NC, 28202", "Fargo, ND, 58102", "Columbus, OH, 43215", "Oklahoma City, OK, 73102", "Portland, OR, 97204", "Philadelphia, PA, 19103", "Providence, RI, 02903", "Charleston, SC, 29401", "Sioux Falls, SD, 57104", "Nashville, TN, 37201", "Houston, TX, 77002", "Salt Lake City, UT, 84111", "Burlington, VT, 05401", "Virginia Beach, VA, 23452", "Seattle, WA, 98101", "Charleston, WV, 25301", "Milwaukee, WI, 53202", "Cheyenne, WY, 82001" };
        List<string> streets = new List<string> { "Main St", "Oak Ave", "Elm St", "Maple Dr", "Pine Rd", "Cedar Ln", "Birch Way", "Ash St", "Willow Ave", "Spruce Dr" };

        // Creates and writes to the specified file path using StreamWriter
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Uses for loop to iterate 100 times to create 100 records
            for (int i = 0; i < 100; i++)
            {
                // Generates data for each field in the record
                string firstName = firstNames[random.Next(firstNames.Count)];
                string lastName = lastNames[random.Next(lastNames.Count)];
                string dob = GenerateRandomDate(random);
                string phone = GenerateRandomPhone(random);
                string street = $"{random.Next(100, 9999)} {streets[random.Next(streets.Count)]}";
                string city = cities[random.Next(cities.Count)];

                // Complies the record together, and writes it to the file as a single line separated by commas
                string record = $"{firstName}, {lastName}, {dob}, {phone}, {street}, {city}";
                writer.WriteLine(record);
            }
        }
        //Prints success message with file path
        Console.WriteLine($"File created successfully: {filePath}");
    }

    // Generates a random date of birth between 1950 and 2009
    static string GenerateRandomDate(Random random)
    {
        int year = random.Next(1950, 2010);
        int month = random.Next(1, 13);
        int day = random.Next(1, 29);
        return $"{month:D2}/{day:D2}/{year}";
    }
    
    // Generates a random phone number in the format XXX-XXX-XXXX
    static string GenerateRandomPhone(Random random)
    {
        return $"{random.Next(200, 999)}-{random.Next(200, 999)}-{random.Next(1000, 9999)}";
    }
}
