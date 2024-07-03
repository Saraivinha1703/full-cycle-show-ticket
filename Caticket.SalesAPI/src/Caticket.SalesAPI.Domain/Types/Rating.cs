namespace Caticket.SalesAPI.Domain.Types;

public class Rating {
    private Rating(string rate) { 
        Rate = rate;   
    }

    public string Rate { get; private set; } = null!;

    public static Rating G { get; private set; } = new("G");
    public static Rating PG { get; private set; } = new("PG");
    public static Rating PG13 { get; private set; } = new("PG-13");
    public static Rating R { get; private set; } = new("R");
    public static Rating NC17 { get; private set; } = new("NC-17");
}