using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CapsLockIndicator
{
    public class CapsLockIndicatorContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        private System.Windows.Forms.ContextMenuStrip contextMenu;

        public CapsLockIndicatorContext()
        {
            //Initialize Icons
            Image RedX = Image.FromFile(".\\Red X.png");
            Icon GrayA = new Icon(".\\Gray A.png");
            Icon GreenA = new Icon(".\\Green A.png");
            ContextMenuStrip mainContext = new ContextMenuStrip();


            //ToolStripMenuItem replaced MenuItem
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", RedX, new EventHandler(Exit));
            notifyIcon.Icon = GrayA;
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