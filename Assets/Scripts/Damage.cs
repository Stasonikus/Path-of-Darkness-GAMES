using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int bullet;
        [SerializeField] int arrow;
        [SerializeField] float multi;

        
        public static int _bullet;
        public static int _arrow;
        public static float _multi;
        

        // Start is called before the first frame update
        void Start()
        {
            _bullet = bullet;
            _arrow = arrow;
            _multi = multi;
           

        }
        private void Update()
        {
            
        }


    }
}
