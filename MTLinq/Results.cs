using System.Collections.Generic;
using System.Windows.Forms;

using MTConnect;

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
                ListViewItem item = new ListViewItem(res.DataItem.Component.Name);
                item.SubItems.Add(res.DataItem.Name);
                item.SubItems.Add(res.Sequence.ToString());
                item.SubItems.Add(res.Timestamp.ToString());
                if (res is Event)
                    item.SubItems.Add(((Event)res).Value);
                else if (res is Sample)
                    item.SubItems.Add(((Sample)res).Value.ToString());
                data.Items.Add(item);
            }

            data.EndUpdate();
        }
    }
}
