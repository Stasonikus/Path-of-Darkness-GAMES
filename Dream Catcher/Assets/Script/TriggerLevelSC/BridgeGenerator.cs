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
    public int maxActivationCount = 5; // ������������ ���������� ��������� ��������

    void Start()
    {
        ActivateRandomObjects();
    }

    void ActivateRandomObjects()
    {
        RemoveActivePlatforms();

        int numberOfObjectsToActivate = Random.Range(2, Mathf.Min(maxActivationCount, bridge.Length) + 1); // ������� ��������� ����� � ��������� �� 2 �� ��������, ������� �������� ��������� ����� ������������ ������ ��������� � ����� ����������� �������� � �������.

        for (int i = 0; i < numberOfObjectsToActivate; i++)
        {
            int randomIndex = Random.Range(0, bridge.Length);

            // ���� ������ ��� �� �����������, ���������� ���
            if (!bridge[randomIndex].isActive)
            {
                bridge[randomIndex].platform.SetActive(true);
                bridge[randomIndex].isActive = true;
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
        foreach (var platformInfo in bridge) //��������� �������� ����� platformInfo
        {
            if (platformInfo.platform.gameObject.activeSelf) //����, �������� �� ���������
            {
                platformInfo.platform.gameObject.SetActive(false);
                platformInfo.isActive = false;
            }
        }
    }

}
