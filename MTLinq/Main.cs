using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTLinq
{
    public partial class Main : Form
    {
        MTConnect mConnect;

        public Main()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            mConnect = new MTConnect(agentURI.Text);
            Dictionary<String, Device> devs = mConnect.probe();
            Tree t = new Tree(devs);
            t.Show();
         }

        private void current_Click(object sender, EventArgs e)
        {
            if (mConnect == null) mConnect = new MTConnect(agentURI.Text);
            List<Result> res = mConnect.current();
            Results r = new Results(res);
            r.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
