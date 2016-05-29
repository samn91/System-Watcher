using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace System_Watcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(program);
                t.IsBackground = true;
                t.Start();
            }
        }

        void program()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            fileSystemWatcher1.Path = folderBrowserDialog1.SelectedPath;
            fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.NotifyFilter |= NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.LastAccess | NotifyFilters.Size;

            while (true)
            {
                WaitForChangedResult w = fileSystemWatcher1.WaitForChanged(WatcherChangeTypes.All);
                label1.Text = w.Name + " " + w.ChangeType;
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
