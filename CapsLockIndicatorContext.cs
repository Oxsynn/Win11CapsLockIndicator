using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CapsLockIndicator
{
    public class CapsLockIndicatorContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();

        public CapsLockIndicatorContext()
        {
            //Initialize Icons
            //Image RedX = Image.FromFile("C:\\Test\\Red X.png");
            //Icon GrayA = new Icon("C:\\Test\\Gray A.ico");
            //Icon GreenA = new Icon(".\\Green A.ico");
            ContextMenuStrip mainContext = new ContextMenuStrip();


            //ToolStripMenuItem replaced MenuItem
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", CapsLockIndicator.Properties.Resources.RedX, new EventHandler(Exit));
            notifyIcon.Icon = CapsLockIndicator.Properties.Resources.GrayA;
            notifyIcon.ContextMenuStrip = mainContext;
            mainContext.Items.Add(exitMenuItem);
            notifyIcon.Visible = true;
        }


        void Exit(object sender, EventArgs e)
        {
            //Removing Icon before Exit
            notifyIcon.Visible = false;
            Application.Exit();
        }


    }
}