using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaswardPanel : MonoBehaviour
{
    [SerializeField, Tooltip("�J����h�A")] DoorBase openDoor;
    [SerializeField, Tooltip("�Ԃ̃����v")] GameObject redLump;
    [SerializeField, Tooltip("�΂̃����v")] GameObject greenLump;
    [SerializeField, Tooltip("�p�X���[�h����͂���p�l��")] GameObject paswardPanel;
    [SerializeField, Tooltip("panel�̐������o������")] Text display;
    [SerializeField, Tooltip("��̂ł��������Ȃ�����")] GameObject astralNumber;
    [SerializeField, Tooltip("Player�̃^�O")] string playerTag = "Player";
    [SerializeField, Tooltip("����")] int[] answer = default;
    [SerializeField, Tooltip("����܂ł̎���")] float waitTime = 1;
    [Header("Test")]
    [SerializeField] bool inAria = false;

    string currntPanel = "";
    int count = 0;
    void Start()
    {
        redLump.SetActive(true);
        greenLump.SetActive(false);
        paswardPanel?.SetActive(false);
        display.text = currntPanel;
    }

    private void Update()
    {
        if (Input.GetKeyDown("f") && inAria)
        {
            paswardPanel.SetActive(true);
        }

        if (PlayerController.Instance.IsBodyOrAstral)
        {
            astralNumber.SetActive(true);
        }
        else
        {
            astralNumber.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            inAria = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            inAria = false;
        }
    }

    public void input(int number)
    {
        SoundManager.Instance.UseSound(SoundType.Button);

        if (answer[count] != number)
        {
            count = 0;
            currntPanel = "";
            display.text = currntPanel;
            paswardPanel?.SetActive(false);
        }
        else
        {
            Debug.Log(number);
            currntPanel += number.ToString();
            display.text = currntPanel;
            Debug.Log(number);
            count++;
            if (count == 6)
            {
                Debug.Log("����");
                StartCoroutine(SuccessCor());
            }
        }
    }

    IEnumerator SuccessCor()
    {
        redLump.SetActive(false);
        greenLump.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        openDoor?.Push();
        paswardPanel?.SetActive(false);
        this.gameObject.GetComponent<PaswardPanel>().enabled = false;
    }
}
