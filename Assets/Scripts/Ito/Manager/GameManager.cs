using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public Transform SavePoint => _savePoint;
    //public int SavePointIndex => 
    public float Timer => _timer;

    [SerializeField] private Transform _savePoint;
    //private int _saveP
    private float _timer;


    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void TimeOver()
    {

    }

    public void Respawn()
    {

    }

}
