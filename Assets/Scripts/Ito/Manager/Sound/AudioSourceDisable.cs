using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceDisable : MonoBehaviour
{
    [SerializeField] float _disableTime = 1f;
    float _timer;
    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _disableTime)
        {
            gameObject.SetActive(false);
            _timer = 0f;
        }
    }
}
