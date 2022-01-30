using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���X�@�̃N���X�@���߂�ꂽ�ʒu���s�����藈���肷��
/// </summary>
public class PressMachine : MonoBehaviour
{
    [SerializeField, Tooltip("�v���X�@���~���Y���W")] Transform movePoint = default;
    [SerializeField, Tooltip("�ړ����x")]float moveSpeed = 1.0f;

    [Tooltip("�v���X�@�̏����ʒu")]Vector3 firstPosition = default;
    [Tooltip("������Transform")]Transform myTransform;
    float timer = 0;
    bool up = false;
    bool stop = false;

    void Start()
    {
        //�����ʒu��ۑ�
        firstPosition = gameObject.transform.position;
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePressMachine();
    }

    void MovePressMachine()
    {
        if(!up)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
        }

        //���߂�ꂽ�n�_�ɓ��B�����bool��؂�ւ���
        if(myTransform.position.y <= movePoint.position.y)
        {
            up = true;
        }
        else if(myTransform.position.y >= firstPosition.y)
        {
            up = false;
        }

        Vector3 vec = new Vector3(firstPosition.x, firstPosition.y + timer * moveSpeed, firstPosition.z);
        myTransform.position = vec;
    }
}
