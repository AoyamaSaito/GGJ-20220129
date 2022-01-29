using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottun : MonoBehaviour
{
    [SerializeField] DoorBase doorBase;

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown("f"))
        {
            doorBase.Push();
        }
    }
}
