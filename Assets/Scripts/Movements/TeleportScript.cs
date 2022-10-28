using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour, IGizmo
{
    // property transform serializable
    [SerializeField] Transform target = null;
    [SerializeField] GizmoSettings settings = new GizmoSettings();
    public GizmoSettings Settings => settings;


    // Start is called before the first frame update
    void Start()
    {
        Teleport();
    }

    void Teleport()
    {
        if (!target) return;
        transform.position = target.position;
    }

    public void OnDrawGizmos()
    {
        if (!settings.UseGizmos)
            return;

        if(!target)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, settings.SphereSize);
            return;
        }

        Vector3 _cacheLocation = target.position;
        Gizmos.color = settings.MainColor;
        Gizmos.DrawLine(_cacheLocation, transform.position);
        Gizmos.DrawWireSphere(_cacheLocation, settings.SphereSize);
    }
}
