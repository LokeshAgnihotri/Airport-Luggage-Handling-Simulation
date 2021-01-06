using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace CartsSimulation2
{
    public partial class Form1 : Form
    {

        List<ProgressBar> carts;
        //Testing
        DispatcherTimer timer;
        int countluggages = 1;

        public Form1()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            carts = new List<ProgressBar>();
            carts.Add(pbCart1);
            carts.Add(pbCart2);
            carts.Add(pbCart3);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Testing  - count of luggages
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += new System.EventHandler(OnTimerEvent);
            timer.Start();
        }

        public void Testing() {
            if (countluggages >= 15)
            {

                if (carts.FirstOrDefault(x => x.Value == 0) != null)
                {
                    countluggages = countluggages - 15;
                    ProgressBar pb = carts.FirstOrDefault(x => x.Value == 0);
                    Processing p = new Processing(pb, this);
                }
            }

            lblTesting.Text = countluggages.ToString();
            countluggages++;
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            Testing();
        }
    }
}
