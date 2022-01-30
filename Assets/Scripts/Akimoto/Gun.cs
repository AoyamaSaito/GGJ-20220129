using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Header("“÷‘Ì‚É“–‚½‚é’e")] GameObject _bodyBulletPrefab = default;
    [SerializeField, Header("°‚É“–‚½‚é’e")] GameObject _astralBulletPrefab = default;
    [SerializeField, Header("—¼•û‚É“–‚½‚é’e")] GameObject _ambiBulletPrefab = default;
    [SerializeField, Header("Œ‚‚Â’e‚ª’N‚É“–‚½‚é‚©")] TargetType _targetType = default;
    [SerializeField, Header("”­ŽËŠÔŠu")] float _fireInterval = 0;
    [SerializeField, Header("’e‚Ì‘¬“x")] float _bulletSpeed = 0;
    [SerializeField, Header("’eŒ‚‚ÂˆÊ’u‚Æ•ûŒü")] Transform _muzzle = default;
    private float _timer = 0;
    private enum TargetType { Body, Astral, Ambi }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _fireInterval)
        {
            _timer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject obj = default;
        if (_targetType == TargetType.Body)
        {
            obj = Instantiate(_bodyBulletPrefab, _muzzle.transform.position, Quaternion.Euler(_muzzle.up));
        }
        else if(_targetType == TargetType.Astral)
        {
            obj = Instantiate(_astralBulletPrefab, _muzzle.transform.position, Quaternion.Euler(_muzzle.eulerAngles /*- new Vector3(0, 0, 90)*/));
        }
        else
        {
            obj = Instantiate(_ambiBulletPrefab, _muzzle.transform.position, Quaternion.Euler( _muzzle.eulerAngles + _ambiBulletPrefab.transform.eulerAngles));
        }
        obj.GetComponent<Rigidbody2D>().velocity = _muzzle.transform.right * _bulletSpeed;
    }
}
