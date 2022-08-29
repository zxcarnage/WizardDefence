using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        Target.ApplyDamage(_damage);
        _animator.Play("Attack");
    }
}
