using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : DoorBase
{
    //[SerializeField] Animation _doorAnim;
    [SerializeField] Animator _doorAnim;
    [SerializeField] float _openSoundDelay = 0.5f;
    public override void Push()
    {
        SoundManager.Instance.UseSound(SoundType.Button);
        StartCoroutine(OpenSound());
        Debug.Log("‚Ç‚ ");
    }

    void Start()
    {
        _doorAnim = GetComponent<Animator>();
    }

    IEnumerator OpenSound()
    {
        yield return new WaitForSeconds(_openSoundDelay);
        SoundManager.Instance.UseSound(SoundType.DoorOpen);
        _doorAnim.Play("Door");
    }
}
