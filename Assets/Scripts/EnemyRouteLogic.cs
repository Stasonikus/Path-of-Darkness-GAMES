using UnityEngine;

namespace StarterAssets
{
    public class EnemyRouteLogic : MonoBehaviour
    {
        [SerializeField] private float speed;
        //[SerializeField] private Transform Enemy;
        [SerializeField] private float rotSpeed = 5f;
        

        [HideInInspector] public float _speed;
        public Transform[] waypoints; // Массив точек маршрута
        private int currentWaypointIndex = 0; // Индекс текущей точки маршрута

        private void Start()
        {
            _speed = speed;
        }

        private void Update()
        {
            if (waypoints.Length == 0)
            {
                Debug.LogError("Не заданы точки маршрута!");
                return;
            }

            MoveToWaypoint();
        }

        private void MoveToWaypoint()
        {
            // Вычисляем направление к текущей точке маршрута
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.y = 0f; // Игнорируем вертикальное направление

            // Если достигли текущей точки маршрута, выбираем следующую точку
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                // Если не достигли, двигаемся к промежуточной точке
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, _speed * Time.deltaTime);
            }

            // Поворачиваем объект в сторону текущей точки маршрута
            RotateTowardsWaypoint(direction);
        }

        private void RotateTowardsWaypoint(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
            }
        }
    }
}