using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Header("���̂ɓ�����e")] GameObject _bodyBulletPrefab = default;
    [SerializeField, Header("���ɓ�����e")] GameObject _astralBulletPrefab = default;
    [SerializeField, Header("�����ɓ�����e")] GameObject _ambiBulletPrefab = default;
    [SerializeField, Header("���e���N�ɓ����邩")] TargetType _targetType = default;
    [SerializeField, Header("���ˊԊu")] float _fireInterval = 0;
    [SerializeField, Header("�e�̑��x")] float _bulletSpeed = 0;
    [SerializeField, Header("�e���ʒu�ƕ���")] Transform _muzzle = default;
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
