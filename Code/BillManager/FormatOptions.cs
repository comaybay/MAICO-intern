using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    class FormatOptions
    {
        private int _indentSize = 4;
        private int _lineSpacing = 1;

        public int IndentSize
        {
            get => _indentSize;
            init
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(IndentSize), "must not be smaller than 0");

                _indentSize = value;
            }
        }

        public int LineSpacing
        {
            get => _lineSpacing;
            init
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(LineSpacing), "must not be smaller than 0");

                _lineSpacing = value;
            }
        }
    }
}
