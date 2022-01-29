using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public Transform[] SavePoints => _savePoints;
    public int SavePointIndex => _savePointIndex;
    public float Timer => _timer;

    [SerializeField] private Transform[] _savePoints;
    [SerializeField] private GameObject _gameOverUi;
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private Text _timerText;
    private GameObject _player;
    private int _savePointIndex = 0;
    private float _timer;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
        if(!_player)
        {
            Debug.LogError("プレイヤーを参照できませんでした");
        }
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerText.text = _timer.ToString("F0");
    }

    void SavePointUpdate(int savePointIndex)
    {
        _savePointIndex = savePointIndex;
    }

    public void TimeOver()
    {
        _player.SetActive(false);
        _gameOverUi.SetActive(true);
    }

    public void Respawn()
    {
        _player.transform.position = _savePoints[_savePointIndex].position;
    }

}
