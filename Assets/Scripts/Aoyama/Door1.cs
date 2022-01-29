using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : DoorBase
{
    [SerializeField] Animation _doorAnim;
    [SerializeField] AudioSource _doorAudio;
    public override void Push()
    {
        _doorAudio.Play();
        _doorAnim.Play();
        //è„Ç…è„Ç™ÇÈ
    }

    void Start()
    {
        _doorAudio = GetComponent<AudioSource>();
        _doorAnim = GetComponent<Animation>();
    }
}
