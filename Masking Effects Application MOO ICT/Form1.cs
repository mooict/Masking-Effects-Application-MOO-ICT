namespace Masking_Effects_Application_MOO_ICT
{
    // Made by MOO ICT
    // For educational purpose only
    public partial class Form1 : Form
    {

        Bitmap background_image;
        TextureBrush texture;
        List<Circle> circles = new List<Circle>();
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            LoadSettings(); 
        }

        private void LoadSettings()
        {
            this.BackgroundImage = Image.FromFile("vinland_saga_bg_bw.jpg");
            background_image = (Bitmap)Image.FromFile("vinland_saga_bg.jpg", true);
            texture = new TextureBrush(background_image);
            texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

            Point location = new Point(5, 5);

            for (int i = 0; i < 60; i++)
            {
                Circle temp_circle = new Circle();
                temp_circle.positionX = location.X;
                temp_circle.positionY = location.Y;
                circles.Add(temp_circle);
                location.X = rand.Next(10, 700);
                location.Y = rand.Next(10, 400);
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                this.BackgroundImage = Image.FromFile("vinland_saga_bg_bw.jpg");
                background_image = (Bitmap)Image.FromFile("vinland_saga_bg.jpg", true);
                texture = new TextureBrush(background_image);
            }
            if (e.KeyCode == Keys.S)
            {
                this.BackgroundImage = Image.FromFile("berserk_bw.jpg");
                background_image = (Bitmap)Image.FromFile("berserk.jpg", true);
                texture = new TextureBrush(background_image);
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Pen outline = new Pen(Color.White, 4);

            foreach (Circle temp_circle in circles)
            {
                e.Graphics.DrawEllipse(outline, temp_circle.circle);
                e.Graphics.FillEllipse(texture, temp_circle.circle);
            }

        }

        private void AnimationTimerEvent(object sender, EventArgs e)
        {
            foreach (Circle temp_circle in circles)
            {
                temp_circle.positionX += temp_circle.speedX;
                temp_circle.positionY += temp_circle.speedY;

                temp_circle.circle.X = temp_circle.positionX;
                temp_circle.circle.Y = temp_circle.positionY;

                if (temp_circle.circle.X < 0 || temp_circle.circle.X + temp_circle.circle.Width > this.ClientSize.Width)
                {
                    temp_circle.speedX = -temp_circle.speedX;
                }
                if (temp_circle.circle.Y < 0 || temp_circle.circle.Y + temp_circle.circle.Height > this.ClientSize.Height)
                {
                    temp_circle.speedY = -temp_circle.speedY;
                }
            }

            this.Invalidate();
        }
    }
}