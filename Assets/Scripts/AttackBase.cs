using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AttackBase : MonoBehaviour
{
    
    [SerializeField] Text HelthBase;
    public int hhealthBase = 10;
    public string enemyTag = "Enemy"; // Тег для врагов

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Destroy(other.gameObject);
            hhealthBase -= 2;
            
        }
    }
    private void Start()
    {
 
    }
    private void Update()
    {
        if (hhealthBase <= 0)
        {
            SceneManager.LoadScene(1);
        }
        HelthBase.text = hhealthBase.ToString();
    }
}
