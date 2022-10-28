using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGizmo
{
    GizmoSettings Settings { get; }

    void OnDrawGizmos();

}
