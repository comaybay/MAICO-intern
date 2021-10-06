using BillManager.Products;
using BillManager.Products.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    class App
    {

        private IList<Bill> _bills = new List<Bill>();

        private readonly IOHelper _ioHelper;
        private readonly BillDisplayer _billDisplayer;

        private readonly FormatOptions _inputFormatOptions;

        private readonly FormatOptions _displayFormatOptions;

        private readonly string _saveFileName;

        public App(FormatOptions inputFormatOptions, FormatOptions displayFormatOptions, string saveFileName)
        {
            _inputFormatOptions = inputFormatOptions;

            if (displayFormatOptions.IndentSize < 1)
                throw new ArgumentOutOfRangeException(nameof(displayFormatOptions), $"{nameof(displayFormatOptions)} indent size must be >= 1");

            _displayFormatOptions = displayFormatOptions;

            _saveFileName = saveFileName;

            _ioHelper = new IOHelper();
            _billDisplayer = new BillDisplayer(_ioHelper);
        }

        public void Run()
        {
            AddBillThroughUserInput();
            DisplayBills();
            throw new NotImplementedException();
        }

        public void AddBillThroughUserInput()
        {
            _ioHelper.SetFormatOptions(_inputFormatOptions);

            int billCount = _ioHelper.ReadNonNegativeInt("Số lượng đơn muốn nhập (0 để thoát): ");

            for (int i = 1; i <= billCount; i++)
            {
                _ioHelper.WriteLine($"Nhập thông tin đơn {i}:");

                _ioHelper.IncreaseIndent();

                string billId = _ioHelper.ReadNonEmptyString("Mã hóa đơn: ");
                DateTime dateCreated = _ioHelper.ReadDate("Ngày lập hóa đơn (dd/mm/yyyy): ");

                _ioHelper.WriteLine("Thông tin khách hàng:");

                _ioHelper.IncreaseIndent();

                var customer = new Customer(
                    id: _ioHelper.ReadNonEmptyString("Mã khách hàng: "),
                    name: _ioHelper.ReadNonEmptyString("Tên khách hàng: "),
                    address: _ioHelper.ReadNonEmptyString("Địa chỉ: "),
                    phoneNumber: _ioHelper.ReadNonEmptyString("Số điện thoại: ")
                    );

                _ioHelper.DecreaseIndent();

                _ioHelper.WriteLine("Nhập danh sách các chi tiết hóa đơn:");

                IList<BillDetails> billDetailsList = ReadBillDetailsList();

                _bills.Add(new Bill(billId, dateCreated, customer, billDetailsList));

                _ioHelper.DecreaseIndent();
            }
        }

        private IList<BillDetails> ReadBillDetailsList()
        {
            _ioHelper.IncreaseIndent();

            int detailsCount = _ioHelper.ReadNonNegativeInt("Số lượng chi tiết trong danh sách các chi tiết hóa đơn: ");

            var billDetailsList = new List<BillDetails>(detailsCount);

            for (int i = 1; i <= detailsCount; i++)
            {
                _ioHelper.WriteLine($"Nhập chi tiết hóa đơn thứ {i}:");

                _ioHelper.IncreaseIndent();

                int choice = _ioHelper.ReadIntWithCondition(
                    "Chọn loại thiết bị điện (1-máy quạt, 2-máy lạnh): ",
                    (val) => val >= 1 && val <= 2
                    );

                ProductFactory productFactory = CreateProductFactory(choice);

                Product product = productFactory.CreateProductThroughUserInput();
                int quantity = _ioHelper.ReadNonNegativeInt("Nhập số lượng bán ra: ");

                billDetailsList.Add(new BillDetails(product, quantity));

                _ioHelper.DecreaseIndent();
            }

            _ioHelper.DecreaseIndent();

            return billDetailsList;
        }

        private ProductFactory CreateProductFactory(int choice) =>
            choice switch
            {
                1 => new FanFactory(_ioHelper),
                2 => new AirConditionerFactory(_ioHelper),
                _ => throw new NotImplementedException()
            };

        public void DisplayBills()
        {
            _ioHelper.SetFormatOptions(_displayFormatOptions);
            if (_bills.Count == 0)
            {
                Console.Clear();
                _ioHelper.IncreaseIndent();

                _ioHelper.WriteLine("Không có hóa đơn để xuất.");
                DisplayESCMessage();

                _ioHelper.DecreaseIndent();

                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                    continue;

                    return;
            }

            int index = 0;
            int prev = -1;
            int cursorLeft = _displayFormatOptions.IndentSize - 1;
            int maxCursorTop = -1;

            void DisplayInstructions()
            {
                DisplayESCMessage();
                _ioHelper.WriteLine("<> Bấm nút mũi tên trái/phải để chọn xem hóa đơn <>");
                _ioHelper.WriteLine("<> Bấm nút mũi tên lên/xuống hoặc lăn chuột để có thể xem hết hóa đơn <>");
                _ioHelper.WriteLine($"<- Hóa đơn thứ {index + 1}/{_bills.Count} ->");
            }

            while (true)
            {
                if (prev != index)
                {
                    Console.Clear();

                    _ioHelper.IncreaseIndent();

                    DisplayInstructions();
                    _ioHelper.WriteLine();

                    _billDisplayer.Display(_bills[index]);

                    _ioHelper.WriteLine();
                    DisplayInstructions();

                    _ioHelper.DecreaseIndent();

                    maxCursorTop = Console.CursorTop;
                    Console.SetCursorPosition(cursorLeft, 0);
                    Console.Write('\u25BC');
                    Console.SetCursorPosition(cursorLeft, 0);
                }

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                    return;

                int newCursorTop = key switch
                {
                    ConsoleKey.UpArrow => Math.Max(0, Console.CursorTop - 1),
                    ConsoleKey.DownArrow => Math.Min(maxCursorTop, Console.CursorTop + 1),
                    _ => Console.CursorTop,
                };

                if (newCursorTop != Console.CursorTop)
                {
                    Console.Write(' ');
                    Console.SetCursorPosition(cursorLeft, newCursorTop);
                    Console.Write(key == ConsoleKey.UpArrow ? '\u25B2' : '\u25BC');
                    Console.SetCursorPosition(cursorLeft, newCursorTop);
                }

                prev = index;
                index = key switch
                {
                    ConsoleKey.LeftArrow => Math.Max(0, index - 1),
                    ConsoleKey.RightArrow => Math.Min(_bills.Count - 1, index + 1),
                    _ => index,
                };
            }
        }

        public void DisplayESCMessage()
        {
            _ioHelper.WriteLine("<> Bấm ESC để quay lại <>.");
        }

        public void SaveBillsToFile()
        {
            throw new NotImplementedException();
        }

    }


}
