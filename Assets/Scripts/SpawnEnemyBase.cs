using System;
using System.Collections;
using UnityEngine;

public class SpawnEnemyBase : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    [SerializeField] private SpawnController[] _spawnController;

    public SpawnController[] SpawnController { get => _spawnController; }

    public event Action<int> WaveCompleted; // �������, ���������� ��� ���������� �����

    private int _currentWaveIndex; // ������ ������� �����
    private int _enemiesLeftToSpawn; // ���������� ���������� ��� ������ ������ � ������� �����

    private void Start()
    {
        _currentWaveIndex = 0;
        StartCoroutine(SpawnEnemiesInWave());
    }

    private IEnumerator SpawnEnemiesInWave()
    {
        _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;

        foreach (var setting in _waves[_currentWaveIndex].WaveSettings)
        {
            yield return new WaitForSeconds(setting._spawnDelay);

            Instantiate(setting._enemy, setting._needSpawner.transform.position, Quaternion.identity);

            _enemiesLeftToSpawn--;
        }

        // �������� ������� � ���������� �����
        OnWaveCompleted(_currentWaveIndex);

        // ���������, ���� �� ��� ����� ��� ������
        if (_currentWaveIndex < _waves.Length - 1)
        {
            _currentWaveIndex++;
            yield return new WaitForSeconds(1f); // ��������� �������� ����� �������
            StartCoroutine(SpawnEnemiesInWave());
        }
    }

    private void OnWaveCompleted(int waveIndex)
    {
        WaveCompleted?.Invoke(waveIndex);
    }

    
   
}

[System.Serializable]
public class Waves
{
    [SerializeField] private WaveSetting[] _waveSettings;
    public WaveSetting[] WaveSettings { get => _waveSettings; }
}

[System.Serializable]
public class WaveSetting
{
    public GameObject _enemy;
    public GameObject _needSpawner;
    public float _spawnDelay;
}
