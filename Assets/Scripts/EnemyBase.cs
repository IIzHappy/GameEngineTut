using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField] float _maxHp = 2;
    float _curHP;

    [SerializeField] float _moveSpeed = 8;
    [SerializeField] float _hitDistance = 2;
    [SerializeField] float _hitDelay = 1;
    float _hitTimer;

    Vector2 _playerPos;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _curHP = _maxHp;
    }

    public void GetPlayerPos(Vector2 playerPos)
    {
        _playerPos = playerPos;
    }

    public void Update()
    {
        Vector3 pos = gameObject.transform.position;
        Vector2 playerPos = _playerPos - new Vector2(pos.x, pos.y);
        if (playerPos.magnitude <= _hitDistance)
        {
            _rb.linearVelocity = Vector2.zero;
        }
        else
        {
            _rb.linearVelocity = playerPos.normalized * _moveSpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        _curHP -= damage;
        if (_curHP <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //Could add point system
        EnemyManager.instance.RemoveEnemy(this);
    }
}
