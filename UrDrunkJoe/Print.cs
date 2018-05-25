using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrDrunkJoe
{
    class Print
    {
        public static void EnterValue (string varname)
        {
            Console.Clear();
            Console.WriteLine("Please, enter a valid value to "+varname+":");
        }
        public static void Intro()
        {
            Console.WriteLine("YOU ARE DRUNK, JOE");
            Console.WriteLine("Joe has just been kicked from his Bar on a little island.");
            Console.WriteLine("Could he walk back home on his own?");
            Console.WriteLine("Or shall he fall ashore?");
            Console.WriteLine("Lets try Joe´s walking skills!");
            Console.WriteLine(" ");
            Console.WriteLine("First, you have to design the island.");
        }
        public static void Generator()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Joe´s world generator.");
            Console.WriteLine("Do you want to build a generic island or do you want to build your own island?");
            Console.WriteLine("Generic islands ar rectangular areas surrounded by water. Joe starts in the midle of the left side of the rectangle and his home is at the right side.");
            Console.WriteLine("Write 1 to build a generic island.");
            Console.WriteLine("Write 2 to build a custom island.");
            Console.WriteLine("World type: ");
        }
        public static void Generator_generic_1()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the generic world generator.");
            Console.WriteLine("Please, specify width and height of Joe´s island.");
            Print.EnterValue("width");
        }
        public static void Generator_custom_intro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the custom island generator.");
            Console.WriteLine("You are about to design Joe´s island.");
            Print.Generator_custom_rules();
            Console.WriteLine("Please, proceed to specify the island size.");
            User.Any();
        }
        public static void Generator_custom_rules()
        {
            Console.WriteLine("");
            Console.WriteLine("Please remember these rules:");
            Console.WriteLine("1. You must specify the island size as a square.");
            Console.WriteLine("2. You can chose between water, wall, home, or normal floor in every tile.");
            Console.WriteLine("3. Also, there must be one and only Joe spawn point.");
            Console.WriteLine("4. The island will be surrounded by water.");
            Console.WriteLine("");
        }
        public static void Generator_tiletypes()
        {
            Console.WriteLine("Tile types: empty normal ground; = water; O objective; W wall; J Joe spawn; ? unspecified.");
        }
        public static void Generator_custom_2()
        {
            Console.Clear();
            Console.WriteLine("Now, you must design the island row by row. In order to do so, follow these instructions:");
            Console.WriteLine("1. Chose a row to edit.");
            Console.WriteLine("2. write a valid sequence of tiles for that row.");
            Console.WriteLine("3. Continue untill every row has been edited.");
            Console.WriteLine("4. Exit the editor when you are satisfied with your island.");
            Console.WriteLine("");
        }
        public static void Generator_custom_3(string[,] m, int r, int w)
        {
            Console.WriteLine("We are going to edit the tyles from a specific row.");
            Print.World_customedit(m);
            Console.WriteLine("Please, write the sequence of tiles you want for row number " + r + ".");
            Console.WriteLine("Remember to write no more and no less than " + w + " characters, this is, the islands width ignoring the surrounding area.");
            Console.WriteLine("Remember to only use characters for tiletypes, including spacebar:");
            Print.Generator_tiletypes();
            Console.WriteLine("Please, enter a valid sequence:");
        }
        public static int Generator_custom_4()
        {
            Console.WriteLine("It looks like the map is ok now. Do you want to continue to the cloning facilities or do you want to continue editing?");
            Console.WriteLine("1. Continue to cloning facilities.");
            Console.WriteLine("2. Continue editing.");
            int decision = User.Input_integer_limit("your decision", 1, 2);
            return decision;
        }
        public static void Generator_end()
        {
            Console.WriteLine("We will continue to Joe´s Cloning Facilities.");
        }
        public static void Cloningfacilities()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Joe´s cloning facility.");
            Console.WriteLine("You can specify how many drunk Joes will attempt to reach home from the bar.");
            Print.EnterValue("amount of joes");
        }
        public static void Joes(int joes)
        {
            Console.WriteLine("Thanks, we will proceed to send " + joes + " Joes to the bar.");
            Console.WriteLine("Please, continue to the experiment");            
        }
        public static void Experiment()
        {
            Console.Clear();
            Console.WriteLine("We are showing position of joe number "+Game.joenumber+" out of "+Game.lastjoe+" Joes.");
            Console.WriteLine("");
            Print.World(Game.map);
            Console.WriteLine("");
            Console.WriteLine("Press 1 to see next turn.");
            Console.WriteLine("Press 2 to start with next Joe.");
            Console.WriteLine("Press 3 to see the final results.");
            //Print.World(Game.world);
        }
        public static void Resultintro()
        {
            Console.Clear();
            Console.WriteLine("All joes have tried to get home. " + Game.joesathome + " Joes out of "+Game.lastjoe+" joes have achieved it.");
            Console.WriteLine("Do you want to display the details?");
            Console.WriteLine("Press 1 to show every joes step.");
            Console.WriteLine("Press 2 to Exit the program.");
        }
        public static void World(string[,] a)
        {
            Console.WriteLine("");
            Console.WriteLine("This is the island of Joe:");
            Console.WriteLine("");
            int width = a.GetLength(0);
            int height = a.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("[" + a[j, i] + "]");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        public static void World_customedit(string[,] a) {
            Console.WriteLine("");
            Console.WriteLine("This is the island of Joe that you are editing:");
            Console.WriteLine("");
            int width = a.GetLength(0);
            int height = a.GetLength(1);
            Print.Generator_tiletypes();
            Console.WriteLine("");
            Console.WriteLine("Row. [Tiles]");
            for (int i = 0; i < height; i++)
            {
                Console.Write(i + ". ");
                for (int j = 0; j < width; j++)
                {
                    Console.Write("[" + a[j, i] + "]");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
        public static void Resultdetail()
        {
            Console.Clear();
            Game.stepregister.Print();
            User.Any();
        }
    }
}
