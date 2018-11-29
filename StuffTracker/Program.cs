using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffTracker
{
    enum HouseLocation
    {
        Bedroom,
        Kitchen,
        Bathroom
    }

    class Program
    {
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }


        /// <summary>
        /// Add a House Item
        /// </summary>
        
        static void DisplayAddHouseItem(List<HouseItem> inventory)
        {
            string userResponse;
            HouseLocation location;
            HouseItem newHouseItem = new HouseItem();

            DisplayHeader("Add a New House Item");

            //
            //create house item object
            //

            HouseItem houseItem = new HouseItem();

            //
            //set house item properties
            //
            Console.Write("Enter Name: ");
            newHouseItem.Name = Console.ReadLine();

            Console.Write("Enter Location: ");
            userResponse = Console.ReadLine();
            Enum.TryParse(userResponse, out location);
            newHouseItem.Location = location;

            Console.Write("Is this item alive?: ");
            userResponse = Console.ReadLine().ToUpper();
            if (userResponse == "YES")
            {
                newHouseItem.IsLive = true;
            }
            else
            {
                newHouseItem.IsLive = false;
            }

            Console.Write("Enter Value: ");
            newHouseItem.Value = double.Parse(Console.ReadLine());

            //
            //add house item object to inventory list
            //

            inventory.Add(newHouseItem);

            //
            //conirm house item added to inventory
            //
            Console.WriteLine();
            Console.WriteLine($"{newHouseItem.Name} has been added to inventory.");

            DisplayContinuePrompt();
        }

        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayOpeningScreen()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tMake'n Shapes");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tGood Bye");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayInventory(List<HouseItem> inventory)
        {
            double total = 0;

            DisplayHeader("Inventory");

            //
            // Display Column Header
            //

            Console.WriteLine("Name:Location".PadRight(25) + "Value".PadLeft(10));
            Console.WriteLine("-----------------".PadRight(25) + "--------".PadLeft(10));

            foreach (HouseItem item in inventory)
            {
                Console.Write(item.StuffInfo().PadRight(25));
                Console.WriteLine(item.Value.ToString("C2").PadLeft(10));

                total = total + item.Value;
            }
           
            Console.WriteLine("------------".PadLeft(35));
            Console.WriteLine(total.ToString("C2").PadLeft(35));
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void DisplayMainMenu()
        {
            string menuChoice;
            bool loopRunning = true;
            List<HouseItem> inventory;

            //
            // initialize inventory
            //
            inventory = InitializeInventory();

            while (loopRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine();

                Console.WriteLine("\t1) Display Inventory");
                Console.WriteLine("\t2) Add Thing");
                Console.WriteLine("\t3) ");
                Console.WriteLine("\tE) Exit");
                Console.WriteLine();
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        DisplayInventory(inventory);
                        break;

                    case "2":
                        DisplayAddHouseItem(inventory);
                        break;

                    case "3":

                        break;

                    case "e":
                    case "E":
                        loopRunning = false;
                        break;

                    default:
                        break;
                }
            }
        }
        static List<HouseItem> InitializeInventory()
        {
            List<HouseItem> inventory = new List<HouseItem>();

            HouseItem myStuff1 = new HouseItem();
            myStuff1.Name = "Mixer";
            myStuff1.Location = HouseLocation.Kitchen;
            myStuff1.IsLive = false;
            myStuff1.Value = 100000;

            HouseItem myStuff2 = new HouseItem();
            myStuff2.Name = "Blower";
            myStuff2.Location = HouseLocation.Bedroom;
            myStuff2.IsLive = true;
            myStuff2.Value = 500000;

            inventory.Add(myStuff1);
            inventory.Add(myStuff2);

            return inventory;
        }
    }

    class HouseItem
    {

        #region FIELDS

        private string _name;
        private HouseLocation _location;
        private bool _isLive;
        private double _value;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsLive
        {
            get { return _isLive; }
            set { _isLive = value; }
        }

        public HouseLocation Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
        #endregion

        #region METHODS

        public string StuffInfo()
        {
            string stuffInfo;

            stuffInfo = _name + ": " + _location;

            return stuffInfo;
        }

        #endregion

        #region CONSTRUCTORS

        public HouseItem()
        {


        }
    }
    }

        #endregion
    


