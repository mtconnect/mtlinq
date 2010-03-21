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
    public partial class Results : Form
    {
        public Results(List<Result> aData)
        {
            InitializeComponent();
            data.BeginUpdate();
            data.Columns.Add("Component", -2, HorizontalAlignment.Left);
            data.Columns.Add("Name", -2, HorizontalAlignment.Left);
            data.Columns.Add("Sequence", -2, HorizontalAlignment.Right);
            data.Columns.Add("Timestamp", -2, HorizontalAlignment.Left);
            data.Columns.Add("Value", -2, HorizontalAlignment.Left);

            foreach (Result res in aData)
            {
                ListViewItem item = new ListViewItem(res.dataItem.component.name);
                item.SubItems.Add(res.dataItem.name);
                item.SubItems.Add(res.sequence.ToString());
                item.SubItems.Add(res.timestamp.ToString());
                if (res is Event)
                    item.SubItems.Add(((Event)res).value);
                else if (res is Sample)
                    item.SubItems.Add(((Sample)res).value.ToString());
                data.Items.Add(item);
            }

            data.EndUpdate();
        }
    }
}
