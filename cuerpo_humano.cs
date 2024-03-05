using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Formularios
{

    public partial class cuerpo_humano : Form
    {

        Graphics graphics;
        ArrayList coor_x;
        ArrayList coor_y;
        String coordenasx;
        String coordenasy;
        int x;
        int y;
        Pen pluma = new Pen(Color.Red, 5);
        public static String coox;
        public static String cooy;
        public static Byte[] bits;
        public static Bitmap datosrecibidos;

        public cuerpo_humano()
        {
            InitializeComponent();
            coor_x = new ArrayList();
            coor_y = new ArrayList();
            pictureBox1.Hide();
            this.cuerpo.Size = new System.Drawing.Size(476, 330);
            graphics = cuerpo.CreateGraphics();
            picvalor.Visible = false;
            pictureBox1.Visible = false;

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int sum = 0;
            x = e.X - 10;
            y = e.Y - 10;
            //////graphics.DrawRectangle(pluma, x, y, 20, 20);
            Rectangle[] recst = { new Rectangle(x, y, 20, 20) };

            graphics.DrawRectangle(pluma, recst[0]);
            coor_x.Add(x.ToString());
            coor_y.Add(y.ToString());


            sum++;
            //----------------------------


            //coor_x.Add(x.ToString());
            //coor_y.Add(y.ToString());



            coordenasx += x.ToString() + ",";
            coordenasy += y.ToString() + ",";

        }

        private void button1_Click(object sender, EventArgs e)
        {




        }
        private void button5_Click(object sender, EventArgs e)
        {

            cuerpo.Refresh();
            cuerpo.Image = picvalor.Image;





        }

        private void cuerpo_humano_Load(object sender, EventArgs e)
        {
            //cuerpo.Image = null;


            //Image x = infomedico.enviodatos;
            //cuerpo.Image = x;
        }



        private void btncargar_Click(object sender, EventArgs e)
        {


            try
            {
                cuerpo.Image = datosrecibidos;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);




            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                int xx;
                int yy;
                Bitmap canvas = new Bitmap(cuerpo.Image);
                for (int i = 0; i < canvas.Width; i++)
                {
                    for (int j = 0; j < canvas.Height; j++)
                    {
                        Color clr = canvas.GetPixel(i, j);
                        int red = clr.R;
                        int green = clr.G;
                        int blue = clr.B;
                        canvas.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                }

                Graphics g = Graphics.FromImage(canvas);
                string[] words = coordenasx.Split(',');
                string[] y2 = coordenasy.Split(',');
                for (int i = 0; i < words.Length - 1; i++)
                {
                    yy = int.Parse(y2[i]);
                    xx = Int32.Parse(words[i]);
                    Rectangle[] recst = { new Rectangle(xx, yy, 20, 20) };
                    graphics.DrawRectangle(pluma, recst[0]);
                    g.DrawRectangle(pluma, recst[0]);

                }
                //pluma.Dispose();
                //g.Dispose();

                pictureBox1.Image = canvas;
                pictureBox1.Show();
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                bits = ms.ToArray();


            }
            catch (Exception f) {
                MessageBox.Show("Error, Vuelva a intentarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
