using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zork_console_app
{
    internal class Server
    {
        private bool hasFirewall;
        private int firewallHealth;
        private bool firewallDefeated;
        private bool hasHack;
        private bool hasPassword;
        private bool isFinalServer;
        private IHack hack;
        private string password;
        string[] hackNames = { "Doomsday", "SQL Injection", "DDoS", "Malware-Injection" };
        public Server()
        {
            Random rand = new Random();
            hasFirewall = rand.Next(1, 3) == 1;

            if (hasFirewall)
            {
                firewallHealth = 20;
            }

            if (!hasFirewall && rand.Next(1, 5) == 1)
            {
                hasHack = true;
                GenerateHack();
                if (rand.Next(1, 5) == 1)
                {
                    TrySpawnHack();
                }
            }
            else
            {
                hasHack = false;
            }
        }
        public bool HasFirewall()
        {
            return hasFirewall;
        }
        public bool FirewallDefeated()
        {
            return firewallDefeated;
        }
        public bool HasHack()
        {
            return hasHack;
        }
        public IHack GetHack()
        {
            if (hack != null)
            {
                Console.WriteLine("PAUL>> I have obtained a hack: " + hack.GetType().Name);
                return hack;
            }
            else
            {
                Console.WriteLine("PAUL>> Sorry, there is no hack in this server.");
                return null;
            }
        }
        public bool HasPassword()
        {
            return hasPassword;
        }

        public void SetPassword(string password)
        {
           this.password = password;
        }

        public bool IsFinalServer()
        {
            return isFinalServer;
        }
        public void GenerateHack()
        {
            string newHackName = hackNames[new Random().Next(0, hackNames.Length)];
            switch (newHackName)
            {
                case "Doomsday":
                    hack = new Doomsday();
                    break;
                case "SQL Injection":
                    hack = new SQLInjection();
                    break;
                case "DDoS":
                    hack = new DDoS();
                    break;
                case "Malware-Injection":
                    hack = new MalwareInjection();
                    break;
            }
            hasHack = true;
        }
        public string TrySpawnHack()
        {
            // Try to spawn a weapon with 30% chance
            Random rand = new Random();
            if (rand.Next(1, 5) == 1)
            {
                return hackNames[rand.Next(hackNames.Length)];
                hasHack = true;
            }
            return null;
        }
        public string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random rand = new Random();
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public void Fight(int health)
        {
            if (hasFirewall && !firewallDefeated)
            {
                while (health > 0 && firewallHealth > 0)
                {
                    Console.WriteLine("Player's turn:");
                    // represents a 10% chance of missing the Firewall
                    int hitChance = new Random().Next(1, 11);

                    if (hitChance == 1)
                    {
                        Console.WriteLine("a miss");
                    }
                    else
                    {
                        Console.WriteLine("a hit!");
                        firewallHealth -= 5;
                    }

                    Console.WriteLine("Monster's turn:");
                    // Generate a random number between 1 and 5, representing a 20% chance of missing the player
                    hitChance = new Random().Next(1, 6);

                    if (hitChance == 1)
                    {
                        Console.WriteLine("The monster missed the player.");
                    }
                    else
                    {
                        Console.WriteLine("The player is hit.");
                        health -= 4;
                    }

                    Console.WriteLine("Player health: " + health);
                    Console.WriteLine("Monster health: " + firewallHealth);
                }

                if (health == 0)
                {
                    Console.WriteLine("you died");
                }
                else if (firewallHealth == 0)
                {
                    Console.WriteLine("you killed the firewall");
                    firewallDefeated = true;
                }
            }
            else
            {
                Console.WriteLine("the firewall has already been beaten");
            }
        }
        

    }
}
