using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ìdé•îg
/// </summary>
public class ErectDoor : DoorBase
{
    [SerializeField] Animator _electromagneticAnim;
    [SerializeField] float _openSoundDelay = 0.5f;
    [SerializeField] GameObject _electromagnetiObj;
    public override void Push()
    {
        SoundManager.Instance.UseSound(SoundType.Button);
        StartCoroutine(OpenSound());
    }

    void Start()
    {
        _electromagneticAnim = GetComponent<Animator>();
    }

    IEnumerator OpenSound()
    {
        yield return new WaitForSeconds(_openSoundDelay);
        SoundManager.Instance.UseSound(SoundType.DoorOpen);
        _electromagneticAnim.Play("Thunder");
        _electromagnetiObj.SetActive(false);
    }
}
