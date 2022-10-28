using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;



public enum Verbosity
{
    ERROR,
    WARNING,
    LOG
}

public static class DebugObjectExtension
{
    public static void ToDebug(this object _item)
    {
        FieldInfo[] _fields = _item.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        foreach (FieldInfo _field in _fields)
        {
            DebugAttribute _debug = _field.GetCustomAttribute<DebugAttribute>();
            if (_debug != null && _debug.IsValid)
                Debug.Log(_field.GetValue(_item));
        }


    }

    public static void ToDebug(this object _item, Verbosity _verb)
    {
        FieldInfo[] _fields = _item.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        foreach (FieldInfo _field in _fields)
        {
            DebugAttribute _debug = _field.GetCustomAttribute<DebugAttribute>();
            if (_debug != null && _debug.IsValid)
            {
                switch(_verb)
                {
                    case Verbosity.LOG:
                        Debug.Log(_field.GetValue(_item));
                        continue;

                    case Verbosity.WARNING:
                        Debug.LogWarning(_field.GetValue(_item));
                        continue;
                    case Verbosity.ERROR:
                        Debug.LogError(_field.GetValue(_item));
                        continue;
                }
            }
        }
    }
}
