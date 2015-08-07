using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
    public static IEnumerable<T> Add<T>(this IEnumerable<T> e, T value)
    {
        foreach (var cur in e)
        {
            yield return cur;
        }
        yield return value;
    }
}