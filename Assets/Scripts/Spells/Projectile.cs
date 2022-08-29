using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    public int Damage => _damage;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }
        Destroy(gameObject);
    }
}
