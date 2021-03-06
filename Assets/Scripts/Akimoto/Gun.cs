using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Header("肉体に当たる弾")] GameObject _bodyBulletPrefab = default;
    [SerializeField, Header("魂に当たる弾")] GameObject _astralBulletPrefab = default;
    [SerializeField, Header("両方に当たる弾")] GameObject _ambiBulletPrefab = default;
    [SerializeField, Header("撃つ弾が誰に当たるか")] TargetType _targetType = default;
    [SerializeField, Header("発射間隔")] float _fireInterval = 0;
    [SerializeField, Header("弾の速度")] float _bulletSpeed = 0;
    [SerializeField, Header("弾撃つ位置と方向")] Transform _muzzle = default;
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
