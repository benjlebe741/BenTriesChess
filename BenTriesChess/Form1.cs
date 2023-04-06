using BenTriesChess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BenTriesChess
{
    public partial class Form1 : Form
    {
        //Board Info
        int boardWidth = 8;
        public static int currentTile;
        public static int previousTile;

        string placingPeice;


        //Array: - Board Layout - Availible Spaces to Move - Physical instances of each tile as a PictureBox
        string[] boardLayout = new string[] {
"BlackRook","BlackHorse","BlackBishop","BlackKing","BlackQueen","BlackBishop","BlackHorse","BlackRook",
"BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn",
"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
"WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn",
"WhiteRook","WhiteHorse","WhiteBishop","WhiteKing","WhiteQueen","WhiteBishop","WhiteHorse","WhiteRook",
        };
//"BlackRook","BlackHorse","BlackBishop","BlackKing","BlackQueen","BlackBishop","BlackHorse","BlackRook",
//"BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn","BlackPawn",
//"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
//"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
//"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
//"Empty","Empty","Empty","Empty","Empty","Empty","Empty","Empty",
//"WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn","WhitePawn",
//"WhiteRook","WhiteHorse","WhiteBishop","WhiteKing","WhiteQueen","WhiteBishop","WhiteHorse","WhiteRook",

        Image[] imageArray = new Image[] { Resources.Empty, Resources.BlackPawn, Resources.BlackRook, Resources.BlackHorse, Resources.BlackBishop, Resources.BlackKing, Resources.BlackQueen, Resources.WhitePawn, Resources.WhiteRook, Resources.WhiteHorse, Resources.WhiteBishop, Resources.WhiteKing, Resources.WhiteQueen, };
        string[] stringArray = new string[] { "Empty", "BlackPawn", "BlackRook", "BlackHorse", "BlackBishop", "BlackKing", "BlackQueen", "WhitePawn", "WhiteRook", "WhiteHorse", "WhiteBishop", "WhiteKing", "WhiteQueen", };
        string[] whiteList = new string[] { "WhitePawn", "WhiteRook", "WhiteHorse", "WhiteBishop", "WhiteKing", "WhiteQueen" };
        string[] blackList = new string[] { "BlackPawn", "BlackRook", "BlackHorse", "BlackBishop", "BlackKing", "BlackQueen" };


        int[] horseMoves = new int[] {6, 10, 15, 17, -6, -10, -15, -17 };
        int[] horseDirections = new int[] {2,3,1,1,3,2,0,0,1,1,2,3,0,0,3,2,};

        int[] kingMoves = new int[] { -9, -8, -7, -1, +1, 7, 8, 9  };
        int[] kingDirections = new int[] { 0, 0, 0, 2, 3, 1, 1, 1, 2, 0, 3, 2, 3, 2, 1, 3 };

        bool[] availibleSpace = new bool[] {
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        };


        List<Tile> tileArray = new List<Tile> { };

        public Form1()
        {
            for (int i = 1; i <= 64; i++)
            {
                int heightCount = 0;
                int widthCount = i;
                int colorTracker = i;
                bool up = true;
                bool down = true;
                bool left = true;
                bool right = true;
                bool hasMoved = true;

                //is this the edge of the board?
                if (i <= 8) { up = false; }
                else if (i > 56) { down = false; }
                if (i % 8 == 0) { right = false; }
                else if((i + 7) % 8 == 0) { left = false; }

                Color paintThisColor = Color.SaddleBrown;

                while (widthCount > boardWidth)
                {
                    widthCount -= boardWidth;
                    heightCount++;
                    colorTracker++;
                }
                if (colorTracker % 2 == 0) { paintThisColor = Color.White; }
                if (boardLayout[i - 1] == "WhitePawn" || boardLayout[i - 1] == "WhiteKing" || boardLayout[i - 1] == "BlackPawn" || boardLayout[i - 1] == "BlackKing") 
                {hasMoved = false;}
                tileArray.Add(new Tile(new Point(12 + (72 * widthCount), 12 + (72 * heightCount)), paintThisColor, i - 1, boardLayout[i - 1], up, down, left, right, hasMoved));
            }
            InitializeComponent();
            updateDisplay();
        }

        void updateDisplay()
        {
            for (int x = 0; x <= tileArray.Count - 1; x++)
            {
                this.Controls.Add(tileArray[x].pictureBox);
                for (int y = 0; y <= imageArray.Length - 1; y++)
                {
                    if (tileArray[x].peiceName == stringArray[y])
                    {
                        tileArray[x].pictureBox.Image = imageArray[y];
                    }
                }

                if (availibleSpace[x] == true && tileArray[x].pictureBox.BackColor == Color.SaddleBrown) { tileArray[x].pictureBox.BackgroundImage = Resources.Dark; }
                else if (availibleSpace[x] == true && tileArray[x].pictureBox.BackColor == Color.White) { tileArray[x].pictureBox.BackgroundImage = Resources.Light; }
                else { tileArray[x].pictureBox.BackgroundImage = Resources.Empty; }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void updateDisplayTestButton_Click(object sender, EventArgs e)
        {
            tileClicked();
            updateDisplay();
        }

        public void tileClicked()
        {
            //IF THE PLAYER CHOOSES A PLACE FOR THE PEICE TO GO
            if (availibleSpace[currentTile] == true)
            {
                label1.Text += $"{previousTile}";
                boardLayout[previousTile] = "Empty";
                tileArray[previousTile].peiceName = "Empty";
                boardLayout[currentTile] = placingPeice;
                tileArray[currentTile].peiceName = placingPeice;
                resetAvailibleSpaces();
                currentTile = -1;
            }


            //IF THE PLAYER PICKS A NEW PEICE
            else if (availibleSpace[currentTile] == false)
            {

                placingPeice = tileArray[currentTile].peiceName;

                resetAvailibleSpaces();
                switch (tileArray[currentTile].peiceName)
                {
                    case "WhitePawn":
                        if (tileArray[currentTile].upDownLeftRight[0] == true)
                        {
                            pawnSpaceCheck(1, blackList);
                        }
                        break;

                    case "BlackPawn":
                        if (tileArray[currentTile].upDownLeftRight[1] == true)
                        {
                            pawnSpaceCheck(-1, whiteList);
                        }
                        break;

                    case "WhiteRook":
                        rookSpaceCheck(blackList);
                        break;
                    case "BlackRook":
                        rookSpaceCheck(whiteList);
                        break;
                    case "WhiteBishop":
                        bishopSpaceCheck(blackList);
                        break;
                    case "BlackBishop":
                        bishopSpaceCheck(whiteList);
                        break;
                    case "WhiteHorse":
                        horseSpaceCheck(blackList);
                        break;
                    case "BlackHorse":
                        horseSpaceCheck(whiteList);
                        break;
                    case "WhiteQueen":
                        bishopSpaceCheck(blackList);
                        rookSpaceCheck(blackList);
                        break;
                    case "BlackQueen":
                        bishopSpaceCheck(whiteList);
                        rookSpaceCheck(whiteList);
                        break;
                    case "WhiteKing":
                        kingSpaceCheck(blackList);
                        break;
                    case "BlackKing":
                        kingSpaceCheck(whiteList);
                        break;
                }

                //feed me info
                label1.Text = $"{Convert.ToString(tileArray[currentTile].peiceName)}";
                label1.Text += $"\n{Convert.ToString(tileArray[currentTile].upDownLeftRight[0])}, {Convert.ToString(tileArray[currentTile].upDownLeftRight[1])}";
                label1.Text += $"\n{Convert.ToString(tileArray[currentTile].upDownLeftRight[2])}, {Convert.ToString(tileArray[currentTile].upDownLeftRight[3])}";
            }
        }

        bool IsInArray_(string[] sampleArray, string sampleString) 
        {
            bool trueOrFalse = false;

        foreach (string _string in sampleArray) 
            { 
            if (_string == sampleString) 
                {
                    trueOrFalse = true; 
                }
            }
            return trueOrFalse;
        }

        void pawnSpaceCheck(int direction, string[] stringArray) 
        {
            if (tileArray[currentTile].upDownLeftRight[2] && IsInArray_(stringArray, tileArray[currentTile - boardWidth * direction - 1].peiceName) == true)
            { availibleSpace[currentTile - boardWidth * direction - 1] = true; }
            if (tileArray[currentTile].upDownLeftRight[3] && IsInArray_(stringArray, tileArray[currentTile - boardWidth * direction + 1].peiceName) == true)
            { availibleSpace[currentTile - boardWidth * direction + 1] = true; }

            if (tileArray[currentTile].upDownLeftRight[0] == true && tileArray[currentTile].upDownLeftRight[1] == true && tileArray[currentTile - boardWidth * direction].peiceName == "Empty")
            {
                if (tileArray[currentTile].hasMoved == false && tileArray[currentTile - (boardWidth * direction)].upDownLeftRight[0] == true && tileArray[currentTile - (boardWidth * direction)].upDownLeftRight[1])
                {
                    if (tileArray[currentTile - (boardWidth * 2) * direction].peiceName == "Empty")
                    {
                        availibleSpace[currentTile - (boardWidth * 2) * direction] = true;
                    }
                }
                availibleSpace[currentTile - boardWidth * direction] = true; 
            }


        }

        void CertainSpaceCheck(string[] stringArray, int one, int two, int range) 
        {
            if (tileArray[currentTile].upDownLeftRight[one] && tileArray[currentTile].upDownLeftRight[two] && (IsInArray_(stringArray, tileArray[currentTile + range].peiceName) == true || tileArray[currentTile + range].peiceName == "Empty"))
            { availibleSpace[currentTile + range] = true; }
        }
        void HorseCertainSpaceCheck(string[] stringArray, int one, int two, int range)
        {
            if (directionIsGood(one,1) == true && directionIsGood(two,0) == true && (IsInArray_(stringArray, tileArray[currentTile + range].peiceName) == true || tileArray[currentTile + range].peiceName == "Empty"))
            { availibleSpace[currentTile + range] = true; }
        }
        void rookSpaceCheck(string[] stringArray)
        {
            directionCheck(boardWidth, stringArray, 1, 1);
            directionCheck(boardWidth * -1, stringArray, 0, 0);
            directionCheck(1, stringArray, 3, 3);
            directionCheck(-1, stringArray, 2, 2);
        }

        void horseSpaceCheck(string[] stringArray) 
        {
            for (int y = 0; y < 8; y++)
            {
                HorseCertainSpaceCheck(stringArray, horseDirections[y], horseDirections[8 + y], horseMoves[y]);
            }
        }
        void kingSpaceCheck(string[] stringArray)
        {
            for (int y = 0; y < 8; y++)
            {
                CertainSpaceCheck(stringArray, kingDirections[y], kingDirections[8 + y], kingMoves[y]);
            }
        }

        void bishopSpaceCheck(string[] stringArray)
        {
            directionCheck(boardWidth + 1, stringArray, 1, 3);
            directionCheck(boardWidth - 1, stringArray, 1, 2);
            directionCheck(-1 * boardWidth + 1, stringArray, 0, 3);
            directionCheck(-1 * boardWidth - 1, stringArray, 0, 2);
        }

        bool directionIsGood(int direction, int stopAt) 
        {
            bool yesOrNo = true;
            for (int y = 0; y <= stopAt; y++) {
                int i = 0;
                switch (direction) 
                {
                    case 0: 
                        i = -8;
                    break;
                    case 1:
                        i = 8;
                    break;
                    case 2:
                        i = -1;
                    break;
                    case 3:
                        i = 1;
                    break;
                }

                if (tileArray[currentTile + (i * y)].upDownLeftRight[direction] != true) 
                { 
                    yesOrNo = false;
                    y = 100;
                }
            }
                        return yesOrNo;
        }
        void directionCheck(int numberOfTiles, string[] stringArray, int direction, int direction2) 
        {
            for (int tilePlace = 0; tilePlace < 19; tilePlace++)
            {
                if (tileArray[currentTile + (numberOfTiles * tilePlace)].upDownLeftRight[direction] == true && tileArray[currentTile + (numberOfTiles * tilePlace)].upDownLeftRight[direction2] == true)
                {
                    if (tileArray[currentTile + (numberOfTiles * tilePlace)].peiceName == "Empty") { availibleSpace[currentTile + (numberOfTiles * tilePlace)] = true; }
                    else if (IsInArray_(stringArray, tileArray[currentTile + (numberOfTiles * tilePlace)].peiceName))
                    {
                        availibleSpace[currentTile + (numberOfTiles * tilePlace)] = true;
                        tilePlace = 20;
                    }
                    else if (tilePlace != 0) { tilePlace = 20; }

                }
                else if(tileArray[currentTile + (numberOfTiles * tilePlace)].peiceName == "Empty" || IsInArray_(stringArray, tileArray[currentTile + (numberOfTiles * tilePlace)].peiceName)) 
                    {
                    availibleSpace[currentTile + (numberOfTiles * tilePlace)] = true;
                    tilePlace = 20;
                }
                else { tilePlace = 20; }
            }
        }

        void resetAvailibleSpaces()
        {
            availibleSpace = new bool[] {
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        };
        }

    
    }
}
