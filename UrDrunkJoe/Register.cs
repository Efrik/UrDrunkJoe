using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrDrunkJoe
{
    class Register
    {
        public List<Joe> joelist = new List<Joe>(); 

        //This should make a list of the joes(Register), and every joe should refer to an array/list with the steps given(Joe). then again, a step is an array with the position of the joe (step).
        public void AddJoe()
        {
            joelist.Add(new Joe());
        }
        public void AddStep(int j, int w, int h)
        {
            if (joelist.Count != 0)
            {
                joelist[j-1].Addstep(w, h);
            }
        }
        public int GetLastJoe()
        {
            return joelist.Count();
        }
        public int GetStepH (int joe, int step)
        {
            int stepH = joelist[joe].GetStepH(step);
            return stepH;
        }
        public int GetStepW (int joe, int step)
        {
            int stepW = joelist[joe].GetstepW(step);
            return stepW;
        }
        public void Print()
        {
            int number = -1
                ;
            foreach (Joe x in joelist)
            {
                number += 1;
                Console.WriteLine("Joe number " + (number + 1) + ":");
                x.Print();
                if (joelist[number].survived == false)
                {
                    Console.WriteLine("This Joe did never come home.");
                }else
                {
                    Console.WriteLine("This Joe did arrive home.");
                }
            }
        }
        public void Survived(int j)
        {
            joelist[j - 2].survived = true;
        }
    }
    class Joe
    {
        public List<Step> steplist = new List<Step>();
        public bool survived = false;

        public void Addstep(int w, int h)
        {
            steplist.Add(new Step(w,h));
        }
        public int GetstepW(int stepnumber)
        {
            int stepw = steplist[stepnumber].GetstepW();
            return stepw;
        }
        public int GetStepH(int stepnumber)
        {
            int steph = steplist[stepnumber].Getsteph();
            return steph;
        }
        public void Print()
        {
            int number = 0;
            foreach (Step x in steplist)
            {
                number += 1;
                Console.Write("Step "+number+": ");
                x.Print();
            }
        }
    }
    class Step
    {
        
        public int stepw;
        public int steph;

        public Step (int w, int h)
        {
            stepw = w;
            steph = h;
        }
        public void Setstep (int w, int h)
        {
            stepw = w;
            steph = h;
        }
        public int GetstepW()
        {
            return stepw;
        }
        public int Getsteph()
        {
            return steph;
        }
        public void Print()
        {
            Console.WriteLine("[ " + stepw + ", "+steph + "]");
        }
    }
}
