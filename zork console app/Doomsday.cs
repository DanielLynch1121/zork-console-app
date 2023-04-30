﻿/**
*--------------------------------------------------------------------
* File name: {Doomsday.cs}
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
    public class Doomsday : IHack
    {
        public string Name { get; } = "Doomsday";
        public int Damage { get; } = 17;
    }
}
