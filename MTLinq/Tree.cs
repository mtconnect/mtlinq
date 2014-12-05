using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MTConnect;

namespace MTLinq
{
    public partial class Tree : Form
    {
        static Font mFont = new Font(new Font("Arial", 8), FontStyle.Bold);

        public Tree(Dictionary<String, Device> aDevices)
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

        public void buildTree(TreeNodeCollection aNodes, MTConnect.Component aComponent)
        {
            TreeNode node = new TreeNode(aComponent.Name);
            node.NodeFont = mFont;
            aNodes.Add(node);

            if (aComponent.DataItems() != null)
            {
                foreach (DataItem d in aComponent.DataItems())
                    node.Nodes.Add(new TreeNode(d.Category + ":" + d.Type + "[" + d.Name + "]"));
            }

            if (aComponent.Components() != null)
            {
                foreach (MTConnect.Component c in aComponent.Components())
                {
                    buildTree(node.Nodes, c);
                }
            }
        }
    }
}
