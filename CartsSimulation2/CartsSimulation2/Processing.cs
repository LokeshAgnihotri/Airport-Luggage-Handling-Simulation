using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartsSimulation2
{
    class Processing 
    {
        private ProgressBar pb;
        Form f;

        public Processing(ProgressBar pb,Form f)
        {
            this.f = f;
            this.pb = pb;

            Start(); 
        }

        public void Start()
        {
            var lTask = new Task(MainF);
            lTask.Start();
         }

        private void MainF()
        {
            for (int i = 0; i < 99; i++)
            {
                 try
                 {
                        Thread.Sleep(600);
                 }
                 catch (ThreadInterruptedException ex)
                 {
                    Console.WriteLine(ex);
                 }
              DoTheProcess();
                
            }
        }


        private void DoTheProcess()
        {
           try
           {
              if (pb.InvokeRequired)
              {
                  pb.Invoke(new Action(DoTheProcess));
                  return;
              }
                pb.Value += 1;
              if (pb.Value == 99)
                {
                    pb.Value = 0;
              }
            }
           catch (Exception ex)
           {
              MessageBox.Show(ex.ToString());
           }
        }
    }
}
