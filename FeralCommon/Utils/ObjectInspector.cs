using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace FeralCommon.Utils;

[UsedImplicitly]
public class ObjectInspector
{
    private const BindingFlags DefaultBindingAttributes = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    private readonly List<Type> _detailedTypes = [];
    private readonly List<Type> _ignoredTypes = [];

    private BindingFlags _bindingAttributes = DefaultBindingAttributes;

    [UsedImplicitly]
    public ObjectInspector WithBindingAttributes(BindingFlags bindingAttributes)
    {
        _bindingAttributes = bindingAttributes;
        return this;
    }

    [UsedImplicitly]
    public ObjectInspector AddIgnoredTypes(params Type[] ignoredTypes)
    {
        _ignoredTypes.AddRange(ignoredTypes);
        return this;
    }

    [UsedImplicitly]
    public ObjectInspector AddIgnoredTypes(List<Type> ignoredTypes)
    {
        _ignoredTypes.AddRange(ignoredTypes);
        return this;
    }

    [UsedImplicitly]
    public ObjectInspector AddDetailedTypes(params Type[] detailedTypes)
    {
        _detailedTypes.AddRange(detailedTypes);
        return this;
    }

    [UsedImplicitly]
    public ObjectInspector AddDetailedTypes(List<Type> detailedTypes)
    {
        _detailedTypes.AddRange(detailedTypes);
        return this;
    }

    [UsedImplicitly]
    public void Inspect(object owner, List<InspectedItem> items)
    {
        Inspect(owner, "", items, [], 0);
    }

    [UsedImplicitly]
    public void Inspect(object owner, out List<InspectedItem> items)
    {
        Inspect(owner, "", items = [], [], 0);
    }

    private void Inspect(object owner, string ownerPath, ICollection<InspectedItem> items, List<object> visited, int depth)
    {
        var ownerType = owner.GetType();

        foreach (var info in ownerType.GetFields(_bindingAttributes))
        {
            var fieldType = info.FieldType;
            if (fieldType.IsByRef) continue;
            if (_ignoredTypes.Contains(fieldType)) continue;

            var fieldValue = info.GetValue(owner);
            if (fieldValue == owner || visited.Contains(fieldValue)) continue;
            visited.Add(fieldValue);
            var fieldPath = AppendPath(ownerPath, info.Name);
            items.Add(new InspectedItem(fieldPath, fieldType, fieldValue));
            if (_detailedTypes.Contains(fieldType) && fieldValue != null && depth <= 2) Inspect(fieldValue, fieldPath, items, visited, depth + 1);
        }

        foreach (var info in ownerType.GetProperties(_bindingAttributes))
        {
            var fieldType = info.PropertyType;
            if (fieldType.IsByRef) return;
            if (_ignoredTypes.Contains(fieldType)) continue;

            var fieldValue = info.GetValue(owner);
            if (fieldValue == owner || visited.Contains(fieldValue)) continue;
            visited.Add(fieldValue);
            var fieldPath = AppendPath(ownerPath, info.Name);
            items.Add(new InspectedItem(fieldPath, fieldType, fieldValue));
            if (_detailedTypes.Contains(fieldType) && fieldValue != null && depth <= 2) Inspect(fieldValue, fieldPath, items, visited, depth + 1);
        }
    }

    private static string AppendPath(string path, string name)
    {
        return string.IsNullOrEmpty(path) ? name : $"{path}.{name}";
    }

    [UsedImplicitly]
    public class InspectedItem(string path, Type type, object? value)
    {
        [UsedImplicitly] public readonly string Path = path;
        [UsedImplicitly] public readonly Type Type = type;
        [UsedImplicitly] public readonly object? Value = value;
    }
}
