using UnityEngine;

public class NoBuildOnBuiltObject : MonoBehaviour
{
    private bool isBuiltUpon = false; // ����, �������������, ���� �� �� ������� ���-�� ���������

    // ����� ��� ��������� ����� isBuiltUpon
    public void SetIsBuiltUpon(bool value)
    {
        isBuiltUpon = value;
    }

    // ��������, ����� �� ������� �� �������
    public bool CanBuild()
    {
        return !isBuiltUpon;
    }
}
