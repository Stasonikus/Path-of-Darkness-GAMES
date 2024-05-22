using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morture : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 5; // Радиус поиска.
    [SerializeField] private float fireRate = 1.0f; // Время выстрела.
    [SerializeField] private float lastShootTime;

    public GameObject[] targetTransforms;
    bool playerDetected = false;
    public Transform SpawnTransform;
    public string targetTag = "Enemy";

    public float AngleInDegrees;
    float g = Physics.gravity.y;

    [SerializeField] private Rigidbody Bullet;

    void Update()
    {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);

        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, detectionRadius); // Делаем радиус поиска.
        foreach (Collider collider in hitcolliders)
        {
            if (collider.CompareTag(targetTag)) // Проверяем тег цели
            {
                playerDetected = true;
                Debug.Log("Выстрел");
                Shot(collider.transform); // Передаем трансформ цели, которую нужно атаковать
                break;
            }
        }
        if (!playerDetected)
        {
            Debug.Log("Нету цели");  // Выполняем ту часть, когда цель выходит из радиуса
        }
    }

    private void OnDrawGizmos() // Делаем радиус видимым.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void Shot(Transform target)
    {
        Vector3 fromTo = target.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        if (Time.time - lastShootTime > fireRate)
        {
            lastShootTime = Time.time; // Скидываем время
            Rigidbody newBullet = Instantiate(Bullet, SpawnTransform.position, Quaternion.identity);
            newBullet.velocity = SpawnTransform.forward * v;
        }
    }

    private void Start()
    {
        lastShootTime = -fireRate;
    }
}
