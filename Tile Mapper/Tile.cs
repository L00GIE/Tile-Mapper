using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tile_Mapper;

namespace Tile_Mapper
{
    public partial class Tile : UserControl
    {
        [JsonIgnore]
        public Image image { get; set; }

        public int rotation = 0;
        public int imageIndex = 0;

        public Tile()
        {
            InitializeComponent();
        }

        private void Tile_Load(object sender, EventArgs e)
        {
            if(this.image != null)
                this.pictureBox1.Image = this.image;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        private void switchImage()
        {
            switch (this.imageIndex)
            {
                case 0: this.pictureBox1.Image = new Bitmap(Tiles.grass); break;
                case 1: this.pictureBox1.Image = new Bitmap(Tiles.dirt); break;
                case 2: this.pictureBox1.Image = new Bitmap(Tiles.dirtedge); break;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.imageIndex += 1;
                if (this.imageIndex >= Tiles.numtiles)
                    this.imageIndex = 0;
                switchImage();
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.rotation += 90;
                if (this.rotation > 270)
                    this.rotation = 0;
                Image rotoImage = pictureBox1.Image;
                rotoImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                this.pictureBox1.Image = rotoImage;
            }
            this.pictureBox1.Update();
        }
    }
}
