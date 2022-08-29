using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _rangeSpread += Random.Range(-_transitionRange, _transitionRange);
    }

    private void Update()
    {
        if (Target == null)
            return;
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransit = true;
    }
}
