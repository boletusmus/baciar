using System.Data.Common;

namespace baciar.meta.Model;

public static class ModelExtension
{
    public static TableItem ReadTableItem(this DbDataReader reader)=>new TableItem(reader.GetString(0), reader.GetString(1));
    public static ViewItem ReadViewItem(this DbDataReader reader)=>new ViewItem(reader.GetString(0), reader.GetString(1), reader.GetString(2));
}
