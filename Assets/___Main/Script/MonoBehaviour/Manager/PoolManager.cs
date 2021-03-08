using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _bulletPoolCount;
    private Queue<Bullet> _bullets;


    public Bullet ShootBullet(Vector3 position, Quaternion rotation, Vector3 moveDirection)
    {
        Bullet bullet = _bullets.Dequeue();
        bullet.Shoot(position, rotation, moveDirection);
        _bullets.Enqueue(bullet);
        return bullet;
    }


    private void Awake()
    {
        InitBulletPool();
    }

    private void InitBulletPool()
    {
        _bullets = new Queue<Bullet>();
        for (int i = 0; i < _bulletPoolCount; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bullets.Enqueue(bullet);
        }
    }
}
