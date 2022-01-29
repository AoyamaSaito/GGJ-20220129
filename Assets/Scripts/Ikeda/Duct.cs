using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duct : MonoBehaviour
{
    [SerializeField] GameObject _other;
    bool _isReady = false;
    Transform _playerTr;

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(Input.GetKeyDown("f") && collision.tag == "Player")
    //    {
    //        Debug.Log(1);
    //        collision.transform.position += _other.transform.position - transform.position;
    //    }
    //    if (Input.GetKey("h"))
    //    {
    //        Debug.Log(";");
    //    }
    //}

    private void Update()
    {
        if(Input.GetKeyDown("f") && _isReady)
        {
            _playerTr.transform.position += _other.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log(1);
            _playerTr = collision.transform;
            _isReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _isReady = false;
        }
    }
}
