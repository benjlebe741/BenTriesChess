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
      public Tile(Point _point,Color _backcolor, int _number, string name) 
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = _backcolor;
            pictureBox.Width = pictureSize;
            pictureBox.Height = pictureSize;
            pictureBox.Location = _point;
            
            pictureBox.MouseClick += PictureBox_MouseClick;
        number = _number;
            peiceName = name;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
           Form1.currentTile = number;
        }
    }
}
