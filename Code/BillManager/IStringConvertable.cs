using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    interface IStringConvertable
    {
        /// <summary>
        /// Chuyển các property bên trong của class thành các dòng string.
        /// </summary>
        public IList<string> GetStringProps();

        /// <summary>
        /// Chuyển giá trị của các property bên trong của class thành 1 dòng string.
        /// </summary>
        public string GetPropValuesAsSingleString();
    }
}
