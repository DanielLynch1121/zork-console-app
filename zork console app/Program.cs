/**
*--------------------------------------------------------------------
* File name: {Program.cs}
* Project name: {Project 5 - Zork}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch lynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {4//2023}
* -------------------------------------------------------------------
*/
namespace zork_console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRows = new Random().Next(3, 7);
            int numCols = new Random().Next(4, 8);
            int exitRow = new Random().Next(0, numCols);
            int currentRow = 0;
            int currentColumn = 0;
            string mapString;
            Server[,] servers = ServerGenerator.GenerateServers(numRows, numCols);
            Server currentServer = servers[0, 0];
            Paul paul = new Paul();
            Map map = new Map();

            Console.WriteLine("PAUL>> Hello my name is P.A.U.L. Welcome to the main fraim");
            Console.WriteLine($"The Main Frame has {numRows} rows and {numCols} columns.");
            Console.WriteLine($"The entrance is in cell (0,0) and the exit is in cell ({exitRow},{numCols - 1}).");
            Console.WriteLine("I start with 100 health points and once I go down we loose.");
            Console.WriteLine("theere is a map on your screen to the left. P is where I am in the server. ");
            Console.WriteLine("H is where a hack is. this will increase my damage ability.");
            Console.WriteLine("F is where a firewall is. I have to fight these before I can go to a new server.");
            Console.WriteLine("Unfortunately my programer was terrible so if I find a hack that is less damage than the current one");
            Console.WriteLine("I must use that so be careful with the hacks.");
            Console.WriteLine("Guide me to that and to the master server and we win!");
            Console.WriteLine();
            Console.WriteLine("PAUL>> Press any key to continue");
            Console.ReadKey();
            // loop until paul exits dies
            while (true)
            { 
                Console.Clear();
                mapString = map.GenerateMap(servers, currentRow, currentColumn);
                Console.WriteLine(mapString);
                Console.WriteLine();
                Console.WriteLine("PAUL>> Which way should I go?");
                Console.WriteLine("go up");
                Console.WriteLine("go down");
                Console.WriteLine("go left");
                Console.WriteLine("go right");
                Console.Write("Enter a command: ");
                string input = Console.ReadLine().ToLower();

                if (input.StartsWith("go "))
                {
                    string[] parts = input.Split(' ');
                    if (parts.Length == 2 && (parts[1] == "up" || parts[1] == "down" || parts[1] == "left" || parts[1] == "right"))
                    {
                        if (parts[1] == "up")
                        {
                            if (currentRow > 0)
                            {
                                currentRow--;
                                currentServer = servers[currentRow, currentColumn]; 
                                Console.WriteLine($"PAUL>> I have moved up to cell ({currentRow},{currentColumn}).");
                                if (currentServer.GetHasFirewall() && !currentServer.FirewallDefeated())
                                {
                                    Console.WriteLine("PAUL>> There is a firewall in the way");
                                    Console.WriteLine("Press any key to fight");
                                    Console.ReadKey();
                                    currentServer.Fight(paul.GetHealth(), paul.GetDamage());
                                    Console.WriteLine("PAUL>> Press any key to continue");
                                    Console.ReadKey();
                                }
                                else if (currentServer.HasHack())
                                {
                                    IHack hack = (IHack)currentServer.GetHack();
                                    Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                    int damage = hack.Damage;
                                    paul.UpdateDamage(damage);
                                    Console.WriteLine("PAUL>> Press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                                Console.WriteLine("PAUL>> Press any key to continue");
                                Console.ReadKey();
                            }
                        }

                        else if (parts[1] == "down")
                        {
                            if (currentRow < numRows - 1)
                            {
                                if (currentRow < numRows - 1)
                                {
                                    currentRow++;
                                    currentServer = servers[currentRow, currentColumn]; 
                                    Console.WriteLine($"PAUL>> I have moved down to cell ({currentRow},{currentColumn}).");
                                    if (currentServer.GetHasFirewall() && !currentServer.FirewallDefeated())
                                    {
                                        Console.WriteLine("PAUL>> There is a firewall in the way");
                                        Console.WriteLine("Press any key to fight");
                                        Console.ReadKey();
                                        currentServer.Fight(paul.GetHealth(), paul.GetDamage());
                                        Console.WriteLine("PAUL>> Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else if (currentServer.HasHack())
                                    {
                                        IHack hack = (IHack)currentServer.GetHack();
                                        Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                        int damage = hack.Damage;
                                        paul.UpdateDamage(damage);
                                        Console.WriteLine("PAUL>> Press any key to continue");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("PAUL>> I cannot move down any further.");
                                    Console.WriteLine("PAUL>> Press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                                Console.WriteLine("PAUL>> Press any key to continue");
                                Console.ReadKey();
                            }
                        }

                        else if (parts[1] == "right")
                        {
                            if (currentColumn < numCols - 1)
                            {
                                if (currentColumn < numCols - 1)
                                {
                                    currentColumn++;
                                    currentServer = servers[currentRow, currentColumn]; // add this line
                                    Console.WriteLine($"PAUL>> I have moved left to cell ({currentRow},{currentColumn}).");
                                    if (currentServer.GetHasFirewall() && !currentServer.FirewallDefeated())
                                    {
                                        Console.WriteLine("PAUL>> There is a firewall in the way");
                                        Console.WriteLine("Press any key to fight");
                                        Console.ReadKey();
                                        currentServer.Fight(paul.GetHealth(), paul.GetDamage());
                                        Console.WriteLine("PAUL>> Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else if (currentServer.HasHack())
                                    {
                                        IHack hack = (IHack)currentServer.GetHack();
                                        Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                        int damage = hack.Damage;
                                        paul.UpdateDamage(damage);
                                        Console.WriteLine("PAUL>> Press any key to continue");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("PAUL>> I cannot move right any further.");
                                    Console.WriteLine("PAUL>> Press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                                Console.WriteLine("PAUL>> Press any key to continue");
                                Console.ReadKey();
                            }
                        }
                        else if (parts[1] == "left")
                        {
                            if (currentColumn > 0)
                            {
                                currentColumn--;
                                currentServer = servers[currentRow, currentColumn]; 
                                Console.WriteLine($"PAUL>> I have moved left to cell ({currentRow},{currentColumn}).");
                                if (currentServer.GetHasFirewall() && !currentServer.FirewallDefeated())
                                {
                                    Console.WriteLine("PAUL>> There is a firewall in the way");
                                    Console.WriteLine("Press any key to fight");
                                    Console.ReadKey();
                                    currentServer.Fight(paul.GetHealth(), paul.GetDamage());
                                    Console.WriteLine("PAUL>> Press any key to continue");
                                    Console.ReadKey();
                                }
                                else if (currentServer.HasHack())
                                {
                                    IHack hack = (IHack)currentServer.GetHack();
                                    Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                    int damage = hack.Damage;
                                    paul.UpdateDamage(damage);
                                    Console.WriteLine("PAUL>> Press any key to continue");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                                Console.WriteLine("PAUL>> Press any key to continue");
                                Console.ReadKey();
                            }
                        }

                        if (currentServer.IsFinalServer())
                        {
                            Console.WriteLine("Congratulations! You have successfully breached the target system.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command.");
                        Console.WriteLine("PAUL>> Press any key to continue");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                    Console.WriteLine("PAUL>> Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}