using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    /// <summary>ëÄçÏï˚ñ@</summary>
    [SerializeField] GameObject _howToPlay;
    [SerializeField] string _mainSceneName;
    [SerializeField] string _titleSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(_mainSceneName);
    }
    public void HowToPlay()
    {
        _howToPlay.SetActive(true);
    }
    public void DontHowToPlay()
    {
        _howToPlay.SetActive(false);
    }
    public void Title()
    {
        SceneManager.LoadScene(_titleSceneName);
    }
}
