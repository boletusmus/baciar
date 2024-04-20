namespace baciar.meta.Model;

public record TableItem(string schema, string name);
public record ViewItem(string schema, string name, string definition);
public record CheckConstraintItem(string schema, string name, string definition);
public record GeneratedColumnDependencyItem(string schema, string name, string columnName, string generatedColumnName);
public record ColumnPrivilegesItem(string schema, string name, string columnName, string privilige, bool isGrantable, string grantor, string grantee);
public record ColumnItem(string schema, string name, string columnName, int position, string? columnDefault, bool isNullable, string dataType, int? characterLength, int? octetLength, int? numericPrecision, int? numericPrecisionRadix, int? numericScale, int? datetimePrecision, bool isIdentity);
