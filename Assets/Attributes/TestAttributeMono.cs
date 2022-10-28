using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Name("toto"), Name("example")]

public class TestAttributeMono : MonoBehaviour
{
    [SerializeField, NameValue] int example = 1,
                                    newInt = 12,
                                    ageValue = 100;

    [NameValue] bool boolExample = false;
    [NameValue] float floatExample = 12.4f;
    [NameValue] GameObject go = null;
    short shortInt = 2;

    //recup les attributs

    private void Start() => Call("GetNameValueAttribute");

    void ReadAttributes()
    {
        Attribute[] _all = Attribute.GetCustomAttributes(GetType());
        foreach (Attribute _at in _all)
        {
            if (_at.GetType() == typeof(NameAttribute))
                Debug.Log(((NameAttribute)_at).Name);
        }
        Debug.Log(_all.Length);
    }

    void Call(string _name)
    {
        MethodInfo _call = GetType().GetMethod(_name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        if (_call == null)
            return;
        _call?.Invoke(this, null);
    }

    void ReflectionExample()
    {
        FieldInfo[] _fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        for (int i = 0; i < _fields.Length; i++)
        {
            Debug.Log($"{_fields[i].Name} - {_fields[i].GetValue(this)}");
            _fields[i].SetValue(this, 10);
            Debug.Log($"{_fields[i].Name} - {_fields[i].GetValue(this)}");
        }
    }

    void GetNameValueAttribute()
    {
        FieldInfo[] _f  = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        for (int i = 0; i < _f.Length; i++)
        {
            if (_f[i].GetCustomAttribute<NameValueAttribute>() != null)
                Debug.Log($"{_f[i].Name} = {_f[i].GetValue(this)}");
        }
    }
}
