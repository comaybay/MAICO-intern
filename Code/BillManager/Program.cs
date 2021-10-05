using System;

namespace BillManager
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var inputFormatOptions = new FormatOptions()
            {
                IndentSize = 4,
                LineSpacing = 2,
            };

            var displayFormatOptions = new FormatOptions()
            {
                IndentSize = 1,
                LineSpacing = 1,
            };

            var app = new App
            (
                inputFormatOptions,
                displayFormatOptions,
                saveFileName: "danh_sach_hoa_don"
            );

            app.Run();
        }
    }
}
