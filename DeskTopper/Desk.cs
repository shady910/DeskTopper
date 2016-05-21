using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTopper
{
    class Desk
    {
            public int deskWidth { get; set; }
            public int deskLength { get; set; }
            public int noOfDrawers { get; set; }
            public int rushOrder { get; set; }
            public SurfaceMaterial deskTopType { get; set; }
            public int priceEstimate { get; set; }


        }
    public enum SurfaceMaterial
    {
        None,
        Oak,
        Laminate,
        Pine,
        Marble,
        Walnut,
        Metal
    };
}

