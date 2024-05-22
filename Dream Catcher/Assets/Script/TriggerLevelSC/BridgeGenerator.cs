using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeGenerator : MonoBehaviour
{
    [System.Serializable]
    public class PlatformInfo
    {
        public GameObject platform;
        public bool isActive;
    }

    public PlatformInfo[] bridge;
    public int maxActivationCount = 5; // Максимальное количество включения объектов

    void Start()
    {
        ActivateRandomObjects();
    }

    void ActivateRandomObjects()
    {
        RemoveActivePlatforms();

        int numberOfObjectsToActivate = Random.Range(2, Mathf.Min(maxActivationCount, bridge.Length) + 1); // создает случайное число в диапазоне от 2 до значения, которое является минимумом между максимальным числом активации и общим количеством объектов в массиве.

        for (int i = 0; i < numberOfObjectsToActivate; i++)
        {
            int randomIndex = Random.Range(0, bridge.Length);

            // Если объект еще не активирован, активируем его
            if (!bridge[randomIndex].isActive)
            {
                bridge[randomIndex].platform.SetActive(true);
                bridge[randomIndex].isActive = true;
            }
            else
            {
                // Если объект уже активирован, выбираем другой
                i--;
            }
        }
    }

    void RemoveActivePlatforms()
    {
        foreach (var platformInfo in bridge) //переборка платформ через platformInfo
        {
            if (platformInfo.platform.gameObject.activeSelf) //если, включены то выключить
            {
                platformInfo.platform.gameObject.SetActive(false);
                platformInfo.isActive = false;
            }
        }
    }

}
