using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProject
{
    internal class Car
    {
        public char carType;
        public int carD;
        public bool onInter;

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

        public void moveCar(int h, int v, char d)
        {
            int ranChoice = 0;
            if (carType == 'p')
            {

            }
            else if (carType == 'n')
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

                        Random random = new Random();
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
            }
        }
    }
}
