using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _destroyTime = 5;
    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _destroyTime)
        {
            Destroy(gameObject);
        }
    }

    //Player‚ªCollder‚È‚Ì‚©Trigger‚È‚Ì‚©•ª‚©‚ç‚ñ‚©‚Á‚½‚©‚ç‚Ç‚Á‚¿‚à—pˆÓ‚µ‚Æ‚¢‚½
    //Á‚µ‚½‚¯‚ê‚Î‚¢‚ç‚È‚¢•ûÁ‚µ‚Ä
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
