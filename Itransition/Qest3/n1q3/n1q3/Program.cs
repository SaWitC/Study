using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Collections;
using System.Linq;
using System.Text;

namespace n1q3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0||args.Length==1)
                {
                    Console.WriteLine("few elements");
                    return;    
                }
                HashSet<string> list = new HashSet<string>();
                Dictionary<int, string> StepDictionary = new Dictionary<int, string>();
                int i = 0;
                foreach (var item in args)
                {
                    list.Add(item);
                    i++;
                    StepDictionary.Add(i, item);
                    //if(li)
                }
                if (list.Count % 2 == 0 || list.Count==1) { Console.WriteLine($"an even number {list.Count}");  return; }
                i = 0;

                //hach
                Random r = new Random();

                int valindex = r.Next(1, list.Count);
                string outForHach = "";
                StepDictionary.TryGetValue(valindex, out outForHach);
                byte[] byteArr = Encoding.Default.GetBytes(outForHach);

                HMACKey hkey = new HMACKey();
                Console.WriteLine(hkey.GenerateHMAC(byteArr));

                string StepNotParse = "";
                int stepDoneParse = -1;

                //data verification
                while (true)
                {
                    Console.WriteLine("Available moves:");
                    foreach (var item in list)
                    {
                        i++;
                        Console.WriteLine($"{i} - {item}");
                    }
                    Console.WriteLine("0 - Exit");
                    Console.WriteLine("? - help");

                    //Console.Write("Enter your mov: ");
                    try
                    {
                        Console.WriteLine($"Enter your move: {StepNotParse}");
                        StepNotParse = Console.ReadLine();
                        if (StepNotParse == "?")
                        {
                            GameRules.ShowRules(list);
                            //break;
                        }
                        else if(int.Parse(StepNotParse) < 0 || int.Parse(StepNotParse) > list.Count)
                        {
                            throw new Exception("number out of range");
                        }
                        else
                        {
                            if (int.TryParse(StepNotParse, out stepDoneParse)) break;
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message);}
                }
                if (stepDoneParse == 0)
                {
                    return;
                }
                string x, x2;
                StepDictionary.TryGetValue(stepDoneParse, out x);
                StepDictionary.TryGetValue(valindex, out x2);

                // Console.WriteLine($"your move: {x}");
                Console.WriteLine($"computer move: {x2}");

                Console.WriteLine("HMAC key");
                Console.WriteLine(hkey.key);

                Winer winer = new Winer(list);
                winer.CheckWiner(stepDoneParse, valindex);
                Console.ReadKey();

                Console.WriteLine("check HMAC");
                Console.WriteLine("input computer step text not number");string ComputerStep= Console.ReadLine();

                byte[] byteArr2 = Encoding.Default.GetBytes(ComputerStep);

                Console.WriteLine(hkey.GenerateHMACByKey(byteArr2,hkey.bytrkey));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
