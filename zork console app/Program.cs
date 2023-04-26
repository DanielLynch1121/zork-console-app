namespace zork_console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRows = new Random().Next(3, 6);
            int numCols = new Random().Next(4, 7);
            int exitRow = new Random().Next(0, numRows);
            int currentRow = 0;
            int currentColumn = 0;

            Server[,] servers = GenerateServers(numRows, numCols);

            Server currentServer = servers[0, 0];
            Paul paul = new Paul();
            int numHacks = 0;
            for (int row = 0; row < servers.GetLength(0); row++)
            {
                for (int col = 0; col < servers.GetLength(1); col++)
                {
                    if (servers[row, col].HasHack())
                    {
                        Console.WriteLine($"Hack found in server at row {row}, column {col}");
                        numHacks++;
                    }
                }
            }
            int numServersWithHack = 0;
            int numServersWithoutHack = 0;
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (servers[row, col].HasHack())
                    {
                        numServersWithHack++;
                    }
                    else
                    {
                        numServersWithoutHack++;
                    }
                }
            }

            Console.WriteLine($"Total number of servers: {numRows * numCols}");
            Console.WriteLine($"Number of servers with hack: {numServersWithHack}");
            Console.WriteLine($"Number of servers without hack: {numServersWithoutHack}");
            Console.WriteLine($"Total number of hacks found: {numHacks}");

            Console.WriteLine("PAUL>> Hello my name is P.A.U.L. Welcome to the main fraim");
            Console.WriteLine($"The Main Frame has {numRows} rows and {numCols} columns.");
            Console.WriteLine($"The entrance is in cell (0,0) and the exit is in cell ({exitRow},{numCols - 1}).");

            // loop until paul exits or dies
            while (true)
            {
                Console.WriteLine("PAUL>> Which way should I go?");
                Console.WriteLine("go north");
                Console.WriteLine("go south");
                Console.WriteLine("go east");
                Console.WriteLine("go west");
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
                                Console.WriteLine($"PAUL>> I have moved up to cell ({currentRow},{currentColumn}).");
                                if (currentServer.HasFirewall() && !currentServer.FirewallDefeated())
                                {
                                    Console.WriteLine("PAUL>> There is a firewall in the way");
                                    Console.WriteLine("Press any key to fight");
                                    Console.ReadKey();
                                    currentServer.Fight(paul.GetHealth());
                                }
                                else if (currentServer.HasHack())
                                {
                                    IHack hack = (IHack)currentServer.GetHack();
                                    Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                    int damage = hack.Damage;
                                    paul.UpdateDamage(damage);
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                            }

                        }
                        else if (parts[1] == "down")
                        {
                            if (currentRow < numRows - 1)
                            {
                                currentRow++;
                                Console.WriteLine($"PAUL>> I have moved down to cell ({currentRow},{currentColumn}).");
                                if (currentServer.HasFirewall() && !currentServer.FirewallDefeated())
                                {
                                    Console.Write("PAUL>> There is a firewall in the way. ");
                                    Console.Write("Press any key to fight");
                                    Console.ReadKey();
                                    currentServer.Fight(paul.GetHealth());
                                }
                                else if (currentServer.HasHack())
                                {
                                    IHack hack = (IHack)currentServer.GetHack();
                                    Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                    int damage = hack.Damage;
                                    paul.UpdateDamage(damage);
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                            }
                        }
                        else if (parts[1] == "left")
                        {
                            if (currentColumn < numCols - 1)
                            {
                                currentColumn++;
                                Console.WriteLine($"PAUL>> I have moved left to cell ({currentRow},{currentColumn}).");
                                if (currentServer.HasFirewall() && !currentServer.FirewallDefeated())
                                {
                                    Console.WriteLine("PAUL>> There is a firewall in the way");
                                    Console.WriteLine("Press any key to fight");
                                    Console.ReadKey();
                                    currentServer.Fight(paul.GetHealth());
                                }
                                else if (currentServer.HasHack())
                                {
                                    IHack hack = (IHack)currentServer.GetHack();
                                    Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                    int damage = hack.Damage;
                                    paul.UpdateDamage(damage);
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                            }
                        }
                        else if (parts[1] == "right")
                        {
                            if (currentColumn > 0)
                            {
                                currentColumn--;
                                Console.WriteLine($"PAUL>> I have moved right to cell ({currentRow},{currentColumn}).");
                                if (currentServer.HasFirewall() && !currentServer.FirewallDefeated())
                                {
                                    Console.WriteLine("PAUL>> There is a firewall in the way");
                                    Console.WriteLine("Press any key to fight");
                                    Console.ReadKey();
                                    currentServer.Fight(paul.GetHealth());
                                }
                                else if (currentServer.HasHack())
                                {
                                    IHack hack = (IHack)currentServer.GetHack();
                                    Console.WriteLine("PAUL>> I have found a " + hack.GetType().Name + " in the server!");
                                    int damage = hack.Damage;
                                    paul.UpdateDamage(damage);
                                }
                            }
                            else
                            {
                                Console.WriteLine("PAUL>> Sorry, but I can't go in that direction.");
                            }
                        }
                        if (currentRow == exitRow && currentColumn == numCols - 1)
                        {
                            Console.WriteLine("Congratulations! You have successfully breached the target system.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }

                

            }
            
        }
        public static Server[,] GenerateServers(int numRows, int numCols)
        {
            Random rand = new Random();
            Server[,] servers = new Server[numRows, numCols];

            // Track whether a password has been added to a server
            bool hasPassword = false;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Server server = new Server();
                    server.HasFirewall();
                    if (!server.HasHack() && !server.HasPassword())
                    {
                        // 20% chance to add a hack
                        if (rand.Next(1, 6) == 1)
                        {
                            server.GenerateHack();
                        }
                        else if (!hasPassword && rand.Next(1, 11) == 1)
                        {
                            string password = server.GeneratePassword();
                            server.SetPassword(password);
                            hasPassword = true;
                        }
                    }
                    servers[row, col] = server;
                }
            }

            return servers;
        }

    }
}