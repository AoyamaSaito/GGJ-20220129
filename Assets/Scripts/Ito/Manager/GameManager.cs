using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public float Timer { get; private set; }
    /// <summary>�v���C���[�̎c��</summary>
    public int Residue { get; private set; }
    
}
