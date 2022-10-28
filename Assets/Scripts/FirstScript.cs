using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{

    #region Events
    #endregion

    #region F/P
    //public int valueExample = 5;
    //public int valueExample { get; set; } = 5;
    [SerializeField] int intValue = 5; // variable s�rialis� priv�e
    public int IntValue => intValue; // accesseur s�rialis� publique

    #endregion

    #region UnityEvents

    //void Awake() => Debug.Log("First");

    // Start is called before the first frame update
    void Start()
    {
        //InitMessage("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Update is called once per frame by the end
    private void LateUpdate()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
    #endregion

    #region CustomMethods
    void InitMessage(string _msg)
    {
        Debug.Log(_msg);
    }
    #endregion
}
