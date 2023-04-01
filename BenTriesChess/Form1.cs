using BenTriesChess.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        Image[] imageArray = new Image[] { Resources.Empty, Resources.BlackPawn,Resources.BlackRook, Resources.BlackHorse, Resources.BlackBishop, Resources.BlackKing, Resources.BlackQueen, Resources.WhitePawn, Resources.WhiteRook, Resources.WhiteHorse, Resources.WhiteBishop, Resources.WhiteKing, Resources.WhiteQueen, };
        string[] stringArray = new string[] {"Empty","BlackPawn","BlackRook","BlackHorse","BlackBishop","BlackKing","BlackQueen","WhitePawn","WhiteRook", "WhiteHorse", "WhiteBishop", "WhiteKing", "WhiteQueen", };




        bool[] availibleSpace = new bool[] {
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, false, false, false, false, false,
        false, false, false, true, true, false, false, false,
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

                Color paintThisColor = Color.SaddleBrown;

                while (widthCount > boardWidth)
                {
                    widthCount -= boardWidth;
                    heightCount++;
                    colorTracker++;
                }
                if (colorTracker % 2 == 0) { paintThisColor = Color.White; }
                tileArray.Add(new Tile(new Point(12 + (72 * widthCount), 12 + (72 * heightCount)), paintThisColor, i - 1, boardLayout[i-1]));
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
                tileArray[x].peiceName = Convert.ToString(tileArray[x].pictureBox.Image);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void updateDisplayTestButton_Click(object sender, EventArgs e)
        {
            tileClicked();
            updateDisplay();
        }

        public void tileClicked()
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
           if ("WhitePawn" == stringArray[7])
           {
                availibleSpace[currentTile - boardWidth] = true;
                label1.Text = $"{Convert.ToString(tileArray[currentTile].peiceName)}";
           }
        }
    }
}
