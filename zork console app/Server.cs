/**
*--------------------------------------------------------------------
* File name: {Server.cs}
* Project name: {Project 5 - Zork}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch lynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {4/29/2023}
* -------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zork_console_app
{
    public class Server
    {
        private bool hasFirewall;
        private int firewallHealth;
        private bool firewallDefeated;
        private bool hasHack;
        private bool isFinalServer;
        private IHack hack;

        private string[] hackNames = { "Doomsday", "SQL Injection", "DDoS", "Malware-Injection", "Bruteforce" };

        public Server()
        {
            hasFirewall = false;
            firewallHealth = 0;
            hasHack = false;
            isFinalServer = false;
        }
        public int SetFirewallHealth(int health)
        {
            firewallHealth = health;
            return firewallHealth;
        }
        public void HasFirewall(bool hasFirewall)
        {
            this.hasFirewall = hasFirewall;
            if (hasFirewall)
            {
                firewallHealth = 20;
            }
        }
        public bool GetHasFirewall()
        {
            return hasFirewall;
        }
        public void SetHasFirewall(bool firewall)
        {
            hasFirewall = firewall;
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
        public void SetIsFinalServer(bool finalServer)
        {
            isFinalServer = finalServer;
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
                case "Bruteforce":
                    hack = new Bruteforce();
                    break;
            }
            hasHack = true;
        }
        public string TrySpawnHack()
        {
            Random rand = new Random();
            if (rand.Next(1, 5) == 1)
            {
                hasHack = true;
                return hackNames[rand.Next(hackNames.Length)];
            }
            return null;
        }
        public void Fight(int health, int paulHitDamage)
        {
            if (hasFirewall && !firewallDefeated)
            {
                while (health > 0 && firewallHealth > 0)
                {
                    Console.WriteLine("Player's turn:");
                    int hitChance = new Random().Next(1, 11);

                    if (hitChance == 1)
                    {
                        Console.WriteLine("a miss");
                    }
                    else
                    {
                        Console.WriteLine("a hit!");
                        firewallHealth -= paulHitDamage;
                    }
                    Console.WriteLine("Monster's turn:");
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
