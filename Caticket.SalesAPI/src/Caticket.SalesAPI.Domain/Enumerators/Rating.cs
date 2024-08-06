using System.Text.Json.Serialization;

namespace Caticket.SalesAPI.Domain.Enumerators;

public class Rating : Enumeration {
    
    [JsonConstructor]
    private Rating(string name, int id) : base(name, id) {}

    public static Rating G { get; private set; } = new("G", 0);
    public static Rating PG { get; private set; } = new("PG", 1);
    public static Rating PG13 { get; private set; } = new("PG-13", 2);
    public static Rating R { get; private set; } = new("R", 3);
    public static Rating NC17 { get; private set; } = new("NC-17", 4);

    public static void DefaultIfNull(ref Rating @this) 
        => @this ??= G;
}