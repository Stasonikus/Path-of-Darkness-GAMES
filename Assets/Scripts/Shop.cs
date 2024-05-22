using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{


    public class Shop : MonoBehaviour
    {
        [SerializeField] int ArrcherCost;
        [SerializeField] GameObject tower;
        public int money;
        
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            money = Money.Instance._money;
            if (money >= ArrcherCost)
            {
                tower.SetActive(true);
            }
            if (money < ArrcherCost)
            {
                tower.SetActive(false);
            }
        }
        public void ArowTower()
        {
            Money.Instance._money -= 70;

        } 
        public void IceTower()
        {
            Money.Instance._money -= 150;
        } 
        public void MagicTower()
        {
            Money.Instance._money -= 300;    
        } 
        public void MortirTower()
        {
            Money.Instance._money -= 90;
        }
    }
}