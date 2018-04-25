using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary.View
{
    public partial class ListControl: UserControl
    {
        public ListControl()
        {
            InitializeComponent();
            InitialControlHandlers();
        }
    }
}
