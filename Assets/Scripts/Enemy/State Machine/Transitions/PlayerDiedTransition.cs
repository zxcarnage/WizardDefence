using UnityEngine;

public class PlayerDiedTransition : Transition
{
    private void Update()
    {
        if (Target == null)
            NeedTransit = true;
    }
}
