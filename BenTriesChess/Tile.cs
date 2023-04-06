using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BenTriesChess;
using BenTriesChess.Properties;

namespace BenTriesChess
{
    internal class Tile
    {
        public PictureBox pictureBox = new PictureBox();
        int pictureSize = 72;
        int number;
        public string peiceName;
        public bool[] upDownLeftRight = new bool[4];
        public bool hasMoved;

        public Tile(Point _point,Color _backcolor, int _number, string name, bool up, bool down, bool left, bool right, bool _hasMoved) 
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = _backcolor;
            pictureBox.Width = pictureSize;
            pictureBox.Height = pictureSize;
            pictureBox.Location = _point;

            upDownLeftRight[0] = up;
            upDownLeftRight[1] = down;
            upDownLeftRight[2] = left;
            upDownLeftRight[3] = right;

            hasMoved = _hasMoved;

            pictureBox.MouseClick += PictureBox_MouseClick;
        number = _number;
            peiceName = name;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Form1.previousTile = Form1.currentTile;
            Form1.currentTile = number;
        }
    }
}
