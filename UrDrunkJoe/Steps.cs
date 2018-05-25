using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrDrunkJoe
{
    class Steps
    {
        // create the list of steps in an int array[joe,w,h]
        private static int[,] listofjoes = Steps.Initiate(Game.world);
        private static int[,] Initiate(string[,] world)
        { 
            int joew = Game.Joew(world); 
            int joeh = Game.Joeh(world);
            int[,] listofjoes = new int[1, 3] { { 1, joew, joeh } };
            return listofjoes;
        }   
        public static void AddStep(int[] newstep) //adds a step to the list of steps
        {
            int index = listofjoes.GetLength(0);
            int[,] temporaljoes = new int[index+1, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j=0;j<index;j++)
                {
                    temporaljoes[j, i] = Steps.listofjoes[j, i];
                }
                temporaljoes[index, i] = newstep[i];
            }
            Steps.listofjoes = temporaljoes;
        }
        public static void AddJoe(string[,] world) //finishes the current Joe and adds a new one
        {
            int currentjoe = Steps.listofjoes[Steps.listofjoes.GetLength(0) - 1, 0];
            int joew = Game.Joew(world);
            int joeh = Game.Joeh(world);
            int[] newjoe = new int[] { currentjoe + 1, joew, joeh };

            Steps.AddStep(newjoe);
        }
        public static int Length()
        {
            int steps = listofjoes.GetLength(0);
            return steps;
        }
        public static void ReadJoe()
        {

        }
        public static void ReadStep()
        {

        }
        public static int Readresult(int step, int column)
        {
            int number = listofjoes[step, column];
            return number;
        }
    }
}
