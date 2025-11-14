# COSC_335_FileManagementProject

File Management Project using C#

This is a small, educational console project that demonstrates several core file management concepts in C#:

- Creating files
- Writing to files
- Reading from files

Repository layout (important files)
---------------------------------
`COSC_335_FilemanagementProject` — Root file folder
- `JSONFileCreate` — .json file creation project folder
- `JSONFileRead` — .json file reading project folder
- `JSONFileWrite` — .json file appending/writing project folder
- `TXTFileCreate` — .txt file creation project folder
- `TXTFileRead` — .txt file reading project folder
- `TXTFileWrite` — .txt file appending/writing project folder

What the program does
---------------------
Each program does an individual seperate task:
### JSON Files
- `JSONFileCreate` — Creates a .JSON file that contains 100 randomly generated people records (including names, addresses, DOBs & phone numbers) and saves it to a designated location determined by the user during program execution.
- `JSONFileRead` — Deserializes a .JSON file, determinted by the user during program execution, to a list and then prints the data in the style of a table using the .Split(", ") function to seperate each part.
- `JSONFileWrite` — Appends 50 new randomly generated people records (including names, addresses, DOBs & phone numbers) to a .JSON file selected by the user during program execution

### TXT Files
- `TXTFileCreate` — Creates a .txt file that contains 100 randomly generated people records (including names, addresses, DOBs & phone numbers) and saves it to a designated location determined by the user during program execution.
- `TXTFileRead` — Reads a .txt file, determinted by the user during program execution to a list, using each line-break to seperate individual people records, and prints the data in table format using the .Split(", ") function to seperate each part
- `TXTFileWrite` — Appends 50 new randomly generated people records (including names, addresses, DOBs & phone numbers) to a .txt file selected by the user during program execution

How to build and run (Windows PowerShell)
---------------------------------------

Open PowerShell in the repository root

Change directory to the project you wish to run by running"

```
cd "{insert-directory}"
```

The run the program:
```
dotnet build
dotnet run
```

Directory List:
---
- JSON Files
    - Create: ```"C:\Users\natha\OneDrive\Documents\Coding Projects\C# Projects\COSC_335_FileManagementProject\JSONFiles\JSONFileCreate\JSONFileCreate"```
    - Read: ```"C:\Users\natha\OneDrive\Documents\Coding Projects\C# Projects\COSC_335_FileManagementProject\JSONFiles\JSONFileRead\JSONFileRead"```
    - Write: ```"C:\Users\natha\OneDrive\Documents\Coding Projects\C# Projects\COSC_335_FileManagementProject\JSONFiles\JSONFileWrite\JSONFileWrite"```

- .txt Files
    - Create: ```"C:\Users\natha\OneDrive\Documents\Coding Projects\C# Projects\COSC_335_FileManagementProject\TXTFiles\TXTFileCreate\TXTFileCreate"```
    - Read: ```"C:\Users\natha\OneDrive\Documents\Coding Projects\C# Projects\COSC_335_FileManagementProject\TXTFiles\TXTFileRead\TXTFileRead"```
    - Write: ```"C:\Users\natha\OneDrive\Documents\Coding Projects\C# Projects\COSC_335_FileManagementProject\TXTFiles\TXTFileWrite\TXTFileWrite"```

Authorship:
------
GitHub Copilot Chat was used to assist in the understanding of code, as well as fixing errors, and updating the README.md file.

Repository Authors: NathanP06, TylerLuke024, Kelmyrl