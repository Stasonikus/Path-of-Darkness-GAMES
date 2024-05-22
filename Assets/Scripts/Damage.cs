using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarterAssets
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int bullet;
        [SerializeField] int arrow;
        [SerializeField] int multi;
        [SerializeField] int chiken;
        [SerializeField] int dog;
        [SerializeField] int horse;
        [SerializeField] int knight;
        [SerializeField] int mage;
        [SerializeField] int pig;

        public static int _bullet;
        public static int _arrow;
        public static int _multi;
        public static int _chiken;
        public static int _dog;
        public static int _horse;
        public static int _knight;
        public static int _mage;
        public static int _pig;

        // Start is called before the first frame update
        void Start()
        {
            _bullet = bullet;
            _arrow = arrow;
            _multi = multi;
            _chiken = chiken;
            _dog = dog;
            _horse = horse;
            _knight = knight;
            _mage = mage;
            _pig = pig;

        }


    }
}
