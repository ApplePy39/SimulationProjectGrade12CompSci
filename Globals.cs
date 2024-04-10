using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SimulationProject
{
    static class Globals
    {
        public static Pieces[,] Gameboard = new Pieces[12, 12];

        public static Pieces housePiece = new Pieces("house", new Bitmap("../../Bitmaps/house.png"));
        public static Pieces grassPiece = new Pieces("grass", new Bitmap("../../Bitmaps/grass.png"));
        public static Pieces roadPiece = new Pieces("road", new Bitmap("../../Bitmaps/roadmain.png"));
        public static Pieces carUpPiece = new Pieces("carUp", new Bitmap("../../Bitmaps/carUp.png"));
        public static Pieces carRightPiece = new Pieces("carRight", new Bitmap("../../Bitmaps/carRight.png"));
        public static Pieces carDownPiece = new Pieces("carDown", new Bitmap("../../Bitmaps/carDown.png"));
        public static Pieces carLeftPiece = new Pieces("carLeft", new Bitmap("../../Bitmaps/carLeft.png"));
        public static Pieces intersectionPiece = new Pieces("intersection", new Bitmap("../../Bitmaps/intersection.png"));
        public static Pieces yellowAlertPiece = new Pieces("yellowAlert", new Bitmap("../../Bitmaps/yellowAlert.png"));
        public static Pieces redAlertPiece = new Pieces("redAlert", new Bitmap("../../Bitmaps/redAlert.png"));
        public static Pieces policeStationPiece = new Pieces("policeStation", new Bitmap("../../Bitmaps/policeStation.png"));
        public static int carX;
        public static int carY;
    }
}
