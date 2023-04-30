/**
*--------------------------------------------------------------------
* File name: {Map.cs}
* Project name: {Project 5 - Zork}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch lynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {4/29/2023}
* -------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zork_console_app
{
    public class Map
    {
        public string GenerateMap(Server[,] servers, int paulRow, int paulCol)
        {
            int numRows = servers.GetLength(0);
            int numCols = servers.GetLength(1);

            StringBuilder mapBuilder = new StringBuilder();
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Server server = servers[row, col];
                    if(server == null)
                    {
                        mapBuilder.Append("|___|");
                    }
                    else if (server.IsFinalServer())
                    {
                        mapBuilder.Append("|_E_|");
                    }
                    else if (row == paulRow && col == paulCol)
                    {
                        mapBuilder.Append("|_P_|");
                    }
                    else if (server.GetHasFirewall())
                    {
                        mapBuilder.Append("|_f_|");
                    }
                    else if (server.HasHack())
                    {
                        mapBuilder.Append("|_H_|");
                    }
                    else
                    {
                        mapBuilder.Append("|___|");
                    }
                }
                mapBuilder.AppendLine();
            }

            return mapBuilder.ToString();
        }

    }
}
