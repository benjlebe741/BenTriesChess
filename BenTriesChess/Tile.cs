using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenTriesChess
{
    internal class Tile
    {
        public PictureBox pictureBox = new PictureBox();
        
      public Tile(Point _point,Color _backcolor) 
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = _backcolor;
            pictureBox.Width = 100;
            pictureBox.Height = 100;
            pictureBox.Location = _point;
            pictureBox.Visible = true;
            pictureBox.Enabled = true;
        }
        void OnMouseDown()
        {
           pictureBox.BackColor = Color.AliceBlue;
        }
    }
}
