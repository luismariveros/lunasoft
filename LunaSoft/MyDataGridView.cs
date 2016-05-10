using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunaSoft
{
    public class MyDataGridView : DataGridView
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                return;
            else
                base.OnKeyDown(e);
        }
    }
}
