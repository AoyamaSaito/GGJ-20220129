using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>���̂Ȃ�false</summary>
    bool _isBodyOrAstral = false;
    [Tooltip("�H�̂̃Q�[���I�u�W�F�N�g")]
    [SerializeField] GameObject _astralBody;
    /// <summary>�H�̂̃C���X�^���X</summary>
    GameObject _astralInstance;
    [Tooltip("���̏�Ԃ̈ړ����x")]
    [SerializeField] float _bodySpeed;
    [Tooltip("�H�̏�Ԃ̈ړ����x")]
    [SerializeField] Vector2 _astralSpeed;
    [Tooltip("���̂̃J����(�E)")]
    [SerializeField] CinemachineVirtualCamera _bodyVCamRight;
    [Tooltip("���̂̃J����(��)")]
    [SerializeField] CinemachineVirtualCamera _bodyVCamLeft;
    CinemachineVirtualCamera _bodyVCam;
    [Tooltip("�H�̂̃J����(�E)")]
    [SerializeField] CinemachineVirtualCamera _astralVCamRight;
    [Tooltip("�H�̂̃J����(��)")]
    [SerializeField] CinemachineVirtualCamera _astralVCamLeft;
    CinemachineVirtualCamera _astralVCam;
    /// <summary>�ړ����͒l</summary>
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
        _bodyVCam = _bodyVCamRight;
        _astralVCam = _astralVCamRight;
        _bodyVCamRight.Priority = 10;
        _astralVCamLeft.Priority = 10;
        _bodyVCamRight.Priority = 10;
        _astralVCamLeft.Priority = 10;
        _bodyVCam.MoveToTopOfPrioritySubqueue();
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
                _astralVCam = _astralVCamLeft;
                _astralVCam.MoveToTopOfPrioritySubqueue();
            }
            else if (_move.x > 0)
            {
                _astralSprite.flipX = false;
                _astralVCam = _astralVCamRight;
                _astralVCam.MoveToTopOfPrioritySubqueue();
            }
        }
        else
        {
            _rb.velocity = new Vector2(_bodySpeed * _move.x, 0);
            if (_move.x < 0)
            {
                _bodySprite.flipX = true;
                _bodyVCam = _bodyVCamLeft;
                _bodyVCam.MoveToTopOfPrioritySubqueue();
            }
            else if (_move.x > 0)
            {
                _bodySprite.flipX = false;
                _bodyVCam = _bodyVCamRight;
                _bodyVCam.MoveToTopOfPrioritySubqueue();
            }
        }
    }

    /// <summary>���̂ƗH�̂�؂�ւ� </summary>
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
            _astralInstance = Instantiate(_astralBody, transform.position, Quaternion.identity);
            _astralRb = _astralInstance.GetComponent<Rigidbody2D>();
            _astralSprite = _astralInstance.GetComponent<SpriteRenderer>();
            _astralSprite.flipX = _bodySprite.flipX;
            if (_bodySprite.flipX)
            {
                _astralVCam = _astralVCamLeft;
            }
            else
            {
                _astralVCam = _astralVCamRight;
            }
            _isBodyOrAstral = true;
            _rb.velocity = Vector2.zero;
            _astralVCam.MoveToTopOfPrioritySubqueue();
            _astralVCam.Follow = _astralInstance.transform;
        }
    }
}
