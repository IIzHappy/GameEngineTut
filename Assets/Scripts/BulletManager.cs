using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    [SerializeField] GameObject _bulletParent;
    [SerializeField] GameObject _bullet;

    public float _bulletSpeed = 15;
    public float _bulletDamage = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (_bulletParent == null)
        {
            _bulletParent = gameObject;
        }
    }

    public void SpawnBullet(Vector2 direction)
    {
        Bullet bullet = Instantiate(_bullet, PlayerController.instance.gameObject.transform.position, Quaternion.identity, _bulletParent.transform).GetComponent<Bullet>();
        bullet.SetUp(direction.normalized * _bulletSpeed, _bulletDamage);
    }
}
