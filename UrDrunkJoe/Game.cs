using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrDrunkJoe
{
    class Game
    {
        public static Random rnd = new Random();
        public static string[,] world;
        public static string[,] map = new string[2, 2] { { "a", "b" }, { "c", "d" } };
        public static bool alive = true;
        public static string previousdir = "west";
        public static int joenumber = 1;
        public static int lastjoe = 1;
        public static int joesathome = 0;
        public static Register stepregister = new Register();

        public static void Intro()
        {
            Print.Intro();
            User.Any();
        }
        public static void Worldgen()
        {
            Print.Generator();
            string worldgen_type = User.Generator_type();
            switch (worldgen_type)
            {
                case "generic":
                    world = Game.Worldgen_generic();
                    map = Cloneworld(world);
                    break;
                case "custom": 
                    world = Game.Worldgen_custom();
                    map = Cloneworld(world);
                    break;
            }
            Print.World(world);
            Print.Generator_end();
            User.Any();
        }
        public static string[,] Worldgen_generic()
        {
            Print.Generator_generic_1();
            int width = User.Input_integer("width");
            int height = User.Input_integer("height");
            Console.WriteLine("Thanks. The island is now " + width + " cells width and " + height + " cells height.");
            User.Any();
            string[,] newworld = new string[width+2, height+2];
            for (int i = 1; i < height + 1; i++)
            {
                newworld[0, i] = "=";
                newworld[width + 1, i] = "=";
                newworld[width, i] = "O";
                for (int j = 1; j < width; j++)
                {
                    newworld[j, i] = " ";
                }
            }
            for (int j = 0; j < width + 2; j++)
            {
                newworld[j, 0] = "=";
                newworld[j, height + 1] = "=";
            }
            int midleheight = (height / 2) + 1;
            newworld[1, midleheight] = "J";
            return newworld;
        }
        public static string[,] Worldgen_custom()
        {
            Print.Generator_custom_intro();
            int width = User.Input_integer("width");
            int height = User.Input_integer("height");
            Console.WriteLine("Thanks. The island is now " + width + " cells width and " + height + " cells height.");
            User.Any();
            string[,] newworld = new string[width + 2, height + 2];
            for (int i = 1; i < height + 1; i++)
            {
                newworld[0, i] = "=";
                newworld[width + 1, i] = "=";
                for (int j = 1; j < width+1; j++)
                {
                    newworld[j, i] = "?";
                }
            }
            for (int j = 0; j < width + 2; j++)
            {
                newworld[j, 0] = "=";
                newworld[j, height + 1] = "=";
            }
            bool Mapok = false;
            while (Mapok == false)
            {
                Print.Generator_custom_2();
                int rowToEdit = User.ChoseRow(newworld, height);
                Game.EditRow(newworld, rowToEdit, width);
                if (CheckMap(newworld)==true) {
                    int confirmed = 0;
                    confirmed = Print.Generator_custom_4();
                    if (confirmed == 1)
                    {
                        Mapok = true;
                    }
                }
            }
            return newworld;
        }
        public static string[,] EditRow(string[,] m, int r, int w)
        {
            string[,] modifiedmap = Game.Cloneworld(m);
            string modifiedline = User.ModifyRow(m,r, w);
            modifiedmap = Game.Modifymap(m, r, modifiedline);
            return modifiedmap;
        }
        public static string[,] Modifymap(string[,] m, int r, string l)
        {
            int length = l.Length;
            for (int i=0; i < length; i++)
            {
                char a = l.ElementAt(i);
                string b = a.ToString();
                m[i+1, r] = b;
            }
            return m;
        }
        public static bool CheckMap(string[,] m)
        {
            bool mapready = false;
            bool charsready = true;
            bool jok = false;
            int w = m.GetLength(0);
            int h = m.GetLength(1);
            int numberJs = 0;
            for (int i=0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (m[i, j] == "?")
                    {
                        charsready = false;
                    }
                    if (m[i, j] == "J")
                    {
                        numberJs += 1;
                    }
                }
            }
                        if (numberJs == 1)
            {
                jok = true;
            }
            if ((charsready == true)&& (jok == true))
            {
                mapready = true;
            }
            return mapready;
        }
        public static int Cloningfacilities ()
        {
            Print.Cloningfacilities();
            int joes=User.Input_integer("amount of joes");
            Print.Joes(joes);
            User.Any();
            lastjoe = joes;
            return joes;
        }
        public static void Experiment(int joes)
        {
            Print.Experiment();
            int nextprint = User.NextResult();
            stepregister.AddJoe();
            int w = Joew(map);
            int h = Joeh(map);
            stepregister.AddStep(1,w,h);
            if (joenumber > lastjoe)
            {
                nextprint = 4;
            }
            switch (nextprint)
            {
                case 1: //+1 Turn
                    Turn(map);
                    Experiment(joenumber);
                    break;
                case 2: //+1 Joe
                    int joeone = joenumber + 1;
                    while (joeone!=joenumber)
                    {
                        Turn(map);
                    }
                    Experiment(joenumber);
                    break;
                case 3: //finnish all joes
                    while (joenumber <= lastjoe)
                    {
                        Turn(map);
                    }
                    break;
                case 4:
                    break;
            }
        }
        public static string[,] Cloneworld(string[,] worldmap)
        {
            int worldw = worldmap.GetLength(0);
            int worldh = worldmap.GetLength(1);
            string[,] clonedworld = new string[worldw, worldh];
            for (int w=0; w < worldw; w++)
            {
                for (int h = 0; h < worldh; h++)
                {
                    clonedworld[w, h] = worldmap[w, h];
                }
            }
            return clonedworld;
        }
        public static string Chosedir()
        {
            int randomnum = rnd.Next (1,5);
            switch (randomnum)
            {
                case 1:
                    return "north";
                case 2:
                    return "south";
                case 3:
                    return "east";
                case 4:
                    return "west";
            }
            return "";
        }
        public static int Joew(string[,] world)
        {
            int width = world.GetLength(0);
            int height = world.GetLength(1);
            int joeW = 0;
            for (int w=0;w<width;w++)
            {
                for (int h = 0; h < height; h++)
                {
                    if (world[w, h] == "J")
                    {
                        joeW= w;
                    }
                }
            }
            return joeW;
        }
        public static int Joeh(string[,] world)
        {
            int width = world.GetLength(0);
            int height = world.GetLength(1);
            int joeH = 0;
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    if (world[w, h] == "J")
                    {
                        joeH=h;
                    }
                }
            }
            return joeH;
        }
        public static void NewJoe () //resets the map
        {
            map = Cloneworld(world);
            joenumber += 1;
            int joew = Joew(map);
            int joeh = Joeh(map);
            if (joenumber <= lastjoe)
            {
                stepregister.AddJoe();
                stepregister.AddStep(joenumber, joew, joeh);
            }
        }
        public static void Movejoe(string direction, string[,] mapreference)
        {
            //locates joe
            int origjoew = Joew(mapreference);
            int origjoeh = Joeh(mapreference);
            //Calculates where Joe should go
            int newjoew = origjoew;
            int newjoeh = origjoeh;
            switch (direction)
            {
                case "north":
                    newjoeh -= 1; 
                    break;
                case "south":
                    newjoeh += 1;
                    break;
                case "west":
                    newjoew += 1;
                    break;
                case "east":
                    newjoew -= 1;
                    break;
            }
            /*Console.WriteLine("This is world:");
            Print.World(world);
            Console.WriteLine("This is map:");
            Print.World(map);
            Console.WriteLine("Now we are modfiyng just map:");
            User.Any();*/
            // Move if it is possible (not a wall)
            if (world [newjoew, newjoeh] != "W")
            {
                map [newjoew,newjoeh] = "J";
                map [origjoew,origjoeh]=" ";
            }
            /*Console.WriteLine("This is world:");
            Print.World(world);
            Console.WriteLine("This is map:");
            Print.World(map);
            User.Any();*/
            //Register the movement
            stepregister.AddStep(joenumber,newjoew,newjoeh);
            // If Joe dies, reset and start with next joe.
            if (world[newjoew, newjoeh] == "=")
            {
                NewJoe();
                alive = false;
            }
            if (world[newjoew, newjoeh] == "O")
            {
                NewJoe();
                alive = false;
                joesathome += 1;
                stepregister.Survived(joenumber);
            }
        }
        public static void Turn (string[,] mapreference)
        {
            string newdirection = Chosedir();
            //Console.WriteLine(newdirection);
            Movejoe(newdirection,mapreference);
        }
        public static void Showresults()
        {
            Print.Resultintro();
            int resultmode= User.input_resultmode();
            switch (resultmode)
            {
                case 1:
                    Print.Resultdetail();
                    break;
                case 2:
                    break;
            }
        }

    }
}
