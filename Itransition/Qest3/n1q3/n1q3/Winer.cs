using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace n1q3
{
    class Winer
    {
        private HashSet<string> list;
        public Winer(HashSet<string> items)
        {
            list = new HashSet<string>();
            foreach (var item in items)
            {
                list.Add(item);
            }
        }
        public void CheckWiner(int user1, int user2)
        {
            int dischanger = (list.Count - 1) / 2;
            if (user1 == user2) Console.WriteLine("frends win");
            for (int i = 1; i < dischanger+1; i++)
            {
                if (user1 > user2)
                {
                    if (user2 == user1 - i && user1 - i > 0)
                        Console.WriteLine("Computer win");
                    if ((user1 -list.Count)+i==user2 )
                        Console.WriteLine("You win");
                }
                if (user2 > user1)
                {
                    if (user1 == user2 - i && user2 - i > 0)
                        Console.WriteLine("You win");
                    if ((user2 - list.Count) + i == user1)
                        Console.WriteLine("Computer win");
                }

                //if (user1 == user2 - i&&user2-i>0)
                //{
                //    Console.WriteLine("user1 win");
                //}
                //if (user2 == user1 - i&&user1-i >0)
                //{
                //    Console.WriteLine("user2 win");
                //}
                //if (user1 == user2 + i && user2 + i <dischanger)
                //{
                //    Console.WriteLine("user1 win");
                //}
                //if (user2 == user1 + i && user1 + i <dischanger)
                //{
                //    Console.WriteLine("user2 win");
                //}
            }
            //if (user1 > dischanger && user2 > dischanger)
            //{
            //    if(user1>user2-1&&user1>user2-dischanger)
            //}
        }
    }
}
