using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CapsLockIndicator
{

    public class CapsLockIndicatorContext : ApplicationContext
    {
        

        NotifyIcon notifyIcon = new NotifyIcon();
        bool isOn = true;
        // initialize icon and text
        string msg;
        Icon trayIcon = CapsLockIndicator.Properties.Resources.WhiteA;

        //construct method that will run asynchronously to check if caps is on

        public bool getCaps()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                return true;
            }
            else return false;
        }
        
        async void updateIcon()
        {
            while (isOn)
            {
                bool isCaps = await Task.Run(() => getCaps());
                if (isCaps == true)
                {
                    msg = "Caps is On";
                    trayIcon = CapsLockIndicator.Properties.Resources.GreenA;
                }
                else
                {
                    msg = "Caps is Off";
                    trayIcon = CapsLockIndicator.Properties.Resources.WhiteA;
                }
                notifyIcon.Icon = trayIcon;
                notifyIcon.Text = msg;
                notifyIcon.Visible = true;
            }
        }
        public CapsLockIndicatorContext()
        {
            //Initialize ContextMenu
            ContextMenuStrip mainContext = new ContextMenuStrip();

            //ToolStripMenuItem replaced MenuItem
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", CapsLockIndicator.Properties.Resources.RedX, new EventHandler(Exit));
            notifyIcon.ContextMenuStrip = mainContext;
            mainContext.Items.Add(exitMenuItem);

            //check Windows Capslock
            notifyIcon.Icon = trayIcon;
            notifyIcon.Visible = true;

            Task.Run(() => updateIcon());
        }


        void Exit(object sender, EventArgs e)
        {
            //Removing Icon before Exit
            isOn = false;
            notifyIcon.Visible = false;
            Application.Exit();
        }


    }
}