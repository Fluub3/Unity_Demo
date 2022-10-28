using System;
using UnityEngine;

[Serializable]
public class TestDebug
{
    [SerializeField, Debug(false)] int toDebug = 5;

}
