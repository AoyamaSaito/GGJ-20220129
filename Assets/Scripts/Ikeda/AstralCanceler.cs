using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralCanceler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.Instance.AstralProjectionCancel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.Instance.AstralProjectionCancel();
        }
    }
}
