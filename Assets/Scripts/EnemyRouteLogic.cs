using UnityEngine;

namespace EmenyLogic
{
    public class EnemyRouteLogic : MonoBehaviour
    {
        [SerializeField] private float speed;
<<<<<<< Updated upstream
=======
        [SerializeField] private Transform Enemy;
        [SerializeField] private float rotSpeed = 5f;
>>>>>>> Stashed changes

        public float _speed;
        public Transform[] waypoints; // ������ ����� ��������
        private int currentWaypointIndex = 0; // ������ ������� ����� ��������

        private void Start()
        {
            _speed = speed;
            
        }
        void Update()
        {
            if (waypoints.Length == 0)
            {
                Debug.LogError("�� ������ ����� ��������!");
                return;
            }

            MoveToWaypoint();
        }

        void MoveToWaypoint()
        {
            // ��������� ����������� � ������� ����� ��������
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction = Vector3.ProjectOnPlane(direction, Vector3.up); // ���������� ������������ �����������

            // ���� �������� ������� ����� ��������, �������� ��������� �����
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                // ���� �� ��������, ��������� � ������������� �����
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, _speed * Time.deltaTime);
            }

            // ������������ ������ � ������� ������� ����� ��������
            RotateTowardsDirection(direction);
        }

        private void RotateTowardsDirection(Vector3 direction)
        {
<<<<<<< Updated upstream
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f);
=======
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
            }
>>>>>>> Stashed changes
        }
    }
}