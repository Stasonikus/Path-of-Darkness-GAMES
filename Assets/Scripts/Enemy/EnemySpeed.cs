using UnityEngine;

namespace StarterAssets
{
    public class EnemySpeed : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _currentSpeed;

        // Start is called before the first frame update
        void Start()
        {
            _currentSpeed = _speed;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
        }

        // Метод для установки новой скорости
        public void SetSpeed(float speed)
        {
            _currentSpeed = speed;
        }

        // Метод для возврата к оригинальной скорости
        public void ResetSpeed()
        {
            _currentSpeed = _speed;
        }

        // Метод для получения оригинальной скорости
        public float GetOriginalSpeed()
        {
            return _speed;
        }
    }
}
