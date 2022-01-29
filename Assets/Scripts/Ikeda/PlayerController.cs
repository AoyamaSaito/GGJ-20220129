using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
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
    /// <summary>�ړ����͒l</summary>
    Vector2 _move;

    Rigidbody2D _rb;
    Rigidbody2D _astralRb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        }
        else
        {
            _rb.velocity = new Vector2(_bodySpeed * _move.x, 0);
        }
    }

    void SwitchBodyOrAstral()
    {
        if (_isBodyOrAstral)
        {
            if (_astralInstance)
            {
                Destroy(_astralInstance);
            }
            _isBodyOrAstral = false;
        }
        else
        {
            _astralInstance = Instantiate(_astralBody, transform);
            _astralRb = _astralInstance.GetComponent<Rigidbody2D>();
            _isBodyOrAstral = true;
        }
    }
}
