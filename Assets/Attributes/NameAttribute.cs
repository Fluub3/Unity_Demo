using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class NameAttribute : Attribute
{
    public string Name { get; set; }
    public NameAttribute(string _value)
    {
        Name = _value;
    }
}

public class NameValueAttribute : Attribute
{

}
