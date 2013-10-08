using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;


namespace PkbLib
{
    public partial class CoordCalcer : Component
    {
        public CoordCalcer()
        {
            InitializeComponent();
        }

        public CoordCalcer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
