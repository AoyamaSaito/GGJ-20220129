using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    /// <summary>ëÄçÏï˚ñ@</summary>
    [SerializeField] GameObject _howToPlay;
    public void StartGame()
    {
        SceneManager.LoadScene("");
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
        SceneManager.LoadScene("");
    }
}
