using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager
{
    class BillDisplayer
    {
        private readonly IOHelper _ioHelper;

        public BillDisplayer(IOHelper ioHelper)
        {
            _ioHelper = ioHelper;
        }

        public void Display(Bill bill)
        {
            IList<string> billGeneralProps = new List<string>()
            {
                $"Mã hóa đơn: {bill.Id}",
                $"Ngày lập: {bill.DateCreated:dd/MM/yyyy}",
                $"Tổng giá: {bill.TotalPrice} nghìn vnđ"
            };

            IList<string> customerProps = bill.Customer.GetStringProps();

            var productPropsList = bill.BillDetailsList.Select(details => details.Product.GetStringProps())
                                                       .ToList();

            int maxStrLength = FindMaxStrLength();
            int maxWidth = maxStrLength + 4;

            DisplayHeader("HÓA ĐƠN");

            foreach (string prop in billGeneralProps)
                DisplayProp(prop);

            DisplayGap();

            DisplayHeader("Khách hàng");

            foreach (string prop in customerProps)
                DisplayProp(prop);

            DisplayGap();

            DisplayHeader("Chi tiết hóa đơn");

            for (int i = 0; i < productPropsList.Count; i++)
            {
                DisplayProp($"Chi tiết {i + 1}/{productPropsList.Count}");
                DisplayLineSmall();

                var props = productPropsList[i];

                //in các prop chung
                for (int j = 0; j < 4; j++)
                    DisplayProp(props[j]);

                DisplayGap();

                string priceStr = props[4];

                //in các prop cụ thể
                if (props.Count > 5)
                {
                    for (int j = 5; j < props.Count; j++)
                        DisplayProp(props[j]);

                    DisplayGap();
                }

                //in đơn giá và số lượng bán
                DisplayProp(priceStr);
                DisplayProp($"Số lượng bán ra: {bill.BillDetailsList[i].Quantity}");

                DisplayGap();

                if (i != productPropsList.Count - 1)
                    DisplayLineSmall();
            }

            DisplayLine();
            DisplayProp($"Tổng giá: {bill.TotalPrice} nghìn vnđ");
            DisplayLine();

            return;

            ///local functions
            int FindMaxStrLength()
            {
                var allProps = billGeneralProps.Concat(customerProps).Concat(productPropsList.SelectMany(props => props));
                return allProps.Max((str) => new StringInfo(str).LengthInTextElements);
            }

            void DisplayLine() => _ioHelper.WriteLine(new string('*', maxWidth));

            void DisplayLineSmall() => _ioHelper.WriteLine($"*{new string('-', maxWidth - 2)}*");

            void DisplayGap() => _ioHelper.WriteLine($"*{new string(' ', maxWidth - 2)}*");

            void DisplayProp(string prop)
            {
                int propLength = new StringInfo(prop).LengthInTextElements;
                string padding = new(' ', maxWidth - propLength - 4);
                _ioHelper.WriteLine($"* {prop}{padding} *");
            }

            void DisplayHeader(string title)
            {
                int titleLength = new StringInfo(title).LengthInTextElements;

                int half = (maxWidth - titleLength) / 2;
                int extra = ((maxWidth - titleLength) % 2 == 0) ? 0 : 1;

                string left = "*" + new string(' ', half - 1);
                string right = new string(' ', half - 1 + extra) + "*";

                DisplayLine();
                _ioHelper.WriteLine(left + title + right);
                DisplayLine();
            }
        }
    }
}
