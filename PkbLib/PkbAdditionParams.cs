using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PkbLib
{
    public partial class PkbAdditionParams : Component
    {
        public PkbAdditionParams()
        {
            InitializeComponent();
        }

        public PkbAdditionParams(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [DisplayName("Длина ячейки")]
        [Description("Длина ячейки в единицах, выдаваемых энкодером")]
        public int celllength { get; set; }
        [DisplayName("Ширина ячейки")]
        [Description("Ширина ячейки в единицах, выдаваемых энкодером")]
        public int cellwidth { get; set; }
        [DisplayName("Высота ячейки")]
        [Description("Высота ячейки в единицах, выдаваемых энкодером")]
        public int cellheight { get; set; }
    }
}
