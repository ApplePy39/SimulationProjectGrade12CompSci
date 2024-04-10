using System;
using System.Collections.Generic;
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

        public void spawnCar(int x, int y, char c)
        {
            carType = c;
            Globals.carX = x;
            Globals.carY = y;

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

            Console.WriteLine(Globals.carX + " " + Globals.carY);
            if (Globals.Gameboard[Globals.carX - h, Globals.carY - v] != Globals.intersectionPiece)
            {
                Globals.Gameboard[Globals.carX - h, Globals.carY - v] = Globals.carUpPiece;
                Globals.Gameboard[Globals.carX - h, Globals.carY] = Globals.roadPiece;
                Console.WriteLine("moving car");
                Globals.carY--;
            }

            else if (Globals.Gameboard[Globals.carX - h, Globals.carY - v] == Globals.intersectionPiece)
            {
                Globals.Gameboard[Globals.carX - h, Globals.carY - v] = Globals.carUpPiece;
                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.roadPiece;
                onInter = true;
                Console.WriteLine("On intersection");
            }

        /*    int ranChoice = 0;
            if (carType == 'p')
            {

            }*/
        /*   else if (carType == 'n')
            {
                if (Globals.Gameboard[Globals.carX, Globals.carY] == Globals.carUpPiece)
                {
                    if (Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.roadPiece)
                    {
                        Globals.Gameboard[Globals.carX, Globals.carY] = Globals.roadPiece;
                        Globals.Gameboard[Globals.carX, Globals.carY - 1] = Globals.carUpPiece;
                        Globals.carY--;
                    }
                    else if (Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.intersectionPiece)
                    {
                        Globals.Gameboard[Globals.carX, Globals.carY] = Globals.roadPiece;
                        Globals.Gameboard[Globals.carX, Globals.carY - 1] = Globals.carUpPiece;
                        Globals.carY--;
                        onInter = true;
                    }
                    else if (onInter == true)
                    {
                        if (Globals.Gameboard[Globals.carX - 1, Globals.carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }
                        if (Globals.Gameboard[Globals.carX + 1, Globals.carY] == Globals.roadPiece)
                        {
                            ranChoice++;
                        }

                        int turn = random.Next(1, ranChoice);


                        if (Globals.Gameboard[Globals.carX - 1, Globals.carY] == Globals.roadPiece && Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.roadPiece && Globals.Gameboard[Globals.carX + 1, Globals.carY] == Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX - 1, Globals.carY] = Globals.carLeftPiece;
                                Globals.carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX, Globals.carY - 1] = Globals.carUpPiece;
                                Globals.carY--;
                            }
                            else if (turn == 3)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX + 1, Globals.carY] = Globals.carRightPiece;
                                Globals.carX++;
                            }
                        }
                        else if (Globals.Gameboard[Globals.carX - 1, Globals.carY] == Globals.roadPiece && Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.roadPiece && Globals.Gameboard[Globals.carX + 1, Globals.carY] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX - 1, Globals.carY] = Globals.carLeftPiece;
                                Globals.carX--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX, Globals.carY - 1] = Globals.carUpPiece;
                                Globals.carY--;
                            }
                        }
                        else if (Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.roadPiece && Globals.Gameboard[Globals.carX + 1, Globals.carY] == Globals.roadPiece && Globals.Gameboard[Globals.carX - 1, Globals.carY] != Globals.roadPiece)
                        {
                            if (turn == 1)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX, Globals.carY - 1] = Globals.carUpPiece;
                                Globals.carY--;
                            }
                            else if (turn == 2)
                            {
                                Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                                Globals.Gameboard[Globals.carX + 1, Globals.carY] = Globals.carRightPiece;
                                Globals.carX++;
                            }
                        }
                        else if (Globals.Gameboard[Globals.carX - 1, Globals.carY] == Globals.roadPiece && Globals.Gameboard[Globals.carX, Globals.carY - 1] != Globals.roadPiece && Globals.Gameboard[Globals.carX + 1, Globals.carY] != Globals.roadPiece)
                        {
                            Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                            Globals.Gameboard[Globals.carX - 1, Globals.carY] = Globals.carLeftPiece;
                            Globals.carX--;
                        }
                        else if (Globals.Gameboard[Globals.carX - 1, Globals.carY] != Globals.roadPiece && Globals.Gameboard[Globals.carX, Globals.carY - 1] == Globals.roadPiece && Globals.Gameboard[Globals.carX + 1, Globals.carY] != Globals.roadPiece)
                        {
                            Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                            Globals.Gameboard[Globals.carX, Globals.carY - 1] = Globals.carUpPiece;
                            Globals.carY--;
                        }
                        else if (Globals.Gameboard[Globals.carX - 1, Globals.carY] != Globals.roadPiece && Globals.Gameboard[Globals.carX, Globals.carY - 1] != Globals.roadPiece && Globals.Gameboard[Globals.carX + 1, Globals.carY] == Globals.roadPiece)
                        {
                            Globals.Gameboard[Globals.carX, Globals.carY] = Globals.intersectionPiece;
                            Globals.Gameboard[Globals.carX + 1, Globals.carY] = Globals.carRightPiece;
                            Globals.carX++;
                        }
                        onInter = false;

                    }
                }
                else if (Globals.Gameboard[Globals.carX, Globals.carY] == Globals.carLeftPiece) 
                {
                    
                }
                else if (Globals.Gameboard[Globals.carX, Globals.carY] == Globals.carDownPiece)
                {

                }
                else if (Globals.Gameboard[Globals.carX, Globals.carY] == Globals.carRightPiece)
                {

                }
            } */
        }
    }
}