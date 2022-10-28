using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GizmoSettings
{
    #region GizmoParam
    [SerializeField, Header("Gizmo settings")] bool showGizmos = true;
    [SerializeField] Color mainColor = Color.green;
    [SerializeField, Range(.1f, 10)] float sphereSize = 1, cubeSize = 1;

    public bool UseGizmos => showGizmos;
    public float SphereSize => sphereSize;
    public float CubeSize => cubeSize;

    public Color MainColor => mainColor;

    public void ShowGizmos(bool _show) => showGizmos = _show;
    #endregion
}
