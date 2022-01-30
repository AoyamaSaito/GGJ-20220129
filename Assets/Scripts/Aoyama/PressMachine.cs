using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレス機のクラス　決められた位置を行ったり来たりする
/// </summary>
public class PressMachine : MonoBehaviour
{
    [SerializeField, Tooltip("プレス機が降りるY座標")] Transform movePoint = default;
    [SerializeField, Tooltip("移動速度")]float moveSpeed = 1.0f;

    [Tooltip("プレス機の初期位置")]Vector3 firstPosition = default;
    [Tooltip("自分のTransform")]Transform myTransform;
    float timer = 0;
    bool up = false;
    bool stop = false;

    void Start()
    {
        //初期位置を保存
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

        //決められた地点に到達するとboolを切り替える
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
