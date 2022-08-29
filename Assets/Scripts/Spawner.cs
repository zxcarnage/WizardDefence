using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    
    private Wave _currentWave;
    private int _currentWaveNum = 0;
    private int _enemySpawned;
    private float _lastSpawnTimePassed;

    public UnityEvent AllEnemySpawned;

    private void Start()
    {
        SetWave(_currentWaveNum);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;
        _lastSpawnTimePassed += Time.deltaTime;

        if(_lastSpawnTimePassed >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _lastSpawnTimePassed = 0;
            _enemySpawned++;
        }

        if(_currentWave.EnemyCount <= _enemySpawned)
        {
            if(_waves.Count > _currentWaveNum+1)
                AllEnemySpawned.Invoke();
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        var enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Died.AddListener(OnEnemyDied);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    public void NextWave()
    {
        _enemySpawned = 0;
        SetWave(++_currentWaveNum);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died.RemoveListener(OnEnemyDied);
        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int EnemyCount;
}

