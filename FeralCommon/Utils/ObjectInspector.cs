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
    public void Inspect(object obj, out List<InspectedItem> items)
    {
        Inspect(obj, "", items = [], [obj], 0);
    }

    [UsedImplicitly]
    public void Diff<T>(T a, T b, out List<DiffItem> diffs)
    {
        Diff(a ?? throw new ArgumentNullException(nameof(a)), b, "", diffs = [], [], 0);
    }

    public static void PrintInspection(List<InspectedItem> items, string title = "No Details")
    {
        Log.Info("-----------------------------------------------------------------------");
        Log.Info($"Inspection: {title}");
        foreach (var item in items) Log.Info($"{item.Path} ({item.Type.Name}): {item.Value}");
        Log.Info("-----------------------------------------------------------------------");
    }

    public static void PrintDiff(List<DiffItem> items, string title = "No Details")
    {
        Log.Info("-----------------------------------------------------------------------");
        Log.Info($"Diff Inspection: {title}");
        foreach (var item in items)
            if (item.LeftValue == null)
                Log.Info($"{item.Path} ({item.RightValue!.GetType().Name}): null => {item.RightValue}");
            else if (item.RightValue == null)
                Log.Info($"{item.Path} ({item.LeftValue.GetType().Name}): {item.LeftValue} => null");
            else if (item.LeftValue.GetType() != item.RightValue.GetType())
                Log.Info($"{item.Path} ({item.LeftValue.GetType().Name} => {item.RightValue.GetType().Name}): {item.LeftValue} => {item.RightValue}");
            else
                Log.Info($"{item.Path} ({item.RightValue.GetType().Name}): {item.LeftValue} => {item.RightValue}");
        Log.Info("-----------------------------------------------------------------------");
    }

    private void Diff(object leftObj, object? rightObj, string path, ICollection<DiffItem> diffs, ICollection<object> visited, int depth)
    {
        var objType = leftObj.GetType();

        foreach (var info in objType.GetFields(_bindingAttributes))
        {
            var fieldType = info.FieldType;
            if (fieldType.IsByRef) continue;
            if (_ignoredTypes.Contains(fieldType)) continue;

            var leftValue = info.GetValue(leftObj);
            var rightValue = rightObj == null ? null : info.GetValue(rightObj);

            if (leftValue == leftObj || visited.Contains(leftValue)) continue;
            visited.Add(leftValue);

            if (leftValue == null && rightValue == null) continue;
            if (leftValue == rightValue) continue;
            if (leftValue != null && leftValue.Equals(rightValue)) continue;
            var fieldPath = AppendPath(path, info.Name);
            diffs.Add(new DiffItem(fieldPath, leftValue, rightValue));
            if (_detailedTypes.Contains(fieldType) && leftValue != null && depth <= 2)
                Diff(leftValue, rightValue, fieldPath, diffs, visited, depth + 1);
        }

        foreach (var info in objType.GetProperties(_bindingAttributes))
        {
            var fieldType = info.PropertyType;
            if (fieldType.IsByRef) continue;
            if (_ignoredTypes.Contains(fieldType)) continue;

            var aValue = info.GetValue(leftObj);
            var bValue = rightObj == null ? null : info.GetValue(rightObj);

            if (aValue == leftObj || visited.Contains(aValue)) continue;
            visited.Add(aValue);

            if (aValue == null && bValue == null) continue;
            if (aValue == bValue) continue;
            if (aValue != null && aValue.Equals(bValue)) continue;
            var fieldPath = AppendPath(path, info.Name);
            diffs.Add(new DiffItem(fieldPath, aValue, bValue));
            if (_detailedTypes.Contains(fieldType) && aValue != null && depth <= 2)
                Diff(aValue, bValue, fieldPath, diffs, visited, depth + 1);
        }
    }

    private void Inspect(object obj, string path, ICollection<InspectedItem> items, ICollection<object> visited, int depth)
    {
        var objType = obj.GetType();

        foreach (var info in objType.GetFields(_bindingAttributes))
        {
            var fieldType = info.FieldType;
            if (fieldType.IsByRef) continue;
            if (_ignoredTypes.Contains(fieldType)) continue;

            var fieldValue = info.GetValue(obj);
            if (fieldValue == obj || visited.Contains(fieldValue)) continue;
            visited.Add(fieldValue);
            var fieldPath = AppendPath(path, info.Name);
            items.Add(new InspectedItem(fieldPath, fieldType, fieldValue));
            if (_detailedTypes.Contains(fieldType) && fieldValue != null && depth <= 2)
                Inspect(fieldValue, fieldPath, items, visited, depth + 1);
        }

        foreach (var info in objType.GetProperties(_bindingAttributes))
        {
            var fieldType = info.PropertyType;
            if (fieldType.IsByRef) return;
            if (_ignoredTypes.Contains(fieldType)) continue;

            var fieldValue = info.GetValue(obj);
            if (fieldValue == obj || visited.Contains(fieldValue)) continue;
            visited.Add(fieldValue);
            var fieldPath = AppendPath(path, info.Name);
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

    public class DiffItem(string path, object? leftVal, object? rightVal)
    {
        [UsedImplicitly] public readonly object? LeftValue = leftVal;
        [UsedImplicitly] public readonly string Path = path;
        [UsedImplicitly] public readonly object? RightValue = rightVal;
    }
}
