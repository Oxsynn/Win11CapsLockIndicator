using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CapsLockIndicator
{
    public class CapsLockIndicatorContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        bool isOn = true;

        public CapsLockIndicatorContext()
        {
            //Initialize ContextMenu
            ContextMenuStrip mainContext = new ContextMenuStrip();

            //ToolStripMenuItem replaced MenuItem
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", CapsLockIndicator.Properties.Resources.RedX, new EventHandler(Exit));
            notifyIcon.Icon = CapsLockIndicator.Properties.Resources.GrayA;
            notifyIcon.ContextMenuStrip = mainContext;
            mainContext.Items.Add(exitMenuItem);

            //check Windows Capslock
            string msg;
            Icon trayIcon = CapsLockIndicator.Properties.Resources.GrayA;
            notifyIcon.Icon = trayIcon;
            notifyIcon.Visible = true;

            updateIcon();

            async Task updateIcon()
            {
                while (isOn)
                {
                    bool isCaps = Control.IsKeyLocked(Keys.CapsLock);

                    if (isCaps == true)
                    {
                        msg = "Caps is On";
                        trayIcon = CapsLockIndicator.Properties.Resources.GreenA;
                    }
                    else
                    {
                        msg = "Caps is Off";
                        trayIcon = CapsLockIndicator.Properties.Resources.GrayA;
                    }
                    notifyIcon.Icon = trayIcon;
                    notifyIcon.Text = msg;
                }
            }
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