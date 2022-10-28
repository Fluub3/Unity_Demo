using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour, IGizmo
{
    [SerializeField] Vector3 direction = Vector3.right; // direction where the object needs to go
    [SerializeField] bool canMove = true, showGizmos = true;

    #region gizmos
    [SerializeField] GizmoSettings settings = new GizmoSettings();
    public GizmoSettings Settings => settings;
    #endregion

    public Vector3 CurrentPosition => transform.position;
    public Vector3 FinalPosition => transform.position + (direction * Time.deltaTime);

// Update is called once per frame
void Update()
    {
        Move();
    }

    void Move()
    {
        if (!canMove)
            return;
        transform.position = FinalPosition;
    }

    public void Startmove() => canMove = true;
    public void Stoptmove() => canMove = false;

    public void OnDrawGizmos()
    {
        if (!settings.UseGizmos)
            return;
        Gizmos.color = settings.MainColor;
        Vector3 _final = transform.position + direction;
        Gizmos.DrawLine(CurrentPosition, _final);
        Gizmos.DrawSphere(_final, settings.SphereSize);
    }
}
