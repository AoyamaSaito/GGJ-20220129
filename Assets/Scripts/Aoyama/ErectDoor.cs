using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �d���g
/// </summary>
public class ErectDoor : DoorBase
{
    [SerializeField] Animation _electromagneticAnim;
    [SerializeField] AudioSource _electromagneticAudio;
    [SerializeField] GameObject _electromagnetiObj;
    public override void Push()
    {
        _electromagneticAudio.Play();
        _electromagneticAnim.Play();
        _electromagnetiObj.SetActive(false);
        //������
    }

    void Start()
    {
        _electromagneticAudio = GetComponent<AudioSource>();
        _electromagneticAnim = GetComponent<Animation>();
    }
}
