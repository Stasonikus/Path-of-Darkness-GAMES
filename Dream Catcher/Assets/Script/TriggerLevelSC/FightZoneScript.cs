using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZoneScript : MonoBehaviour
{
    private bool _fightProverca;

    public static bool _fight; //проверка состояния боя 

    private void Start()
    {
        _fightProverca = false;
        _fight = false; //при запуске боя нет
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
            Debug.Log("Ошибка");
        }
    }
    
    private void OnTriggerEnter(Collider other) //проверка зашел ли ГГ в зону файта
    {
        // Проверяем, является ли соприкоснувшийся объект тем объектом, к которому прикреплен скрипт
        if (other.CompareTag("Player") && this.gameObject == gameObject)
        {
            _fightProverca = true;
        }

    }

    private void OnTriggerExit(Collider other) //проверка вышел ли ГГ за зону файта
    {
        // Проверяем, является ли соприкоснувшийся объект тем объектом, к которому прикреплен скрипт
        if (other.CompareTag("Player") && this.gameObject == gameObject)
        { 
            FightZoneSpawn._spawnedOnce = true;
        }

    }
}
