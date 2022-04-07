using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace n1q3
{
    class GameRules
    {
        public static void ShowRules(HashSet<string>List)
        {

            Console.WriteLine("            Game Rules");
            Console.WriteLine("----------------------------------------");
            Console.Write("user\\computer");
            foreach (var item in List)
            {
                Console.Write(item + " | ");
            }
            int i = 1;
            int dischanger = (List.Count - 1) / 2;
            Console.WriteLine();

            foreach (var item in List)
            {
                i++;
                int j = 1;
                int count = 0;
                bool drawPos = false;

                Console.Write(item);
                foreach (var item2 in List)
                {
                    if (item == item2){
                        Console.Write("draw | ");
                        drawPos = true; 
                    }
                    else
                    {
                        int l=dischanger + i  - j - List.Count;
                        if (i + dischanger - j > List.Count && count !=l)
                        {
                            Console.Write("| Win |");
                            count++;
   
                        }
                        else if (j <= List.Count-dischanger-1&& drawPos==true)
                        { 
                            j++;
                            Console.Write("| Win |");
                        }
                        else Console.Write("| Lose |");
                    }
                }
                Console.WriteLine();
            }

            //Console.WriteLine("-------------------------------------");
            //int dischanger = (List.Count - 1) / 2;
            //foreach (var item1 in List)
            //{
            //    int count = 0;
            //    bool next = false;
            //    foreach (var item2 in List)
            //    {
            //        if (item1 == item2) next = true;
            //        if (next == false) continue;
            //        else if (item1 != item2 && count != dischanger && next == true)
            //        {
            //            count++;
            //            Console.WriteLine($"{item1} >{item2}");
            //        }
            //        if (count != dischanger && List.Last() == item2)
            //        {
            //            foreach (var item3 in List)
            //            {
            //                Console.WriteLine($"{item1} >{item3}");
            //                count++;
            //                if (count == dischanger) break;
            //            }
            //        };
            //    }
            //    Console.WriteLine("-------------------------------------");

            //}
        }
    }
}
