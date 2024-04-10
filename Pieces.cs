using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProject
{
    internal class Pieces
    {
        /// <summary>
        /// This class will provide the template for each piece in the game
        /// </summary>

        string _name;
        Bitmap _image;
        bool _hasEmergencyCurrently = false;

        public Pieces()
        {

        }

        public Pieces (string name, Bitmap image)
        {
            _name = name;
            _image = image;
        }

        public Pieces(string name, Bitmap image, bool hasEmergencyCurrently)
        {
            _name = name;
            _image = image;
            _hasEmergencyCurrently = hasEmergencyCurrently;
        }

        public string getPieceName()
        {
            return _name;
        }

        public void setPieceName(string name)
        {
            _name = name;
        }

        public Bitmap getPieceImage()
        {
            return _image;
        }

        public void setPieceImage(Bitmap image)
        {
            _image = image;
        }
    }
}
