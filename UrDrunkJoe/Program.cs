using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrDrunkJoe
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // Intro
            Game.Intro();
            // World Generator
            Game.Worldgen();
            //Joe Cloning facilities
            int joes = Game.Cloningfacilities();
            //Experiment
            Game.Experiment(joes);
            //Results
            Game.Showresults();
        }
    }
}

