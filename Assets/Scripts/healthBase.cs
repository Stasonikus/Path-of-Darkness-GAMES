using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class healthBase : MonoBehaviour
{
    [SerializeField] private int _healthBase;
    [SerializeField] Text HelthBase;

    public int hhealthBase;

    private void Start()
    {
        hhealthBase = _healthBase;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Урон");
            //_healthBase -= 2;
        }    
    }
    private void Update()
    {
        if (_healthBase <= 0)
        {
            SceneManager.LoadScene(1);
        }
        HelthBase.text = _healthBase.ToString();
    }
}
