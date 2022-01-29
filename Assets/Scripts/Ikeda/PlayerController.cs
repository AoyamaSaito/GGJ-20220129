using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>肉体ならfalse</summary>
    bool _isBodyOrAstral = false;
    [Tooltip("幽体のゲームオブジェクト")]
    [SerializeField] GameObject _astralBody;
    /// <summary>幽体のインスタンス</summary>
    GameObject _astralInstance;
    [Tooltip("肉体状態の移動速度")]
    [SerializeField] float _bodySpeed;
    [Tooltip("幽体状態の移動速度")]
    [SerializeField] Vector2 _astralSpeed;
    [Tooltip("肉体のカメラ")]
    [SerializeField] CinemachineVirtualCameraBase _bodyVCam;
    [Tooltip("幽体のカメラ")]
    [SerializeField] CinemachineVirtualCameraBase _astralVCam;
    /// <summary>移動入力値</summary>
    Vector2 _move;

    SpriteRenderer _bodySprite;
    SpriteRenderer _astralSprite;

    Rigidbody2D _rb;
    Rigidbody2D _astralRb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bodySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            SwitchBodyOrAstral();
        }
        _move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (_isBodyOrAstral)
        {
            _astralRb.velocity = _astralSpeed * _move;
            if (_move.x < 0)
            {
                _astralSprite.flipX = true;
            }
            else if (_move.x > 0)
            {
                _astralSprite.flipX = false;
            }
        }
        else
        {
            _rb.velocity = new Vector2(_bodySpeed * _move.x, 0);
            if (_move.x < 0)
            {
                _bodySprite.flipX = true;
            }
            else if (_move.x > 0)
            {
                _bodySprite.flipX = false;
            }
        }
    }

    /// <summary>肉体と幽体を切り替え </summary>
    void SwitchBodyOrAstral()
    {
        if (_isBodyOrAstral)
        {
            if (_astralInstance)
            {
                Destroy(_astralInstance);
            }
            _isBodyOrAstral = false;
            _bodyVCam.MoveToTopOfPrioritySubqueue();
        }
        else
        {
            _astralInstance = Instantiate(_astralBody, transform);
            _astralRb = _astralInstance.GetComponent<Rigidbody2D>();
            _astralSprite = _astralInstance.GetComponent<SpriteRenderer>();
            _isBodyOrAstral = true;
            _rb.velocity = Vector2.zero;
            _astralVCam.MoveToTopOfPrioritySubqueue();
            _astralVCam.LookAt = _astralInstance.transform;
            _astralVCam.Follow = _astralInstance.transform;
        }
    }
}
