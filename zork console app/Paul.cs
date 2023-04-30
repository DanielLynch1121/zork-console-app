/**
*--------------------------------------------------------------------
* File name: {Paul.cs}
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
using static System.Net.Mime.MediaTypeNames;

namespace zork_console_app
{
    public class Paul
    {
        private int health { get; set; }
        private int damage { get; set; }

        public Paul()
        {
            health = 100;
            damage = 5;
        }

        public int GetHealth()
        {
            return health;
        }
        public int GetDamage()
        {
            return damage;
        }

        public void TakeDamage(int damageTaken)
        {
            health -= damageTaken;
        }
        public void UpdateDamage(int newDamage)
        {
            damage = newDamage;
            Console.WriteLine($" PAUL>> I have updated my damage to {newDamage}.");
        }
    }
}
