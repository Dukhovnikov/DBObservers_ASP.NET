using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Observer_ASP.NET_Core_Current.Models
{
    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        MaximumPressureForceAsc, // по максимальная сила давления по возрастанию
        MaximumPressureForceDesc,    // по максимальная сила давления по убыванию
        WeightAsc, // по весу по возрастанию
        WeightyDesc // по весу по убыванию
    }
}
