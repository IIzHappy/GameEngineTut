using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    Rigidbody2D _rb;

    [SerializeField] float _moveSpeed = 10;
    Vector2 _moveDir = Vector2.zero;

    bool _isShooting;
    [SerializeField] float _shootDelay = 0.5f;
    float _shootTimer = 0;

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
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        Move();
        if (_isShooting)
        {
            Shoot();
        }
    }

    void GetInput()
    {
        _moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveDir.y++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveDir.y--;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveDir.x--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveDir.x++;
        }
        _isShooting = Input.GetKey(KeyCode.Mouse0);
    }
    void Move()
    {
        _rb.linearVelocity = _moveDir.normalized * _moveSpeed;
        EnemyManager.instance.UpdatePlayerPos(gameObject.transform.position);
    }

    void Shoot()
    {
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _shootDelay)
        {
            _shootTimer = 0;
            BulletManager.instance.SpawnBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
        }
    }
}
