using System.Reflection;
using Caticket.SalesAPI.Domain.Exceptions;

namespace Caticket.SalesAPI.Domain.Enumerators;

public abstract class Enumeration(string name, int id) : IComparable
{
    public string Name {get; set;} = name;
    public int Id {get; set;} = id;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration {
        FieldInfo[] fields = typeof(T).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        return fields.Select(f => f.GetValue(null)).Cast<T>();
    }

    public static bool IsValid<T>(string name) where T : Enumeration 
        => GetAll<T>().Any(t => t.Name == name);

    public static T From<T>(string name) where T : Enumeration {
        if(IsValid<T>(name)) {
            T type = GetAll<T>().FirstOrDefault(t => t.Name == name) ?? throw new InvalidEnumerationException(nameof(T));
            return type;
        } else {
            throw new InvalidEnumerationException(nameof(T));
        }
    }

    public int CompareTo(object? obj) 
        => obj == null ? 0 : Id.CompareTo(((Enumeration)obj).Id);

    public override bool Equals(object? obj)
    {
        if(obj == null || obj is not Enumeration enumeration) return false;

        bool flag = GetType().Equals(obj.GetType());
        bool flag2 = Id.Equals(enumeration.Id);
        return flag && flag2;
    }

    public override int GetHashCode()
        => Id.GetHashCode();

    public override string ToString()
        => Name;
    
}