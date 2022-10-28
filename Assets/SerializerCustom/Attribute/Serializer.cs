using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;

public sealed class CommonSerialize<T>
{
    public string Name { get; protected set; }
    public string Value { get; protected set; }

    public CommonSerialize(T _type, FieldInfo _field)
    {
        Name = _field.Name;
        Value = _field.GetValue(_type).ToString();
    }

    public CommonSerialize(T _type, PropertyInfo _prop)
    {
        Name = _prop.Name;
        Value = _prop.GetValue(_type).ToString();
    }

    public override string ToString()
    {
        return " \"" + Name + "\":\"" + Value + "\"";
    }

}

public class Serializer<T>
{
    public static string Serialize(T _item)
    {
        FieldInfo[] _fields = _item.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        JsonObject<T> _json = new JsonObject<T>();
        for (int i = 0; i < _fields.Length; i++)
        {
            if (_fields[i].GetCustomAttribute<ToJsonAttribute>() != null)
                _json.Add(new CommonSerialize<T>(_item, _fields[i]));
        }
        PropertyInfo[] _properties = _item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        for (int i = 0; i < _properties.Length; i++)
        {
            if (_properties[i].GetCustomAttribute<ToJsonAttribute>() != null)
                _json.Add(new CommonSerialize<T>(_item, _properties[i]));
        }
        return _json.ToString();
    }

    public static T Deserialize(string _object)
    {
        object _item = Activator.CreateInstance<T>();
        List<MemberInfo> _members = new List<MemberInfo>
            (_item.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
        _members.AddRange(_item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
        string[] _parts = FormatJsonToString(_object).Split(',');
        for (int i = 0; i < _parts.Length; i++)
        {
            string[] _split = _parts[i].Split(':');
            string _name = _split[0].Trim();
            string _value = _split[1].Trim();
            MemberInfo _validMember = _members.FirstOrDefault(f => f.Name == _name);
            if (_parts == null)
                continue;
            if (_validMember.MemberType == MemberTypes.Field)
                _validMember = SetFieldInfo(_item, (FieldInfo)_validMember, _value);
            else if (_validMember.MemberType == MemberTypes.Property)
                _validMember = SetPropertyInfo(_item, (PropertyInfo)_validMember, _value);
        }
        return (T)_item;
    }

    static FieldInfo SetFieldInfo(object _item, FieldInfo _field, string _value)
    {
        if (_field.FieldType == typeof(string))
            _field.SetValue(_item, _value);
        else if (_field.FieldType == typeof(int))
            _field.SetValue(_item, int.Parse(_value));
        else if (_field.FieldType == typeof(bool))
            _field.SetValue(_item, bool.Parse(_value));
        return _field;
    }

    static PropertyInfo SetPropertyInfo(object _item, PropertyInfo _property, string _value)
    {
        if (_property.PropertyType == typeof(string))
            _property.SetValue(_item, _value);
        else if (_property.PropertyType == typeof(int))
            _property.SetValue(_item, int.Parse(_value));
        else if (_property.PropertyType == typeof(bool))
            _property.SetValue(_item, bool.Parse(_value));
        return _property;
    }



    static string FormatJsonToString(string _json)
    {
        return _json.Replace("{", "").Replace("}", "").Replace("\"", "");
    }
}
