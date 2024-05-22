using UnityEngine;

namespace StarterAssets
{
    public class EnemyRouteLogic : MonoBehaviour
    {
        [SerializeField] private float speed;
        //[SerializeField] private Transform Enemy;
        [SerializeField] private float rotSpeed = 5f;
        

        [HideInInspector] public float _speed;
        public Transform[] waypoints; // ������ ����� ��������
        private int currentWaypointIndex = 0; // ������ ������� ����� ��������

        private void Start()
        {
            _speed = speed;
        }

        private void Update()
        {
            if (waypoints.Length == 0)
            {
                Debug.LogError("�� ������ ����� ��������!");
                return;
            }

            MoveToWaypoint();
        }

        private void MoveToWaypoint()
        {
            // ��������� ����������� � ������� ����� ��������
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.y = 0f; // ���������� ������������ �����������

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