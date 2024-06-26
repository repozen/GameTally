﻿using GameTally.Helpers;
using GameTally.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTally.Forms
{
    public partial class Info : Form
    {
        public static string gamepath = "";
        public Info()
        {
            InitializeComponent();
            button1.Click += (sender, args) =>
            {
                Process.Start("explorer.exe", Path.GetDirectoryName(gamepath));
            };

            button2.Click += (sender, args) =>
            {
                if(MessageWindow.ShowL("Warning","Are you sure you want to reset the time?"))
                {
                    try
                    {
                        GlobalVariables.gamesTimeList[Path.GetFileNameWithoutExtension(gamepath)] = "0h 0m";
                        GameTime.Text = "Time Played 0h 0m";
                        SaveHelper.SaveToFile();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
                }
            };

            /// <summary>
            /// Set Mica title bar if windows version is 11
            /// </summary>
            if (WindowsVersionHelper.IsWindows11())
            {
                var preference = Convert.ToInt32(true);
                dwmapi.DwmSetWindowAttribute(this.Handle,
                                      dwmapi.DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                                      ref preference, sizeof(uint));
            }
        }
    }
}
