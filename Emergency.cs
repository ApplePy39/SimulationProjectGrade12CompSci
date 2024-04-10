using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProject
{
    internal class Emergency
    {
        bool _criticalEmergency;
        UInt16 _numberOfCops;
        int _numberofEmergencies;
        private string _textOfEmergency;
        private string _locationOfEmergency;
        private int[,] _locationOnMap;

        List<string> regularEmergencyTextList = new List<string>()
        {
            "Robbery In Progress",
            "Multiple reports of speeding",
            "Bank robbery",
            "Car accident",
            "Neighbourhood dispute over fence",
            "Cat stuck on a tree",
            "Large fight in crowd",
            "Car has hit a traffic light",
        };

        List<string> criticalEmergencyTextList = new List<string>()
        { 
            "Shootout with police",
            "Protest has gone violent"
        };

        List<string> houseAdresses = new List<string>()
        {
            "203 Main Street",
            "5 Davis Lane",
            "95190 Christophe Roads",
            "156 Leannon Well",
            "155 Gislason Pike",
            "576 Emmerich Ferry",
            "7612 Ethelyn Mews",
            "865 Brendan Wells Suite 463",
            "95194 Frederick Squares Suite 963",
            "69714 Adan Port"
        };

        public Emergency() 
        {
            getRegEmergency();
        }

        public Emergency (int numberOfEmergencies) 
        {
            _numberofEmergencies = numberOfEmergencies;
        }
        
        /// <summary>
        /// Each emergency has a bool checking if it's serious, it needs the number of cops needed at
        /// the emergency, the text to display, and the address/location
        /// </summary>
        public Emergency(bool critEmergency, UInt16 numCops, string text, string location)
        {
            _criticalEmergency = critEmergency;
            _numberOfCops = numCops;
            _textOfEmergency = text;
            _locationOfEmergency = location;
        }

        public void setCriticalEmergency(bool answer)
        {
            _criticalEmergency = answer;
        }

        public bool getCriticalEmergency()
        {
            return _criticalEmergency;
        }

        public void setNumberOfCops(UInt16 num)
        {
            _numberOfCops = num;
        }

        public UInt16 getNumberOfCops()
        {
            return _numberOfCops;
        }

        public void setNumberOfEmergencies(int numOfEmergencies)
        {
            _numberofEmergencies = numOfEmergencies;
        }

        public int getNumberOfEmergencies()
        {
            return _numberofEmergencies;
        }

        public void setTextOfEmergency(string text)
        {
            _textOfEmergency = text;
        }

        public string getEmergencyText()
        {
            return _textOfEmergency;
        }

        public void setEmergencyLocation(string location) 
        {
            _locationOfEmergency = location;
        }

        public string getEmergencyLocation()
        {
            return _locationOfEmergency;
        }

        public void setlocationOnMap(int[,] location)
        {
            _locationOnMap = location;            
        }

        public int[,] getLocationOnMap()
        {
            return _locationOnMap;
        }

        public string getRandomAddress()
        {
            Random random = new Random();
            int item = random.Next(houseAdresses.Count());
            _locationOfEmergency = houseAdresses[item];
            return (string)houseAdresses[item];
        }

        public void AssignHouse()
        {
            Random random = new Random();
            int xCoord = random.Next(1, 12);
            int yCoord = random.Next(1, 12);
            Console.WriteLine($"x: {xCoord.ToString()}, y: {yCoord.ToString()}");
            
            if (Globals.Gameboard[xCoord, yCoord] == Globals.housePiece)
            {
                Globals.Gameboard[xCoord, yCoord] = Globals.redAlertPiece;
                _locationOnMap = new int[xCoord, yCoord];
            }

            else if (Globals.Gameboard[xCoord, yCoord] != Globals.housePiece)
            {
             //   getRandomHouse();
            }
        }

        public string getRegEmergency()
        {
            Random random = new Random();
            int item = random.Next(regularEmergencyTextList.Count());
            Console.WriteLine((string)regularEmergencyTextList[item]);
            _textOfEmergency = regularEmergencyTextList[(int)item];
            return (string)regularEmergencyTextList[item];
        }

        private bool CriticalEmergency()
        {
            Random random = new Random();
            int chance = random.Next(1, 10);
            if (chance == 1) 
            {
                _criticalEmergency = true;
            }

            else
            {
                _criticalEmergency = false;
            }

            return _criticalEmergency;
        }
    }
}
