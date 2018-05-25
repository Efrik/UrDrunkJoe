using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrDrunkJoe
{
    class User
    {
        public static void Any ()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        public static string Generator_type()
        {
            bool worldchosen = false;
            string input = "";
            while (worldchosen == false)
            {                
                string worldtype = Console.ReadLine();
                if (worldtype == "1")
                {
                    worldchosen = true;
                    input = "generic";
                }
                if (worldtype == "2")
                {
                    worldchosen = true;
                    input = "custom";
                }
                Print.EnterValue("world generation type [1:Generic, 2:Custom]");
            }
            return input;
        }
        public static string Input_string(string varname)
        {
            Print.EnterValue(varname);
            string userinput = Console.ReadLine();
            return userinput;
        }
        public static int Input_integer(string varname)
        {
            bool parsed = false;
            int input = 0;
            while (parsed == false) {
                Print.EnterValue(varname);
                string userinput = Console.ReadLine();
                int zero = 0;
                if (int.TryParse(userinput, out zero))
                {
                    int integer = int.Parse(userinput);
                    if (integer > 0)
                    {
                        parsed = true;
                        input= integer;
                    }
                }
            }
            return input;
        }
        public static int Input_integer_limit(string varname,int min, int max)
        {
            bool parsed = false;
            int input = 0;
            while (parsed == false)
            {
                Console.WriteLine("Please, enter a valid value to " + varname + ":");
                string userinput = Console.ReadLine();
                int zero = 0;
                if (int.TryParse(userinput, out zero))
                {
                    int integer = int.Parse(userinput);
                    if (integer >= min)
                    {
                        if (integer <= max)
                        {
                            parsed = true;
                            input = integer;
                        }
                    }
                }
                Console.Clear();
            }
            return input;
        }
        public static int ChoseRow(string[,] m, int max)
        {
            Print.World_customedit(m);
            Console.WriteLine("Now, you shall chose one row to edit.");
            int row = User.Input_integer_limit("row", 1, max+1);
            Console.WriteLine("You have chosen line number " + row + ".");
            return row;
        }
        public static string ModifyRow(string[,] m, int r,int w)
        {
            bool isok = false;
            bool lengthok = false;
            bool charok = true;
            string line = "";
            while (isok == false)
            {
                lengthok = false;
                charok = true;
                Print.Generator_custom_3(m, r, w);
                line = Console.ReadLine();
                int length = line.Length;
                if (length == w)
                {
                    lengthok = true;
                }
                for (int c = 0; c < w; c++)
                {
                    char a = line.ElementAt(c);
                    string b = a.ToString();
                    if ((b != "=") && (b != "O") && (b != "J") && (b != " ") && (b != "W"))
                    {
                        charok = false;
                    }
                }
                if ((lengthok == true) && (charok == true))
                {
                    isok = true;
                }else
                {
                    Console.WriteLine("That is not a valid row.");
                }
            }
            return line;                
        }
        public static int NextResult()
        {
            bool chosen = false;
            int input = 0;
            while (chosen == false)
            {
                string next = Console.ReadLine();
                if (next == "1")
                {
                    chosen = true;
                    input = 1;
                }
                else if (next == "2")
                {
                    chosen = true;
                    input = 2;
                }
                else if (next=="3")
                {
                    chosen = true;
                    input = 3;
                }
                if (chosen == false)
                {
                    Console.WriteLine("Please, enter a valid option.");
                }
            }
            return input;
        }
        public static int input_resultmode()
        {
            bool chosen = false;
            int input = 0;
            while (chosen == false)
            {
                string next = Console.ReadLine();
                if (next == "1")
                {
                    chosen = true;
                    input = 1;
                }
                else if (next == "2")
                {
                    chosen = true;
                    input = 2;
                }
                Console.WriteLine("Please, enter a valid option.");
            }
            return input;
        }
    }
}
