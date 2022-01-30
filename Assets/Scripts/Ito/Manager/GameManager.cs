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
    bool _firstTime = true;
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
        else if(_player)
        {
            Debug.Log("ﾌﾟﾚｲﾔｰ");
        }

        if(!_timerMinutesText && !_timerSecondsText && !_timerUi)
        {
            Debug.LogError("timerのUIが設定されていません");
        }
    }
    private void Update()
    {
        _timerSeconds -= Time.deltaTime;

        if (_timerminutes <= 0f && _timerSeconds <= 0)
        {
            TimeOver();
        }
        else if (_timerminutes <= 0f && _timerSeconds <= 30)
        {
            _timerMinutesText.color = Color.red;
            coron.color = Color.red;
            _timerSecondsText.color = Color.red;
        }

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
        if (!_firstTime) return;
        _firstTime = false;
        _timerUi.SetActive(false);
        _player.SetActive(false);
        _gameOverUi.SetActive(true);
    }

    public void Respawn()
    {
        PlayerController.Instance.AstralProjectionCancel();
        PlayerController.Instance.Anim.SetBool("_isBodyOrAstral", false);
        _player.transform.position = _savePoints[_savePointIndex].position;
    }
    public void GameClear()
    {
        _player.SetActive(false);
        _gameClereUi.SetActive(true);
        SoundManager.Instance.UseSound(SoundType.GameClear);
        _timerUi.SetActive(false);
    }

}
