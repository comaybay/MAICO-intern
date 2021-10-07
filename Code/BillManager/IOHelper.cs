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
            ReadLineAndParse<string>(msg, (input) =>
            {
                if (!string.IsNullOrWhiteSpace(input))
                    return (true, input);

                else
                    return (false, null);
            });

        public decimal ReadDecimal(string msg) =>
            ReadLineAndParse<decimal>(msg, (input) =>
            {
                if (decimal.TryParse(input, out decimal res))
                    return (true, res);

                else
                    return (false, 0);
            });

        public DateTime ReadDate(string msg) =>
            ReadLineAndParse<DateTime>(msg, (input) =>
            {
                if (DateTime.TryParseExact(input, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime res))
                    return (true, res);

                else
                    return (false, DateTime.MinValue);
            });

        public float ReadNonNegativeFloat(string msg) =>
           ReadLineAndParse<float>(msg, (input) =>
            {
                if (float.TryParse(input, out float res) && res >= 0)
                    return (true, res);

                else
                    return (false, 0);
            });

        public bool ReadBoolean(string msg) =>
            ReadLineAndParse<bool>(msg, (input) =>
            {
                return input switch
                {
                    "0" => (true, false),
                    "1" => (true, true),
                    _ => (false, false),
                };
            });

        public int ReadInt(string msg) =>
           ReadLineAndParse<int>(msg, (input) =>
           {
               if (int.TryParse(input, out int res))
                   return (true, res);

               else
                   return (false, 0);
           });

        public int ReadNonNegativeInt(string msg) =>
           ReadLineAndParse<int>(msg, (input) =>
           {
               if (int.TryParse(input, out int res) && res >= 0)
                   return (true, res);

               else
                   return (false, 0);
           });

        public int ReadIntWithCondition(string msg, Func<int, bool> condition) =>
            ReadLineAndParse<int>(msg, (input) =>
            {
                if (int.TryParse(input, out int res) && condition(res))
                    return (true, res);

                else
                    return (false, 0);
            });

        public char ReadCharWithCondition(string msg, Func<char, bool> condition) =>
            ReadKeyAndParse<char>(msg, (input) =>
            {
                if (condition(input))
                    return (true, input);

                else
                    return (false, ' ');

            });

        private T ReadKeyAndParse<T>(string msg, Func<char, (bool success, T res)> tryParse) =>
            ReadAndParse<char, T>(msg, tryParse, () => Console.ReadKey().KeyChar);

        private T ReadLineAndParse<T>(string msg, Func<string, (bool success, T res)> tryParse) =>
            ReadAndParse<string, T>(msg, tryParse, () => Console.ReadLine());

        private PARSE_T ReadAndParse<READ_T, PARSE_T>(string msg, Func<READ_T, (bool success, PARSE_T res)> tryParse, Func<READ_T> readInput)
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

                int baseCursorTop = Console.CursorTop;
                READ_T input = readInput();
                Console.SetCursorPosition(Console.CursorLeft, baseCursorTop);

                (bool success, PARSE_T value) = tryParse(input);

                if (success)
                {
                    //xóa focus
                    if (_offsetX >= 2)
                    {
                        Console.SetCursorPosition(0, baseCursorTop);
                        Console.Write(new string(' ', focus.Length));
                    }

                    //xóa dòng báo lỗi nếu có
                    Console.SetCursorPosition(0, baseCursorTop + 1);
                    Console.Write(new string(' ', Console.WindowWidth));


                    //kéo màn hình xuống
                    Console.SetCursorPosition(0, baseCursorTop + (Console.WindowHeight / 2));

                    //quay về chỗ cũ và xuống dòng
                    Console.SetCursorPosition(0, baseCursorTop + LineSpacing);

                    return value;
                }

                shake = (shake == "") ? " " : "";
                Console.WriteLine();
                Console.Write(padding + shake + "<!> Giá trị nhập không hợp lệ. <!> ");

                //xóa dòng msg phía trên
                Console.SetCursorPosition(0, baseCursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, baseCursorTop);
            }
        }
    }
}
