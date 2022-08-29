using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Target == null)
            _animator.Play("Idle");
        else
        {
            _animator.Play("Walk");
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
        
    }
}
