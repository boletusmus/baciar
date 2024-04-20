using System.Data.Common;

namespace baciar.meta.Model;

public static class ModelExtension
{
    public static string? GetNullableString(this DbDataReader reader, int index)
    {
        return reader.IsDBNull(index) ? null : reader.GetString(index);
    }
    public static long? GetNullableLong(this DbDataReader reader, int index)
    {
        return reader.IsDBNull(index) ? null : reader.GetInt64(index);
    }
    public static int? GetNullableInt(this DbDataReader reader, int index)
    {
        return reader.IsDBNull(index) ? null : reader.GetInt32(index);
    }
    public static short? GetNullableShort(this DbDataReader reader, int index)
    {
        return reader.IsDBNull(index) ? null : reader.GetInt16(index);
    }
    public static TableItem ReadTableItem(this DbDataReader reader)=>new TableItem(reader.GetString(0), reader.GetString(1));
    public static ViewItem ReadViewItem(this DbDataReader reader)=>new ViewItem(reader.GetString(0), reader.GetString(1), reader.GetString(2));
    public static CheckConstraintItem ReadCheckConstraintItem(this DbDataReader reader)=>new CheckConstraintItem(reader.GetString(0), reader.GetString(1), reader.GetString(2));
    public static GeneratedColumnDependencyItem ReadGeneratedColumnDependencyItem(this DbDataReader reader)=>new GeneratedColumnDependencyItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
    public static ColumnPrivilegesItem ReadColumnPrivilegesItem(this DbDataReader reader) => new ColumnPrivilegesItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4), reader.GetString(5), reader.GetString(6));
    public static ColumnItem ReadColumnItem(this DbDataReader reader)=>new ColumnItem(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetNullableString(4), reader.GetBoolean(5), reader.GetString(6), reader.GetNullableInt(7), reader.GetNullableInt(8), reader.GetNullableInt(9), reader.GetNullableInt(10), reader.GetNullableInt(11), reader.GetNullableInt(12), reader.GetBoolean(13));
}
