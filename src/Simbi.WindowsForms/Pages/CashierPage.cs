using Simbi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simbi.WindowsForms
{
    public partial class CashierPage : UserPage
    {
        public CashierPage(SignInManager signInManager) : base(signInManager)
        {
            InitializeComponent();
        }                     
    }
}
