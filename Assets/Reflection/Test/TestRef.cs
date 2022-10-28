using System;
using System.Reflection;
using UnityEngine;

public class TestRef : MonoBehaviour
{
    void MyStart()
    {
        Debug.Log("start");
    }

    void MyUpdate()
    {
        Debug.Log("update");
    }

    void MyFixedUpdate()
    {
        Debug.Log("Fupdate");
    }

    void MyLateUpdate()
    {
        Debug.Log("Lupdate");
    }
}
