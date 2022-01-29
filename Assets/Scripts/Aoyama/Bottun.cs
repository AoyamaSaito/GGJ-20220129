using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottun : MonoBehaviour
{
    [SerializeField] Animator _doorAnim;
    [SerializeField] DoorBase doorBase;
    bool _isEnter= false;

    private void Start()
    {
        _doorAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("f") && _isEnter)
        {
            _doorAnim.Play("LeverAnim");
            doorBase.Push();
            Debug.Log("ボタン");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Stay");
        //if (collision.gameObject.tag == "Player" && Input.GetKeyDown("r"))
        //{
        //    doorBase.Push();
        //    Debug.Log("ボタン");
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _isEnter = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isEnter = false;
        }
    }
}
