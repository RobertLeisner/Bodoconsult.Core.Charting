using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Bodoconsult.Core.Charting.Util
{
    /// <summary>
    /// Extensions for <see cref="DataTable"/> objects
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Convert <see cref="DataTable"/> to a generic <see cref="IList{DataRow}"/>
        /// </summary>
        /// <param name="datatable">data table to convert</param>
        /// <returns>List with <see cref="DataRow"/> objects</returns>
        public static IList<DataRow> ToGenericList(this DataTable datatable)
        {
            return (from row in datatable.AsEnumerable()
                    select (row)).ToList();
        }

    }

}
