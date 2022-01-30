using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SavePoint : MonoBehaviour 
{ 
    [SerializeField] int _save;
    [SerializeField] GameObject _saveUI;
    [SerializeField] float _saveTime = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.SavePointUpdate(_save);
            SoundManager.Instance.UseSound(SoundType.Save);
            StartCoroutine(SaveUiStart());
        }
    }

    IEnumerator SaveUiStart()
    {
        _saveUI.SetActive(true);
        yield return new WaitForSeconds(_saveTime);
        _saveUI.SetActive(false);
        gameObject.SetActive(false);
    }
}
