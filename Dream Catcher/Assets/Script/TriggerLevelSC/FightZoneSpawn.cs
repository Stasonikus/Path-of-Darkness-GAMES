using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FightZoneSpawn : MonoBehaviour
{
    private bool _maySpawn = true; // ����� ���������
    public static bool _spawnedOnce = false; // ����� ��� ��� ��������
    private bool _increaseOnce = true;

    private int _zoneCounter;   //������� ���������� ���
    private bool _allEnemiesDead; //��� �����

    public static event System.Action<int> ZoneCompleted;


    public GameObject _Enemy_1;
    public GameObject _Enemy_2;
    public GameObject _Enemy_3;
    public int _min_GUL_ToSpawn = 1;
    public int _max_GUL_ToSpawn = 2;
    public int _min_TOAD_ToSpawn = 3;
    public int _max_TOAD_ToSpawn = 4;
    public int _min_GHOST_ToSpawn = 5;
    public int _max_GHOST_ToSpawn = 7;

    public List<GameObject> _spawnedObjects = new List<GameObject>();

    private void Start()
    {
        _zoneCounter = 0;
    }

    private void Update()
    {

        if (FightZoneScript._fight && !_maySpawn) // ��������� ������� _canSpawn
        {
            _maySpawn = true;
            SpawnObjects();
        }

        else if (!FightZoneScript._fight)
        {
            _maySpawn = false;
            RemoveSpawnedObjects();
        }
        AreAllEnemiesDead(); 
        //Debug.Log(_zoneCounter);

        /*if (_allEnemiesDead)
        {
            if (_increaseOnce)
            {
                _zoneCounter += 1;
                _increaseOnce = false;

                // �������� ������� ZoneCompleted, ��������� ������� �������� �������� ���
                ZoneCompleted?.Invoke(_zoneCounter);
            }
        }
        else
        {
            _increaseOnce = true;
        }*/
    }


    void SpawnObjects()
    {
        // ������� ������ ��� ������ ����� ������
        RemoveSpawnedObjects();

        // �������� ����� ��� ������� ���� ����� � ��������� ����������
        SpawnObjectsOfType(_Enemy_1, _min_GUL_ToSpawn, _max_GUL_ToSpawn);
        SpawnObjectsOfType(_Enemy_2, _min_TOAD_ToSpawn, _max_TOAD_ToSpawn);
        SpawnObjectsOfType(_Enemy_3, _min_GHOST_ToSpawn, _max_GHOST_ToSpawn);
    }

    void SpawnObjectsOfType(GameObject enemyPrefab, int minToSpawn, int maxToSpawn)
    {
        int numberOfEnemiesToSpawn = Random.Range(minToSpawn, maxToSpawn + 1);

        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            SpawnObjectWithUniquePosition(enemyPrefab);
        }
    }

    void SpawnObjectWithUniquePosition(GameObject enemyPrefab)
    {
        Vector3 spawnPosition = GenerateRandomSpawnPosition();

        // ������� ������
        GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        _spawnedObjects.Add(enemyObject); // ��������� ��������� ������ � ������
    }

    void RemoveSpawnedObjects()
    {
        // ������� ��� ��������� ������� �� ������ � �� �����
        foreach (var obj in _spawnedObjects)
        {
            Destroy(obj);
        }

        // ������� ������
        _spawnedObjects.Clear();
    }

    Vector3 GenerateRandomSpawnPosition()
    {
        // �������� ��������� ���������� � �������� ��������
        float randomX = Random.Range(transform.position.x - transform.localScale.x / 2 + 20, transform.position.x + transform.localScale.x / 2 - 20);
        float randomY = transform.position.y; // ������ ��������, ���� ����� ����������� ������
        float randomZ = Random.Range(transform.position.z - transform.localScale.z / 2 + 20, transform.position.z + transform.localScale.z / 2 - 20);

        return new Vector3(randomX, randomY, randomZ);
    }
    void AreAllEnemiesDead()
    {

        foreach (var obj in _spawnedObjects)
        {
            if (obj != null && obj.activeSelf)
            {
                _allEnemiesDead = false;
            }
            else
            {
                _allEnemiesDead = true;

            }
        }

    }
}