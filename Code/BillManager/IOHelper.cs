using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    class IOHelper
    {
        public int BaseOffsetX { get; private set; }
        public int LineSpacing { get; private set; }

        private int _offsetX;

        public IOHelper()
        {
            SetFormatOptions(new FormatOptions());
        }

        public void SetFormatOptions(FormatOptions options)
        {
            BaseOffsetX = options.IndentSize;
            LineSpacing = options.LineSpacing;
        }


        public void IncreaseIndent()
        {
            _offsetX += BaseOffsetX;
        }

        public void DecreaseIndent()
        {
            _offsetX -= BaseOffsetX;
        }

        public void WriteLine(string msg = "")
        {
            Console.WriteLine(new string(' ', _offsetX) + msg);

            Console.SetCursorPosition(0, Console.CursorTop + LineSpacing - 1);
        }

        public string ReadNonEmptyString(string msg) =>
            ReadAndParse<string>(msg, (input) =>
            {
                if (!string.IsNullOrWhiteSpace(input))
                    return (true, input);

                else
                    return (false, null);
            });

        public decimal ReadDecimal(string msg) =>
            ReadAndParse<decimal>(msg, (input) =>
            {
                if (decimal.TryParse(input, out decimal res))
                    return (true, res);

                else
                    return (false, 0);
            });

        public DateTime ReadDate(string msg) =>
            ReadAndParse<DateTime>(msg, (input) =>
            {
                if (DateTime.TryParseExact(input, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime res))
                    return (true, res);

                else
                    return (false, DateTime.MinValue);
            });

        public float ReadNonNegativeFloat(string msg) =>
           ReadAndParse<float>(msg, (input) =>
            {
                if (float.TryParse(input, out float res) && res >= 0)
                    return (true, res);

                else
                    return (false, 0);
            });

        public bool ReadBoolean(string msg) =>
            ReadAndParse<bool>(msg, (input) =>
            {
                return input switch
                {
                    "0" => (true, false),
                    "1" => (true, true),
                    _ => (false, false),
                };
            });

        public int ReadInt(string msg) =>
           ReadAndParse<int>(msg, (input) =>
           {
               if (int.TryParse(input, out int res))
                   return (true, res);

               else
                   return (false, 0);
           });

        public int ReadNonNegativeInt(string msg) =>
           ReadAndParse<int>(msg, (input) =>
           {
               if (int.TryParse(input, out int res) && res >= 0)
                   return (true, res);

               else
                   return (false, 0);
           });

        public int ReadIntWithCondition(string msg, Func<int, bool> condition) =>
            ReadAndParse<int>(msg, (input) =>
            {
                if (int.TryParse(input, out int res) && condition(res))
                    return (true, res);

                else
                    return (false, 0);
            });

        private T ReadAndParse<T>(string msg, Func<string, (bool success, T res)> tryParse)
        {
            string padding;
            string focus = ">>";
            if (_offsetX <= focus.Length)
            {
                padding = new string(' ', _offsetX);
                focus = "";
            }
            else
            {
                padding = new string(' ', _offsetX - focus.Length);
            }

            string shake = "";
            while (true)
            {
                Console.Write(focus + padding + msg);

                (bool success, T value) = tryParse(Console.ReadLine());

                int baseTop = Console.CursorTop;
                if (success)
                {
                    //xóa focus
                    if (_offsetX >= 2)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write(new string(' ', focus.Length));
                        Console.SetCursorPosition(0, Console.CursorTop + 1);
                    }

                    //xóa dòng báo lỗi nếu có
                    Console.Write(new string(' ', Console.WindowWidth));


                    //kéo màn hình xuống
                    Console.SetCursorPosition(0, baseTop + (Console.WindowHeight / 2));

                    Console.SetCursorPosition(0, baseTop + LineSpacing - 1);

                    return value;
                }

                shake = (shake == "") ? " " : "";
                Console.Write(padding + shake + "<!> Giá trị nhập không hợp lệ. <!> ");

                //xóa dòng msg phía trên
                Console.SetCursorPosition(0, baseTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, baseTop - 1);
            }
        }
    }
}
