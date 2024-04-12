using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProject
{
    internal class Car
    {
        public char carType;
        public int carD;
        public bool onInter;
        Random random = new Random();
        public int carX;
        public int carY;

        public Car (int x, int y, char c)
        {
            carX = x;
            carY = y;
            carType = c;

            if (Globals.Gameboard[x, y] == Globals.roadPiece)
            {
                if (carType == 'p')
                {
                    Globals.Gameboard[x, y] = Globals.carUpPiece;
                }
                else if (carType == 'n')
                {
                    Globals.Gameboard[x, y] = Globals.carUpPiece;
                }
            }
        }

        public void spawnCar(int x, int y, char c)
        {
            carType = c;
            carX = x;
            carY = y;

            if (Globals.Gameboard[x, y] == Globals.roadPiece)
            {
                if (c == 'p')
                {
                    Globals.Gameboard[x, y] = Globals.carUpPiece;
                }
                else if (c == 'n')
                {
                    Globals.Gameboard[x, y] = Globals.carUpPiece;
                }
            }
        }

        /// <summary>
        ///  
        /// Get Cars location at the beginning of every tick
        /// Check if the car is at an intersection
        /// If the car is not at an intersection, continue going forwards until an intersection is hit
        /// if the car is at an intersection, list all possible ways to move, excluding going backwards.
        /// Have a random number generated with the total number of ways to move, move the car said way.
        /// Use the parameters, no need to use -1 or +1 to move the vehicle.
        /// 
        /// </summary>
        /// <param name="h"> horizontal </param>
        /// <param name="v"> vertical </param>
        /// <param name="d"></param>
        public void moveCar(int h, int v, char d)
        {
            // Not working properly currently

            /*  Console.WriteLine(carX + " " + carY);
              if (Globals.Gameboard[carX - h, carY - v] != Globals.intersectionPiece)
              {
                  Globals.Gameboard[carX - h, carY - v] = Globals.carUpPiece;
                  Globals.Gameboard[carX - h, carY] = Globals.roadPiece;
                  Console.WriteLine("moving car");
                  carY--;
              }

              else if (Globals.Gameboard[carX - h, carY - v] == Globals.intersectionPiece)
              {
                  Globals.Gameboard[carX - h, carY - v] = Globals.carUpPiece;
                  Globals.Gameboard[carX, carY] = Globals.roadPiece;
                  onInter = true;
                  Console.WriteLine("On intersection");
              }*/

            int ranChoice = 0;
            if (carType == 'p')
            {

            }
            else if (carType == 'n')
            {
                if (Globals.Gameboard[carX, carY] == Globals.carUpPiece)
                {
                    if (Globals.Gameboard[carX, carY - 1] == Globals.roadPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                        carY--;
                    }
                    else if (Globals.Gameboard[carX, carY - 1] == Globals.intersectionPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                        carY--;
                        onInter = true;
                    }

                    if (onInter == true)
                    {
                        if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX, carY - 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }

                        int turn = random.Next(1, ranChoice + 1);


                        if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }

                            else if (turn == 3)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                        }
                        else if (Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece && Globals.Gameboard[carX - 1, carY] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                        }
                        else if (Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece && Globals.Gameboard[carX - 1, carY] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carRightPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX + 1, carY] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                            carX--;
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                            carY--;
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                            carX++;
                        }
                        onInter = false;

                    }
                }
                else if (Globals.Gameboard[carX, carY] == Globals.carDownPiece)
                {
                    if (Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                        carY++;
                    }
                    else if (Globals.Gameboard[carX, carY + 1] == Globals.intersectionPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                        carY++;
                        onInter = true;
                    }

                    if (onInter == true)
                    {
                        if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }

                        int turn = random.Next(1, ranChoice + 1);


                        if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }

                            else if (turn == 3)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carRightPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece && Globals.Gameboard[carX + 1, carY] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                            carX--;
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece && Globals.Gameboard[carX + 1, carY] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                            carY++;
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece && Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                            carX++;
                        }
                        onInter = false;

                    }
                }
                else if (Globals.Gameboard[carX, carY] == Globals.carLeftPiece)
                {
                    if (carX == 0)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        carX = 11;
                        carY = 8;
                        Globals.Gameboard[carX, carY] = Globals.carLeftPiece;
                    }
                    if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                        carX--;
                    }
                    else if (Globals.Gameboard[carX - 1, carY] == Globals.intersectionPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                        carX--;
                        onInter = true;
                    }
                    else if (onInter == true)
                    {
                        if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX, carY - 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }

                        int turn = random.Next(1, ranChoice + 1);


                        if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 3)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                                carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                        }
                        else if (Globals.Gameboard[carX - 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX - 1, carY] = Globals.carLeftPiece;
                            carX--;
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                            carY++;
                        }
                        else if (Globals.Gameboard[carX - 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                            carY--;
                        }
                        onInter = false;

                    }
                }
                else if (Globals.Gameboard[carX, carY] == Globals.carRightPiece)
                {
                    if (carX == 11)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        carX = 0;
                        carY = 4;
                        Globals.Gameboard[carX, carY] = Globals.carLeftPiece;
                    }
                    if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                        carX++;
                    }
                    else if (Globals.Gameboard[carX + 1, carY] == Globals.intersectionPiece)
                    {
                        Globals.Gameboard[carX, carY] = Globals.roadPiece;
                        Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                        carX++;
                        onInter = true;
                    }
                    else if (onInter == true)
                    {
                        if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX, carY - 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }

                        int turn = random.Next(1, ranChoice + 1);


                        if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {

                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                            else if (turn == 3)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                        }
                        else if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;

                            }
                        }
                        else if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                                carX++;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                        }
                        else if (Globals.Gameboard[carX + 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                                carY--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                                Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                                carY++;
                            }
                        }
                        else if (Globals.Gameboard[carX + 1, carY] == Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX + 1, carY] = Globals.carRightPiece;
                            carX++;
                        }
                        else if (Globals.Gameboard[carX + 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] != Globals.roadPiece && Globals.Gameboard[carX, carY + 1] == Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX, carY + 1] = Globals.carDownPiece;
                            carY++;
                        }
                        else if (Globals.Gameboard[carX + 1, carY] != Globals.roadPiece && Globals.Gameboard[carX, carY - 1] == Globals.roadPiece && Globals.Gameboard[carX, carY + 1] != Globals.roadPiece)
                        {
                            Globals.Gameboard[carX, carY] = Globals.intersectionPiece;
                            Globals.Gameboard[carX, carY - 1] = Globals.carUpPiece;
                            carY--;
                        }
                        onInter = false;

                    }

                }
            }
        }
    }
}