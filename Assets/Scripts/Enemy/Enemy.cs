using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;

    private Player _target;
    private Animator _animator;

    public Player Target => _target;
    public int Reward => _reward;

    public UnityEvent<Enemy> Died;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        _animator.Play("Hurt");

        if (_health <= 0)
        {
            Die();
            Died.Invoke(this);
        } 
    }

    private void Die()
    {
        _animator.Play("Death");
        _target.FullfillMana();
        Destroy(gameObject);

    }

    public void Init(Player player)
    {
        _target = player;
    }
    
}
