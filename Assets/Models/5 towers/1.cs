using UnityEngine;

public class NoBuildOnBuiltObject : MonoBehaviour
{
    private bool isBuiltUpon = false; // Флаг, отслеживающий, было ли на объекте что-то построено

    // Метод для установки флага isBuiltUpon
    public void SetIsBuiltUpon(bool value)
    {
        isBuiltUpon = value;
    }

    // Проверка, можно ли строить на объекте
    public bool CanBuild()
    {
        return !isBuiltUpon;
    }
}
