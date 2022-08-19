using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 6;
        int y = 6;
        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> randomList = new List<int>();

            Random random = new Random();
            while (randomList.Count < 5)
            {
                int number = random.Next(0, 25);
                if (!randomList.Contains(number))
                {
                    randomList.Add(number);
                }
            }


            for (int i = 0; i < 25; i++)
            {
                Button btn = new Button();
                //Add a Click EventHandler
                btn.Click += new EventHandler(Btn_Click);
                btn.Name = i.ToString();
                btn.Width = 50;
                btn.Height = 50;
                btn.Left = (i % 5) * 50;
                btn.Top = (i / 5) * 50;
                btn.Enabled = !randomList.Contains(i);
                Controls.Add(btn);

            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {

            Button button = sender as Button;
            //button.Text = button.Name;
            int index = Convert.ToInt32(button.Name);
            int komsu = 0;

            //sol
            if (index % 5 != 0)
            {
                Button btn = (Button)Controls.Find((index - 1).ToString(), false)[0];
                if (btn.Enabled)
                {
                    komsu++;
                }
            }

            //sağ
            if (index % 5 != 4)
            {
                Button btn = (Button)Controls.Find((index + 1).ToString(), false)[0];
                if (btn.Enabled)
                {
                    komsu++;
                }
            }

            //yukarı
            if (index - 5 >= 0)
            {
                Button btn = (Button)Controls.Find((index - 5).ToString(), false)[0];
                if (btn.Enabled)
                {
                    komsu++;
                }
            }

            //aşağı
            if (index + 5 < 24)
            {
                Button btn = (Button)Controls.Find((index + 5).ToString(), false)[0];
                if (btn.Enabled)
                {
                    komsu++;
                }
            }
            button.Text = komsu.ToString();
        }
    }
}
