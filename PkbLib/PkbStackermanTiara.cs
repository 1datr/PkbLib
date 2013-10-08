using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PkbLib
{
    public partial class PkbStackermanTiara : Stackerman
    {
        public PkbStackermanTiara()
        {
            InitializeComponent();
        }

        public PkbStackermanTiara(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
