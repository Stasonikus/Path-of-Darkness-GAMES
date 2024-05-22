using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZoneScript : MonoBehaviour
{
    private bool _fightProverca;

    public static bool _fight; //�������� ��������� ��� 

    private void Start()
    {
        _fightProverca = false;
        _fight = false; //��� ������� ��� ���
    }
    private void Update()
    {
        Fight();
    }

    void Fight()
    {
        if (_fightProverca == true)
        {
            _fight = true;
        }
        else if (_fightProverca == false)
        {
            _fight = false;
        }
        else
        {
            Debug.Log("������");
        }
    }
    
    private void OnTriggerEnter(Collider other) //�������� ����� �� �� � ���� �����
    {
        // ���������, �������� �� ���������������� ������ ��� ��������, � �������� ���������� ������
        if (other.CompareTag("Player") && this.gameObject == gameObject)
        {
            _fightProverca = true;
        }

    }

    private void OnTriggerExit(Collider other) //�������� ����� �� �� �� ���� �����
    {
        // ���������, �������� �� ���������������� ������ ��� ��������, � �������� ���������� ������
        if (other.CompareTag("Player") && this.gameObject == gameObject)
        { 
            FightZoneSpawn._spawnedOnce = true;
        }

    }
}
