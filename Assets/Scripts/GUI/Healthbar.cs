using UnityEngine;

public class Healthbar : Bar
{
    private void OnEnable()
    {
        _player.HealthChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        _player.HealthChanged.RemoveListener(OnValueChanged);
    }
}
