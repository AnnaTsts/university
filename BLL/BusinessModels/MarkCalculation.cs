using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class MarkCalculation
    {
        public static double CalculateMark(Book book)
        {
            double mark = 0;
            foreach (Mark m in book.Marks)
            {
                mark += m.Value;
            }
            mark /= book.Marks.Count;
            return mark;
        }
    }
}
