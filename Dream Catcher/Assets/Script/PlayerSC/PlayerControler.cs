using UnityEngine;
namespace StarterAssets
{

    public class PlayerControler : MonoBehaviour
    {
        public float _peaceRun = 6.0f;
        public float _fightRun = 3.0f;
        private float moveSpeed;
        public float fireRate = 1.0f;
        private float lastShotTime;
        public GameObject _ArroyPrefab;
        private Rigidbody rbPlayer;
        public Animator animator;


        public Transform arrowPosition;

        private void Start()
        {
            lastShotTime = -fireRate;
            rbPlayer = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            // Замораживаем вращение по осям X, Y и Z
            rbPlayer.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        private void Update()
        {
            if (FightZoneScript._fight)
            {
                moveSpeed = _fightRun;
            }
            else
            {
                moveSpeed = _peaceRun;
            }
            MoveCharacter();



           /* if (Input.GetMouseButton(0))
            {
                Shoot();
            }*/
        }

        private void MoveCharacter()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(movement * moveSpeed * Time.deltaTime);
            animator.SetFloat("Speed", Vector3.ClampMagnitude(movement, 1).magnitude);



            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W) && Time.time - lastShotTime > 1.0f / fireRate)
            {
                animator.SetBool("Hit2", true);
            }
            else
            {
                animator.SetBool("Hit2", false);
            }

        }

        private void Shoot()
        {
            lastShotTime = Time.time;

            // Стрельба из точки, привязанной к объекту, в текущем направлении
            Instantiate(_ArroyPrefab, arrowPosition.position, arrowPosition.rotation);
        }
    }  
}
