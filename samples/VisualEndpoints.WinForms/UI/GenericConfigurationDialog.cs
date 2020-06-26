using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualEndpoints.WinForms.UI
{
    public partial class GenericConfigurationDialog<T> : Form
    {
        public GenericConfigurationDialog()
        {
            InitializeComponent();
            lblTypeName.Text = typeof(T).FullName;
        }
    }
}
