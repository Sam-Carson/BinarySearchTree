using static System.Console;

namespace BinarySearchTreeRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree t = new BinarySearchTree();
            string keyInput;
            string valueInput;
            string input;
            bool done = false;

            string[] teamNames = LoadTeamTable();
            string[] teamLocations = LoadTeamLocation();

            for (int i = 0; i < teamNames.Length; i++)
            {
                
                t.Insert(teamNames[i], teamLocations[i]);
                WriteLine($"--{teamNames[i].ToUpper(), -15} ({teamLocations[i].ToUpper(), 5}) has beenn added");
            }

            do
            {
                Write("\nSelect (I)nsert, (D)elete, (T)raverse, (F)ind, or (Q)uit: ");
                switch (ReadLine().ToUpper())
                {
                    case "I":
                        WriteLine("INSERT A NEW TEAM");
                        WriteLine("----------------------");
                        Write("\n- - - TEAM NAME: ");
                        keyInput = ReadLine();
                        Write("\n- - - TEAM CITY: ");
                        valueInput = ReadLine();
                        t.Insert(keyInput, valueInput);
                        WriteLine($"{keyInput} successfully added.");
                        break;
                    case "D":
                        Write("\nTEAM TO DELETE: ");
                        input = ReadLine();
                        string delete = t.Find(input);
                        if (delete != "not found")
                        {
                            string locationDeleted = t.Find(input);
                            t.Delete(input);
                            WriteLine($"The {input} from {locationDeleted} are no more!");
                        }
                        else WriteLine($"{input} was not found.");
                        
                        break;
                    case "T":
                        WriteLine("\nCONTENT OF BINARY TREE IN ASCENDING SEQUENCE: ");
                        WriteLine("-----------------------------------------------------------");
                        t.Traverse();
                        WriteLine();
                        break;
                    case "F":
                        WriteLine("FIND A TEAM");
                        WriteLine("----------------------");
                        Write("\nTEAM NAME: ");
                        input = ReadLine();
                        string message = t.Find(input);
                        if (message == "not found")
                        {
                            WriteLine($"{input} was not found!");
                        }
                        else WriteLine($"{input} are from {message}");                        
                        break;
                    case "Q":
                        WriteLine("\nOkey dokey.  All done.");
                        done = true;
                        break;
                    default:
                        WriteLine("INVALID COMMAND: ");
                        break;
                }
            } while (!done);

            ReadKey();
        }

        private static string[] LoadTeamTable()
        {
            return new string[32] {"Cardinals","Falcons","Ravens","Bills",
                "Panthers","Bears","Bengals","Browns",
                "Cowboys","Broncos","Lions","Packers",
                "Texans","Colts","Jaguars","Chiefs",
                "Chargers","Rams","Dolphins","Vikings",
                "Patriots","Saints","Giants","Jets",
                "Raiders","Eagles","Steelers","49ers",
                "Seahawks","Buccaneers","Titans","Football Team"};
        }

        private static string[] LoadTeamLocation()
        {
            return new string[32] {"Arizona","Atlanta","Baltimore","Buffalo",
            "Carolina","Chicago","Cincinnati","Cleveland",
            "Dallas","Denver","Detroit","Green Bay",
            "Houston","Indianapolis","Jacksonville","Kansas City",
            "Los Angeles","Los Angeles", "Miami","Minnesota",
            "New England","New Orleans","New York","New York",
            "Oakland","Philadelphia","Pittsburgh","San Francisco",
            "Seattle","Tampa Bay","Tennessee", "Washington"};
        }
    }
}
