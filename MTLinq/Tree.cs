using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTLinq
{
    public partial class Tree : Form
    {
        static Font mFont = new Font(new Font("Arial", 8), FontStyle.Bold);

        public Tree(Dictionary<String,Device> aDevices)
        {
            InitializeComponent();

            devices.BeginUpdate();
            devices.Nodes.Clear();
            foreach (KeyValuePair<String, Device> kvp in aDevices)
            {
                buildTree(devices.Nodes, kvp.Value);
            }
            devices.EndUpdate();
        }

        public void buildTree(TreeNodeCollection aNodes, Component aComponent)
        {
            TreeNode node = new TreeNode(aComponent.name);
            node.NodeFont = mFont;
            aNodes.Add(node);

            if (aComponent.dataItems() != null)
            {
                foreach (DataItem d in aComponent.dataItems())
                    node.Nodes.Add(new TreeNode(d.category + ":" + d.type + "[" + d.name + "]"));
            }

            if (aComponent.components() != null)
            {
                foreach (Component c in aComponent.components())
                {
                    buildTree(node.Nodes, c);
                }
            }
        }
    }
}
