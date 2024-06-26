﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationProject
{
    public partial class Form1 : Form
    {
        string[,] board;
        
        Size gridSize = new Size(); // 12 cells wide and tall
        Size cellSize = new Size(40, 40); // each cell will be 40px wide/tall
        Point currentPoint;
        List<Emergency> listOfEmergencies = new List<Emergency>();
        List<Car> activeCars = new List<Car>();

        public Form1()
        {
            InitializeComponent();
        }

        private void createGrid()
        {
            for (int row = 0; row < gridSize.Height; row++)
            {
                for (int col = 0; col < gridSize.Width; col++)
                {
                    // board[row, col] = "";
                    Globals.Gameboard[row, col] = Globals.housePiece;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;

            newEmergency();

            Console.WriteLine("Should be moving");
        }

        private void newEmergency()
        {
            Random random = new Random();

            // 25% chance of an emergency spawning every second
            int emergencyChecker = random.Next(1, 3);

            if (emergencyChecker == 1)
            {
                Emergency emergency = new Emergency();
                string emer = emergency.getRegEmergency();
                emergency.AssignHouse();
                string address = emergency.getRandomAddress();
                listOfEmergencies.Add(new Emergency(false, 1, emer, address));
                label3.Text = $"{emer} at {address} at the coordinates {emergency.getLocationOnMap()}";
                DisplayEmergencies();
            }
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            int elapsedTime = 0;
            int numberOfCars = 0;

            Console.WriteLine($"Time elapsed: {elapsedTime += 1}");

            for (int i = 0; i < activeCars.Count; i++)
            {
                activeCars[i].moveCar(0, 0, 'u');
                Console.WriteLine($"Cars active on the road: {numberOfCars += 1}");
            }

            Invalidate();
        }

        private void DisplayEmergencies()
        {
            for (int i = 0; i < listOfEmergencies.Count; i++)
            {
                Console.WriteLine($"{listOfEmergencies[i].getEmergencyText()} at {listOfEmergencies[i].getEmergencyLocation()} at the coordinates {listOfEmergencies[i].getLocationOnMap()}");
            }
        }

        private void readMap()
        {
            string lineOfText = null;
            int level = 0;

            StreamReader mapFile = new StreamReader("../../Map.txt");
            while (!mapFile.EndOfStream)
            {
                lineOfText = mapFile.ReadLine();
                if (lineOfText[0] == '-') continue;//This will skip this line of text
                lineOfText = mapFile.ReadLine();//This will have our col and rows
                string[] data = lineOfText.Split(',');
                gridSize.Width = Convert.ToInt16(data[0]);
                gridSize.Height = Convert.ToInt16(data[1]);
                Globals.Gameboard = new Pieces[gridSize.Width * cellSize.Width, gridSize.Height * gridSize.Height];
                
                for (int row = 0; row < gridSize.Height; row++)
                {
                    lineOfText = mapFile.ReadLine();
                    for (int col = 0; col < lineOfText.Length; col++)
                    {
                        SetCell(col, row, lineOfText[col]);
                    }
                }
            }

            mapFile.Close();
            this.CenterToScreen();
            this.Invalidate();
        }

        private void SetCell(int x, int y, char character)
        {
            if (character.Equals('h'))
            {
                Globals.Gameboard[x, y] = Globals.housePiece;
            }

            else if (character.Equals('r'))
            {
                Globals.Gameboard[x, y] = Globals.roadPiece;
            }

            else if (character.Equals('g'))
            {
                Globals.Gameboard[x, y] = Globals.grassPiece;
            }

            else if (character.Equals('c'))
            {
                Globals.Gameboard[x, y] = Globals.carUpPiece;
            }

            else if (character.Equals('i'))
            {
                Globals.Gameboard[x, y] = Globals.intersectionPiece;
            }

            else if (character.Equals('p'))
            {
                Globals.Gameboard[x, y] = Globals.policeStationPiece;
            }

            else if (character.Equals(' '))
            {

            }

          //  car.spawnCar(1, 7, 'n');
           // car2.spawnCar(10, 10, 'n');
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readMap();
            board = new string[gridSize.Width * cellSize.Width, gridSize.Height * cellSize.Height];
            timer1.Start();
            refresh.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            activeCars.Add(new Car(1, 7, 'n'));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           // DoubleBuffered = true;

            Brush brush;

            e.Graphics.TranslateTransform(40, 40);

            /*for(int i = 0; i <= 12; i++)
            {
                e.Graphics.DrawLine(Pens.Black, i * 40, 0, i * 40, 500);
            }

            for (int i = 0; i <= 12; i++)
            {
                e.Graphics.DrawLine(Pens.Black, 500, i * 40, 0, i * 40);
            }*/

            for (int i = 0; i < gridSize.Width; i++)
            {
                for (int j = 0; j < gridSize.Height; j++)
                {
                    Rectangle destRect = new Rectangle(i * cellSize.Width, j * cellSize.Height, cellSize.Width, cellSize.Height);
                    Rectangle srcRect = new Rectangle(cellSize.Width, 0, cellSize.Width, cellSize.Height);

                    if (Globals.Gameboard[i, j] == null)
                    {
                        /*e.Graphics.DrawImage(grassPiece.getPieceImage(), destRect);*/
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "house")
                    {
                        e.Graphics.DrawImage(Globals.housePiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "grass")
                    {
                        e.Graphics.DrawImage(Globals.grassPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "road")
                    {
                        e.Graphics.DrawImage(Globals.roadPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "intersection")
                    {
                        e.Graphics.DrawImage(Globals.roadPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "yellowAlert")
                    {
                        e.Graphics.DrawImage(Globals.housePiece.getPieceImage(), destRect);
                        e.Graphics.DrawImage(Globals.yellowAlertPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "redAlert")
                    {
                        e.Graphics.DrawImage(Globals.housePiece.getPieceImage(), destRect);
                        e.Graphics.DrawImage(Globals.redAlertPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "policeStation")
                    {
                        Rectangle destRectP = new Rectangle(i * cellSize.Width, j * cellSize.Height, cellSize.Width * 2, cellSize.Height);
                        e.Graphics.DrawImage(Globals.grassPiece.getPieceImage(), destRectP);
                        e.Graphics.DrawImage(Globals.policeStationPiece.getPieceImage(), destRectP);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "carUp")
                    {
                        e.Graphics.DrawImage(Globals.roadPiece.getPieceImage(), destRect);
                        e.Graphics.DrawImage(Globals.carUpPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "carLeft")
                    {
                        e.Graphics.DrawImage(Globals.roadPiece.getPieceImage(), destRect);
                        e.Graphics.DrawImage(Globals.carLeftPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "carRight")
                    {
                        e.Graphics.DrawImage(Globals.roadPiece.getPieceImage(), destRect);
                        e.Graphics.DrawImage(Globals.carRightPiece.getPieceImage(), destRect);
                    }

                    else if (Globals.Gameboard[i, j].getPieceName() == "carDown")
                    {
                        e.Graphics.DrawImage(Globals.roadPiece.getPieceImage(), destRect);
                        e.Graphics.DrawImage(Globals.carDownPiece.getPieceImage(), destRect);
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Emergency Text Display
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EmergencyTrackbar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
