using UnityEngine;

namespace StarterAssets
{
    public class Victory : MonoBehaviour
    {
        public GameObject victory;
        public BosHealth bosHealth; // Переменная для ссылки на компонент BosHealth

        // Update is called once per frame
        void Update()
        {
            if (bosHealth != null && BosHealth._bosHealth <= 0)
            {
                victory.SetActive(true);
            }
        }
    }
}
