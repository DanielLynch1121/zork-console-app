/**
*--------------------------------------------------------------------
* File name: {ServerGenerator.cs}
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
    public class ServerGenerator
    {
        public static Server[,] GenerateServers(int numRows, int numCols)
        {
            Random rand = new Random();
            Server[,] servers = new Server[numRows, numCols];
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Server server = new Server();
                    if ((row != 0 || col != 0) && !server.IsFinalServer())
                    {
                        if (rand.Next(1, 3) == 1)
                        {
                            server.SetHasFirewall(true);
                            server.SetFirewallHealth(20);
                        }
                        if (rand.Next(1, 3) == 1)
                        {
                            server.GenerateHack();
                            if (rand.Next(1, 3) == 1)
                            {
                                server.TrySpawnHack();
                            }
                        }
                        if (row == numRows - 1 && col == numCols - 1)
                        {
                            server.SetIsFinalServer(true);
                        }
                    }
                    servers[row, col] = server;
                }
            }
            return servers;
        }

    }
}
