using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    /// <summary>肉体ならfalse</summary>
    bool _isBodyOrAstral = false;
    public bool IsBodyOrAstral { get { return _isBodyOrAstral; } }
    [Tooltip("幽体のゲームオブジェクト")]
    [SerializeField] GameObject _astralBody;
    /// <summary>幽体のインスタンス</summary>
    GameObject _astralInstance;
    [Tooltip("肉体状態の移動速度")]
    [SerializeField] float _bodySpeed;
    [Tooltip("幽体状態の移動速度")]
    [SerializeField] Vector2 _astralSpeed;
    [Tooltip("肉体のカメラ(右)")]
    [SerializeField] CinemachineVirtualCamera _bodyVCamRight;
    [Tooltip("肉体のカメラ(左)")]
    [SerializeField] CinemachineVirtualCamera _bodyVCamLeft;
    CinemachineVirtualCamera _bodyVCam;
    [Tooltip("幽体のカメラ(右)")]
    [SerializeField] CinemachineVirtualCamera _astralVCamRight;
    [Tooltip("幽体のカメラ(左)")]
    [SerializeField] CinemachineVirtualCamera _astralVCamLeft;
    [SerializeField] ParticleSystem _callParticle;
    /// <summary>移動入力値</summary>
    Vector2 _move;
    [Tooltip("Cinemachineのブレンドの時間")]
    [SerializeField] float _brendTime;
    [Tooltip("戻る奴")]
    [SerializeField] GameObject _orb;
    [Tooltip("肉体のアニメーター")]
    [SerializeField] Animator _anim;
    [Tooltip("胸部")]
    [SerializeField] Transform _bust;

    /// <summary>右向きがtrue</summary>
    bool _isRightOrLeft = true;


    Rigidbody2D _rb;
    Rigidbody2D _astralRb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bodyVCam = _bodyVCamRight;
        _bodyVCamRight.Priority = 10;
        _astralVCamLeft.Priority = 10;
        _bodyVCamRight.Priority = 10;
        _astralVCamLeft.Priority = 10;
        _bodyVCam.MoveToTopOfPrioritySubqueue();
        if (!_bust)
        {
            _bust = transform;
        }
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
            _move.Normalize();
            _astralRb.velocity = _astralSpeed * _move;
            if (_move.x < 0)
            {
                _astralInstance.transform.eulerAngles = new Vector3(0, 180, 0);
                _astralVCamLeft.MoveToTopOfPrioritySubqueue();
            }
            else if (_move.x > 0)
            {
                _astralInstance.transform.eulerAngles = Vector3.zero;
                _astralVCamRight.MoveToTopOfPrioritySubqueue();
            }
        }
        else
        {
            _rb.velocity = new Vector2(_bodySpeed * _move.x, 0);
            if (_move.x < 0)
            {
                _isRightOrLeft = false;
                transform.eulerAngles = new Vector3(0, 180, 0);
                _bodyVCam = _bodyVCamLeft;
                _bodyVCam.MoveToTopOfPrioritySubqueue();
            }
            else if (_move.x > 0)
            {
                _isRightOrLeft = true;
                transform.eulerAngles = Vector3.zero;
                _bodyVCam = _bodyVCamRight;
                _bodyVCam.MoveToTopOfPrioritySubqueue();
            }
        }
    }

    private void LateUpdate()
    {
        if (_anim)
        {
            _anim.SetBool("_isBodyOrAstral", _isBodyOrAstral);
            _anim.SetFloat("XSpeed", _move.x);
            _anim.SetFloat("YSpeed", _move.y);
        }
    }

    /// <summary>肉体と幽体を切り替え </summary>
    void SwitchBodyOrAstral()
    {
        if (_isBodyOrAstral)
        {
            if (_astralInstance)
            {
                StartCoroutine(Buck(_brendTime, _astralInstance.transform.position, _bust.transform.position));
                Destroy(_astralInstance);
            }
            _isBodyOrAstral = false;
            _bodyVCam.MoveToTopOfPrioritySubqueue();
        }
        else
        {
            _astralInstance = Instantiate(_astralBody,　_bust.transform.position, Quaternion.identity);
            _astralRb = _astralInstance.GetComponent<Rigidbody2D>();
            if (!_isRightOrLeft)
            {
                _astralInstance.transform.eulerAngles = new Vector3(0, 180, 0);
                _astralVCamLeft.MoveToTopOfPrioritySubqueue();
                _astralVCamLeft.Follow = _astralInstance.transform;
                _astralVCamRight.Follow = _astralInstance.transform;
            }
            else
            {
                _astralInstance.transform.eulerAngles = Vector3.zero;
                _astralVCamRight.MoveToTopOfPrioritySubqueue();
                _astralVCamLeft.Follow = _astralInstance.transform;
                _astralVCamRight.Follow = _astralInstance.transform;
            }
            _isBodyOrAstral = true;
            _rb.velocity = Vector2.zero;
            Instantiate(_callParticle, _bust.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator Buck(float time, Vector2 astral, Vector2 body)
    {
        var go = Instantiate(_orb, _astralInstance.transform.position, Quaternion.identity);
        for (float course = 0; course <= time; course += Time.deltaTime)
        {
            go.transform.position = Vector2.Lerp(astral, body, course / time);
            yield return null;
        }
        Destroy(go);
    }
}
