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

namespace BenTriesChess
{
    public partial class Form1 : Form
    {
        //Board Width
        int boardWidth = 8;
        new Tile testTile = new Tile(new Point(12,12),Color.SaddleBrown);
        new PictureBox pictureBox = new PictureBox();

        //Array: - Board Layout - Availible Spaces to Move - Physical instances of each tile as a PictureBox
        Image[] boardLayout = new Image[] {
Resources.BlackRook,Resources.BlackHorse,Resources.BlackBishop,Resources.BlackKing,Resources.BlackQueen,Resources.BlackBishop,Resources.BlackHorse,Resources.BlackRook,
Resources.BlackPawn,Resources.BlackPawn,Resources.BlackPawn,Resources.BlackPawn,Resources.BlackPawn,Resources.BlackPawn,Resources.BlackPawn,Resources.BlackPawn,
Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,
Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,
Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,
Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,Resources.Empty,
Resources.WhitePawn,Resources.WhitePawn,Resources.WhitePawn,Resources.WhitePawn,Resources.WhitePawn,Resources.WhitePawn,Resources.WhitePawn,Resources.WhitePawn,
Resources.WhiteRook,Resources.WhiteHorse,Resources.WhiteBishop,Resources.WhiteKing,Resources.WhiteQueen,Resources.WhiteBishop,Resources.WhiteHorse,Resources.WhiteRook,
        };


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

        #region allTiles
        Tile[] tileArray = new Tile[] {
        new Tile(new Point(12,12),Color.SaddleBrown),
         new Tile(new Point(118, 12),Color.White),
        new Tile(new Point(224,12),Color.SaddleBrown),
         new Tile(new Point(330, 10),Color.White),
         //        new Tile(new Point(436,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
         //        new Tile(new Point(12,12),Color.SaddleBrown),
         //new Tile(new Point(10, 10),Color.White),
        };
        #endregion
        public Form1()
        {
            InitializeComponent();
            updateDisplay();
        }

        void updateDisplay()
        {
            for (int x = 0; x <= tileArray.Length - 1; x++)
            {
                tileArray[x].pictureBox.Image = boardLayout[x];
                if (availibleSpace[x] == true) { tileArray[x].pictureBox.BackgroundImage = Resources.CanMoveHere; }
                else { tileArray[x].pictureBox.BackgroundImage = Resources.Empty; }
              
                //testing
                testTile.pictureBox.Size = A1.Size;
                testTile.pictureBox.Location = new Point(12,12);
                testTile.pictureBox.BackColor = Color.White;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void updateDisplayTestButton_Click(object sender, EventArgs e)
        {
            updateDisplay();
        }
    }
}
