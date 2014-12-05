using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MTConnect;

namespace MTLinq
{
    public partial class Main : Form
    {
        MTConnect.MTConnect mConnect;

        public Main()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            mConnect = new MTConnect.MTConnect(agentURI.Text);
            Dictionary<String, Device> devs = mConnect.Probe();
            Tree t = new Tree(devs);
            t.Show();
        }

        private void current_Click(object sender, EventArgs e)
        {
            if (mConnect == null) mConnect = new MTConnect.MTConnect(agentURI.Text);
            List<Result> res = mConnect.Current();
            Results r = new Results(res);
            r.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
