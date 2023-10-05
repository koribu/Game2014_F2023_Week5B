using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private int _bulletTotal = 50;

    Queue<GameObject> _bulletPool = new Queue<GameObject>();

    GameObject _bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        PoolBuilder();
    }

    void PoolBuilder()
    {
        // take how many bullet we want
        // Create that amount of bullet

        for (int i = 0; i < _bulletTotal; i++)
        {
            //Create a bullet
            CreateBullet();
        }

    }

    void CreateBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab);
        bullet.transform.parent = transform;
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);

    }

    public GameObject GetBullet()
    {
        GameObject bullet = _bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}
