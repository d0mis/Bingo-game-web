using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_game_web.Classes
{
    //Class used to generate a list of numbers and draw them randomly
    public class Rand
    {
        private int[] list;
        private int length;
        
        //Creates the list
        public Rand(int length)
        {
            this.length = length;
            list = new int[length];
            for(int i = 0; i < length; i++)
            {
                list[i] = i;
            }
        }

        //Shuffles the list
        public void Suffle()
        {
            Random random = new Random();
            list = list.OrderBy(a => random.Next()).ToArray();
        }

        //Draws a number from the end
        public int draw()
        {
            return list[--length];
        }
    }
}
