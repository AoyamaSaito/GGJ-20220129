using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public Transform[] SavePoints => _savePoints;
    public int SavePointIndex => _savePointIndex;
    //public float Timer => _timer;

    [SerializeField] private Transform[] _savePoints;
    [SerializeField] private GameObject _gameOverUi;
    [SerializeField] private GameObject _gameClereUi;
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private GameObject _timerUi;
    [SerializeField] private Text _timerMinutesText;
    [SerializeField] private Text coron;
    [SerializeField] private Text _timerSecondsText;
    private GameObject _player;
    private int _savePointIndex = 0;
    //private float _timer;
    [Header("Timer")]
    [SerializeField] int _timerminutes = 3;
    [SerializeField] private float _timerSeconds;
    //[SerializeField] float seconds = 0;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
        if(!_player)
        {
            Debug.LogError("プレイヤーを参照できませんでした");
        }

        if(!_timerMinutesText && !_timerSecondsText && !_timerUi)
        {
            Debug.LogError("timerのUIが設定されていません");
        }
    }
    private void Update()
    {
        if (_timerminutes <= 0f && _timerSeconds <= 0)
        {
            _timerUi.SetActive(false);
            TimeOver();
        }
        else if (_timerminutes <= 0f && _timerSeconds <= 30)
        {
            _timerMinutesText.color = Color.red;
            coron.color = Color.red;
            _timerSecondsText.color = Color.red;
        }

        _timerSeconds -= Time.deltaTime;
        _timerMinutesText.text = _timerminutes.ToString("00");
        _timerSecondsText.text = (_timerSeconds / 1f).ToString("00");

        if(_timerSeconds < 0)
        {
            _timerminutes--;
            _timerSeconds = 59;
        }
    }

    public void SavePointUpdate(int savePointIndex)
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
    public void GameClear()
    {
        _gameClereUi.SetActive(true);
    }

}
