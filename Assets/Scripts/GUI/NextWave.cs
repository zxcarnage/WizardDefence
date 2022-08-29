using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned.AddListener(OnAllEnemySpawned);
        _button.onClick.AddListener(OnNextWaveButtonClicked);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned.RemoveListener(OnAllEnemySpawned);
        _button.onClick.RemoveListener(OnNextWaveButtonClicked);
    }

    private void OnAllEnemySpawned()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClicked()
    {
        _spawner.NextWave();
        _button.gameObject.SetActive(false);
    }
}
