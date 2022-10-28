using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public struct VirtualMethod
{
    public MonoBehaviour ObjectRef { get; set; }
    public MethodInfo Method { get; set; }

    public void Execute()
    {
        Method.Invoke(ObjectRef, null);
    }
}

    public class VirtualMethods
    {
        List<VirtualMethod> allMethods = new List<VirtualMethod>();
        public void Add(MonoBehaviour _origin, MethodInfo _method)
        {
            allMethods.Add(new VirtualMethod()
            {
                ObjectRef = _origin,
                Method = _method
            });

        }

        public void InvokeAll()
        {
            for (int i = 0; i < allMethods.Count; i++)
            {
                allMethods[i].Execute();
            }
        }
    }

