using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottun : MonoBehaviour
{
    [SerializeField] DoorBase doorBase;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            doorBase.Push();
        }
    }
}
