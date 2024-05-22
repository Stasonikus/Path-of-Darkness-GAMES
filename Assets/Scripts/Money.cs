using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{



    public class Money : MonoBehaviour
    {
        [SerializeField] GameObject[] enemy;
        [SerializeField] int ArrcherCost = 50;
        public int _ArrcherCost;
        public Text textMoney;
        public int _money;
        public static Money Instance;
        public string Level = "Level";
        private GameObject[] objectsWithTag;
        void Start()
        {
            _ArrcherCost = ArrcherCost;
            objectsWithTag = GameObject.FindGameObjectsWithTag(Level);
        }

        

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        // Update is called once per frame
        void Update()
        {
            textMoney.text = _money.ToString();

            



        }

    }
}
