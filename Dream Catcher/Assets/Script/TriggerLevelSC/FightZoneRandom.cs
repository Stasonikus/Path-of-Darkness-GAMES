using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZoneRandom : MonoBehaviour
{
    [System.Serializable]
    public class FightZoneInfo
    {
        public GameObject platform;
        public bool isActive;
    }

    public FightZoneInfo[] Zons;
    public int maxActivationCount = 7; // ������������ ���������� ��������� ��������

    void Start()
    {
        ActivateRandomObjects();
    }

    void ActivateRandomObjects()
    {
        RemoveActivePlatforms();
        int numberOfObjectsToActivate = Random.Range(7, Mathf.Min(maxActivationCount, Zons.Length) + 1);

        for (int i = 0; i < numberOfObjectsToActivate; i++)
        {
            int randomIndex = Random.Range(0, Zons.Length);

            // ���� ������ ��� �� �����������, ���������� ���
            if (!Zons[randomIndex].isActive)
            {
                Zons[randomIndex].platform.SetActive(true);
                Zons[randomIndex].isActive = true;
            }
            else
            {
                // ���� ������ ��� �����������, �������� ������
                i--;
            }
        }
    }

    void RemoveActivePlatforms()
    {
        foreach (var ZoneInfo in Zons) //��������� �������� ����� platformInfo
        {
            if (ZoneInfo.platform.gameObject.activeSelf) //����, �������� �� ���������
            {
                ZoneInfo.platform.gameObject.SetActive(false);
                ZoneInfo.isActive = false;
            }
        }
    }

}
