using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField, Header("“÷‘Ì‚É“–‚½‚é’e")] GameObject _bodyBulletPrefab = default;
    [SerializeField, Header("°‚É“–‚½‚é’e")] GameObject _astralBulletPrefab = default;
    [SerializeField, Header("Œ‚‚Â’e‚ª’N‚É“–‚½‚é‚©")] TargetType _targetType = default;
    [SerializeField, Header("”­ŽËŠÔŠu")] float _fireInterval = 0;
    [SerializeField, Header("’e‚Ì‘¬“x")] float _bulletSpeed = 0;
    [SerializeField, Header("’eŒ‚‚ÂˆÊ’u‚Æ•ûŒü")] Transform _muzzle = default;
    private float _timer = 0;
    private enum TargetType { Body, Astral }

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
            obj = Instantiate(_bodyBulletPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            obj = Instantiate(_astralBulletPrefab, transform.position, Quaternion.identity);
        }
        obj.GetComponent<Rigidbody2D>().velocity = _muzzle.transform.right * _bulletSpeed;
    }
}
