using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tile_Mapper
{
    public partial class Form1 : Form
    {
        private List<Tile> tiles = new List<Tile>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void InitTiles()
        {
            for (int y = 0; y < tilesHigh.Value; y++)
            {
                for (int x = 0; x < tilesWide.Value; x++)
                {
                    Tile tile = new Tile();
                    tile.image = Tiles.grass;
                    tile.Width = (int)tileWidth.Value;
                    tile.Height = (int)tileHeight.Value;
                    tile.Location = new Point(tile.Width * x, tile.Height * y);
                    tiles.Add(tile);
                    splitContainer1.Panel2.Controls.Add(tile);
                }
            }
        }

        private void exportJson()
        {
            int[] indexes = new int[tiles.Count];
            int[] rotations = new int[tiles.Count];
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = tiles[i].imageIndex;
                rotations[i] = tiles[i].rotation;
            }
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>
            {
                { "tiles", indexes },
                { "rotations", rotations }
            };
            string json = JsonConvert.SerializeObject(data);
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\export.json";
            using (FileStream fs = File.Open(savepath, FileMode.Create))
            {
                byte[] bytes = new UTF8Encoding(true).GetBytes(json);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitTiles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Scale(new SizeF(1.1f, 1.1f));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Scale(new SizeF(0.9f, 0.9f));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exportJson();
        }
    }
}
