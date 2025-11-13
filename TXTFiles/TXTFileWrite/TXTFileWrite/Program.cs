using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main()
    {
        // Prompt the user to select an existing text file
        OpenFileDialog openDialog = new OpenFileDialog
        {
            Title = "Select a text file to append records",
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        };

        string filePath = string.Empty;
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            filePath = openDialog.FileName;
        }
        else
        {
            Console.WriteLine("No file selected. Exiting...");
            return;
        }

        Random random = new Random();

        // Same data lists as before
        List<string> firstNames = new List<string> { "Amina", "Hiroshi", "Lucius", "Freya", "Kofi", "Isabella", "Ragnar", "Mei", "Elijah", "Zahra", "Dimitri", "Aria", "Nefertari", "Santiago", "Yara", "Bjorn", "Chidi", "Helena", "Rajesh", "Fiona", "Omar", "Beatrice", "Takumi", "Leif", "Salma", "Tobias", "Aroha", "Vladislav", "Eshe", "Matteo", "Ingrid", "Akio", "Zahid", "Eleanor", "Tenzin", "Joaquin", "Sappho", "Amir", "Greta", "Marcus", "Rania", "Hugo", "Aisha", "Cyrus", "Layla", "Solomon", "Amara", "Nikita", "Hilda", "Kaimana" };
        List<string> lastNames = new List<string> { "Nguyen", "Kowalski", "Ibrahim", "Müller", "Okafor", "Tanaka", "Patel", "Hernandez", "Dubois", "MacLeod", "Alvarez", "Khan", "Yamamoto", "Petrov", "Hassan", "Romano", "Singh", "Kim", "O’Connor", "Andersson", "da Silva", "Cohen", "Martinez", "Kuznetsov", "Haddad", "Schneider", "Adams", "Ivanova", "Lopez", "Chowdhury", "Moreau", "Fernandes", "Rahman", "Caruso", "Nakamura", "Volkov", "Hughes", "Garcia", "Sorenson", "Abebe", "Costa", "Levine", "Murphy", "Nowak", "Takahashi", "Rossi", "Mendoza", "Holloway", "Zhou", "Bekele" };
        List<string> cities = new List<string> { "Camden, AL, 36726", "Cold Bay, AK, 99571", "Supai, AZ, 86435", "Almyra, AR, 72003", "Petrolia, CA, 95558", "Bedrock, CO, 81411", "Voluntown, CT, 06384", "Woodside, DE, 19980", "Micanopy, FL, 32667", "Surrency, GA, 31563", "Hana, HI, 96713", "Dixie, ID, 83525", "Metropolis, IL, 62960", "Santa Claus, IN, 47579", "What Cheer, IA, 52593", "Elsmore, KS, 66732", "Mud Lick, KY, 42161", "Branch, LA, 70516", "Allagash, ME, 04735", "Aquasco, MD, 20608", "Shutesbury, MA, 01072", "Skanee, MI, 49962", "Brimson, MN, 55602", "Boyle, MS, 38730", "Sweet Springs, MO, 65351", "Hingham, MT, 59528", "Merna, NE, 68854", "Caliente, NV, 89008", "Center Sandwich, NH, 03227", "Chatsworth, NJ, 08019", "Santa Fe, NM, 87501", "Amenia, NY, 12501", "Cary, NC, 27513", "Nome, ND, 58062", "Bainbridge, OH, 45612", "Sweetwater, OK, 73666", "Spray, OR, 97874", "Blue Ball, PA, 17506", "Pascoag, RI, 02859", "Monetta, SC, 29105", "Piedmont, SD, 57769", "Lascassas, TN, 37085", "Cut and Shoot, TX, 77306", "Springdale, UT, 84767", "Lower Waterford, VT, 05848", "Dendron, VA, 23839", "Electric City, WA, 99123", "Hundred, WV, 26575", "Black Earth, WI, 53515", "Emblem, WY, 82422" };
        List<string> streets = new List<string> { "Zzyzx Rd", "Electric Ave", "This Way", "That Way", "Unbelievable Ln", "Chicken Bristle Rd", "Psycho Path", "Ego Alley", "Boring Rd", "Lick Skillet Rd", "Hash Knife Ranch Rd", "60 Yard Line", "Don't Look Back Ln", "Y St", "Featherbed Ln", "Gobbler Dr", "Divorce Ct", "Poor St", "Catfish Paradise", "Whippoorwill Ln", "No Name Rd", "Shady Rest Rd", "Headless Horseman Dr", "Lost Weekend Rd", "Pee Wee's Pl" };

        // Append 50 new records
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            for (int i = 0; i < 50; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Count)];
                string lastName = lastNames[random.Next(lastNames.Count)];
                string dob = GenerateRandomDate(random);
                string phone = GenerateRandomPhone(random);
                string street = $"{random.Next(100, 9999)} {streets[random.Next(streets.Count)]}";
                string city = cities[random.Next(cities.Count)];

                string record = $"{firstName}, {lastName}, {dob}, {phone}, {street}, {city}";
                writer.WriteLine(record);
            }
        }

        Console.WriteLine($"50 new records appended successfully to: {filePath}");
    }

    static string GenerateRandomDate(Random random)
    {
        int year = random.Next(1950, 2010);
        int month = random.Next(1, 13);
        int day = random.Next(1, 29);
        return $"{month:D2}/{day:D2}/{year}";
    }

    static string GenerateRandomPhone(Random random)
    {
        return $"{random.Next(200, 999)}-{random.Next(200, 999)}-{random.Next(1000, 9999)}";
    }
}