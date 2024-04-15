using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace FeralCommon.Utils;

[UsedImplicitly]
public static class FieldSearcher
{
    private const BindingFlags AttributeFilter = BindingFlags.Public | BindingFlags.NonPublic;
    private const BindingFlags StaticAttributeFilter = AttributeFilter | BindingFlags.Static;

    [UsedImplicitly]
    public static void Search<TType>(object from, out List<TType> fields)
    {
        fields = [];
        SearchInternal(from.GetType(), from, AttributeFilter, ref fields);
    }

    [UsedImplicitly]
    public static void Search<TType>(Type from, out List<TType> fields)
    {
        fields = [];
        SearchInternal(from, null, StaticAttributeFilter, ref fields);

        foreach (var nested in from.GetNestedTypes(StaticAttributeFilter)) SearchInternal(nested, null, StaticAttributeFilter, ref fields);
    }

    private static void SearchInternal<TType>(IReflect from, object? instance, BindingFlags filter, ref List<TType> fields)
    {
        foreach (var field in from.GetFields(filter))
            if (field.GetValue(instance) is TType value)
                fields.Add(value);
    }
}
