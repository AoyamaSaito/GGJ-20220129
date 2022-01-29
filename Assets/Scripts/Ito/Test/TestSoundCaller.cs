using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundCaller : MonoBehaviour
{
    public void Play(int index)
    {
        SoundManager.Instance.UseSound((SoundType)index);
    }
}
