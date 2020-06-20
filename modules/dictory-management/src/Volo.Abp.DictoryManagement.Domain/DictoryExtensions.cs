using System;
using System.Collections.Generic;
using System.Linq;

namespace Volo.Abp.DictoryManagement
{
    public static class DictoryManagementExtensions
    {
        public static List<DataItem> GetTree(List<DataItem> source, Guid? parentId = null)
        {
            var result = source.Where(i => i.ParentId == parentId).OrderBy(i => i.Sort).ToList();
            foreach (var item in result)
            {
                item.Children = GetTree(source, item.Id);
            }
            return result;
        }

        public static List<DataItem> ToTree(this List<DataItem> source, Guid? parentId = null)
        {
            return GetTree(source, parentId);
        }
    }
}
