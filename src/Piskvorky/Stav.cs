using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piskvorky
{
    /// <summary>
    /// Všechny stavy, ve který hra může být.
    /// </summary>
    enum Stav
    {
        /// <summary>Hráč 1 je na tahu. </summary>
        TAHNE1,
        /// <summary>Hráč 2 je na tahu. </summary>
        TAHNE2,
        /// <summary>Hráč 1 vyhrál hru. </summary>
        VYHRAL1,
        /// <summary>Hráč 2 vyhrál hru. </summary>
        VYHRAL2,
        /// <summary>Hra ještě nezačala. </summary>
        PRED_ZACATKEM
    }
}
