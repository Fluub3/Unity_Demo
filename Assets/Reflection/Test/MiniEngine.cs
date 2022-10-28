using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MiniEngine : MonoBehaviour
{
    public const string START_KEY = "MyStart", UPDATE_KEY = "MyUpdate", FIXED_UPDATE_KEY = "MyFixedUpdate", LATE_UPDATE_KEY = "MyLateUpdate";
    [SerializeField] MonoBehaviour[] allEngineScripts = null;

    Dictionary<string, VirtualMethods> allMethods = new Dictionary<string, VirtualMethods>()
    {
        {START_KEY, new VirtualMethods() },
        {UPDATE_KEY, new VirtualMethods() },
        {LATE_UPDATE_KEY, new VirtualMethods() },
        {FIXED_UPDATE_KEY, new VirtualMethods() },
    };

    private void Start()
    {
        GetVirtualMethods();
        allMethods[START_KEY].InvokeAll();
    }

    void Update() => allMethods[UPDATE_KEY].InvokeAll();

    private void LateUpdate() => allMethods[LATE_UPDATE_KEY].InvokeAll();

    private void FixedUpdate() => allMethods[FIXED_UPDATE_KEY].InvokeAll();

    void GetVirtualMethods()
    {
        for (int i = 0; i < allEngineScripts.Length; i++)
        {
            MonoBehaviour _script = allEngineScripts[i];
            MethodInfo _startMethod = _script.GetType().GetMethod(START_KEY, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                        _updateMethod = _script.GetType().GetMethod(UPDATE_KEY, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                        _lateMethod = _script.GetType().GetMethod(LATE_UPDATE_KEY, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                        _fixedMethod = _script.GetType().GetMethod(FIXED_UPDATE_KEY, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (_startMethod != null)
                allMethods[START_KEY].Add(_script, _startMethod);
            if (_updateMethod != null)
                allMethods[UPDATE_KEY].Add(_script, _updateMethod);
            if (_lateMethod != null)
                allMethods[LATE_UPDATE_KEY].Add(_script, _lateMethod);
            if (_fixedMethod != null)
                allMethods[FIXED_UPDATE_KEY].Add(_script, _fixedMethod);
        }
    }
}
