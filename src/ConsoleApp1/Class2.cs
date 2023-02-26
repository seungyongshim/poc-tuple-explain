using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1;

public static class Helper
{
    public static string ToTypeExplain(this object obj) =>
        string.Join(string.Empty, TypeExplain(obj.GetType()));

    public static IEnumerable<string> TypeExplain(Type t)
    {
        if (t.ReflectedType is not null)
        {
            foreach(var i in TypeExplain(t.ReflectedType))
            {
                yield return i;
            }
        }
        else if (Regex.IsMatch(t.Name, "^ValueTuple`.*", RegexOptions.Compiled))
        {
            yield return "(";
            yield return string.Join(", ", t.GenericTypeArguments.SelectMany(TypeExplain));
            yield return ")";
        }
        else if (t.IsGenericType)
        {
            yield return t.Name;

            yield return "<";
            yield return string.Join(", ", t.GenericTypeArguments.SelectMany(TypeExplain));
            yield return ">";

        }
        else
        {
            yield return t.Name;
        }
        
    }
}
