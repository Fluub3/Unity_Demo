using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [Serializable] remember JsonUtility // NewtonSoft
[Serializable]
public class ClassTestJson
{
    [SerializeField, ToJson] int firstValue = 10;
    [SerializeField, ToJson] bool lastBool = false;
    [SerializeField] float floatValue = 5.0f;
    [ToJson] public string Example { get; set; } = "Test";


}
