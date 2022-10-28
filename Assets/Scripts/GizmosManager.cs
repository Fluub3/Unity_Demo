using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosManager : MonoBehaviour
{
    List<IGizmo> allGizmos = new List<IGizmo>();

    public void Add(IGizmo _gizmo)
    {
        allGizmos.Add(_gizmo);
    }

    public void StopAll()
    {
        for (int i = 0; i < allGizmos.Count; i++)
        {
            allGizmos[i].Settings.ShowGizmos(false);
        }
    }
}
