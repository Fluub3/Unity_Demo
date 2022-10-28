using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugerMono : MonoBehaviour
{
    [SerializeField] TestDebug debug = new TestDebug();
    [SerializeField, Debug] bool toDebugBool = true;

    void Start()
    {
        this.ToDebug();
        
    }

    private void FixedUpdate()
    {
        debug.ToDebug(Verbosity.ERROR);
    }

}
