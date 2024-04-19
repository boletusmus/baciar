namespace baciar.meta.Model;

public record TableItem(string schema, string name);
public record ViewItem(string schema, string name, string definition);
