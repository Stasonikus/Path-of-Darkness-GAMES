using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider scale;
    public GameObject remove;
    public GameObject credits;

    public void Loading()
    {
        remove.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(DelayedLoad());
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSeconds(1f); // ������������� �������� ����� ������� ��������
        yield return StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        while (!loadAsync.isDone)
        {
            scale.value = loadAsync.progress;
            yield return null;
            
        }

        // ���������, ��� �������� �������� ������ 100%
        if (scale.value < 1f)
        {
            yield return new WaitForSeconds(3f);
            yield return null;
        }

        // ��������� �������� � 2 ������� ����� �������� �� 100%
        Debug.Log("Before delay"); // ��������, ��� ��� ����� �� ���� �����
       
        Debug.Log("After delay"); // ��������, ��� ��� ������ ����� ��������

        // ����� ��������� �������������� �������� ����� ��������
    }
     public  void Credits()
    {
        remove.SetActive(false);
        credits.SetActive(true);
    }

   public void Back()
    {
        remove.SetActive(true);
        credits.SetActive(false);
    }
}
