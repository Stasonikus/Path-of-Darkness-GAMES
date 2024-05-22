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
        yield return new WaitForSeconds(1f); // Искусственная задержка перед началом загрузки
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

        // Проверяем, что прогресс загрузки достиг 100%
        if (scale.value < 1f)
        {
            yield return new WaitForSeconds(3f);
            yield return null;
        }

        // Добавляем задержку в 2 секунды после загрузки на 100%
        Debug.Log("Before delay"); // Проверка, что код дошел до этой точки
       
        Debug.Log("After delay"); // Проверка, что код прошел через задержку

        // Можно выполнить дополнительные действия после ожидания
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
