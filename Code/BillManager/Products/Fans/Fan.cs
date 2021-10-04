using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManager.Products.Fans
{
    /// <summary>
    /// Do các subclass của Fan không có điểm chung cho nên class này chỉ dùng cho mục đích quản lý code thuộc loại product quạt. 
    /// </summary>
    abstract class Fan : Product
    {
        protected Fan(string id, string name, string placeOfManufacture) : base(id, name, placeOfManufacture)
        {
        }
    }
}
