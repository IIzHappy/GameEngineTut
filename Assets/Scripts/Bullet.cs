using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    float _damage;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetUp(Vector2 movement, float damage)
    {
        _rb.linearVelocity = movement;
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyBase>().TakeDamage(_damage);
        Destroy(gameObject);
    }
}
