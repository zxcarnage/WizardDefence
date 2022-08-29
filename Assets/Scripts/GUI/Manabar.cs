using UnityEngine;

public class Manabar : Bar
{
    private void OnEnable()
    {
        _player.ManaChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _player.ManaChanged.RemoveListener(OnValueChanged);
    }
}
