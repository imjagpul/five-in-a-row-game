using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piskvorky
{
    /// <summary>
    /// Znaky, které můžou být umístěny na políčku herní mapy.
    /// </summary>
    enum Policko
    {
        /// <summary>Nebyl umístěn žádný znak. </summary>
        PRAZDNO,
        /// <summary>Byl umístěn křížek. </summary>
        KRIZEK,
        /// <summary>Bylo umístěno kolečko. </summary>
        KOLECKO
    }
}
