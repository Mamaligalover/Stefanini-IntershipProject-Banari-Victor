using System;
using System.Collections.Generic;
using System.Linq;

namespace InternshipProject
{
    class Startup
    {
        static void Main(string[] args)
        {

            //Cooks Info
            var cooks = new List<Cook>()
            {
                new Cook()  { ID = 1, Numberdishes = 0,  Time=0 },
                new Cook()  { ID = 2, Numberdishes = 0, Time=0 },
                new Cook()  { ID = 3, Numberdishes = 0,  Time=0 },
                new Cook()  { ID = 4, Numberdishes = 0, Time=0 }
             
            };
            //----------------------------------Sorted list of cooks by time---------------------------------
            List<Cook> sortedCooks = cooks.OrderBy(x => x.Time).ToList();


            //Ingredients Info
            string[] ingredients = { 
                   
                                    "Tomato", "5",  
                                    "Meet", "20", 
                                    "Onion", "2",
                                    "Garlic", "7",
                                    "Cheese", "15",
                                    "Carrot", "4",
                                    "Salt", "1",
                                    "Dough", "9",
                                    "Peper", "4",
                                    "Potato", "3",
                                    "Oil", "3"
                                    };


 //-------------------Dishes information-----------------------------------
            var menu = new List<Menu>() 
            {
                new Menu()
                {
                     Name = "Borch",
                     Description = new string[] {"Tomato", "Meet", "Salt", "Garlic"},
                     Time = 15
                },
                new Menu()
                {
                     Name = "Pizza",
                     Description = new string[] { "Tomato", "Meet", "Salt", "Peper","Dough" },
                     Time = 25
                 },
                new Menu()
                {
                    Name = "Free potato",
                    Description = new string[] { "Potato", "Oil", "Salt"},
                    Time = 5
                },
                new Menu()
                {
                    Name = "Spageti",
                    Description = new string[] { "Tomato", "Dough", "Salt", "Peper", "Meet" },
                    Time = 15
                 },

        };


            //----------------Calculating dish price------------------------------

                     double FinalPrice(string[] description)
                     {
                            var localprice = 0;
                             

                              
                            for (int j = 0; j < description.Length; j++)
                            {
                                for (int i = 0; i < ingredients.Length-1; i++)
                                {
                                    if (ingredients[i].ToUpper() == description[j].ToUpper())
                                              localprice += int.Parse(ingredients[i + 1]);

                                }
                            }
                            

                        return localprice*1.2;

                     }


            //---------------------------Display Menu--------------------------------
            Console.WriteLine("---------------Menu-----------------");
            Console.WriteLine("               Welcome");
            foreach (var food in menu)
            {
                Console.WriteLine();
                Console.Write(" Name : ");
                Console.WriteLine(food.Name);
                Console.Write(" Description : ");
                for (int i = 0; i < food.Description.Length; i++)
                {
                    Console.Write(food.Description[i]);
                    Console.Write(", ");
                }
                Console.WriteLine();
                Console.Write(" Time of preparing (minutes) : ");
                Console.WriteLine(food.Time);
                Console.Write(" Price : ");
                Console.WriteLine(FinalPrice(food.Description));
                for (int i = 0; i < 15; i++)
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine(" ");
            //______________________________________Instruction__________________________________________
            Console.WriteLine("to finish the order please type y then press ENTER after pres ESC ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");






            //--------------------------------Order Process------------------------------------------------
            Console.WriteLine("type the number of custumers : ");
            var numberofcustumers = int.Parse(Console.ReadLine());
            var totalprice = 0.0;
            for (int i = 1; i <= numberofcustumers; i++)
            {
                var check = false;
                Console.WriteLine("Custumer {0} please place your order ",i);
                List<string> order = new List<string>();
                

                do
                {
                    var dish = "";
                    while (!Console.KeyAvailable)
                    {
                        while (dish != "0")
                        {
                            dish = Console.ReadLine();

                            //Add a dish to a list of dishes for one custumer
                            if (dish != "0")
                            {
                                order.Add(dish);
                            }
                            
                        }
                        
                        
                    }

                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                foreach (var dish in order)
                {
                   //Calculate price per custumer
                    foreach (var item in menu)
                    {
                        if (dish.ToUpper() == item.Name.ToUpper())
                        {
                            totalprice += FinalPrice(item.Description);
                            foreach (var cook in sortedCooks)
                            {
                                if (cook.Numberdishes < 5)
                                {
                                    foreach (var cook2 in cooks)
                                    {
                                        if (cook.ID == cook2.ID)
                                        {
                                            cook2.Numberdishes++;
                                            cook2.Time += item.Time;
                                            check = true;

                                        }

                                    }
                                    cook.Numberdishes++;
                                    check = true;
                                }
                                

                            }

                        }

                    }
                   
                    
                }
                
                order.Clear();
                if (!check)
                {
                     Console.WriteLine("No cooks available please wait {0} minutes ", sortedCooks[0].Time); 
                }
            }
                Console.WriteLine(totalprice);



        }
    }
}