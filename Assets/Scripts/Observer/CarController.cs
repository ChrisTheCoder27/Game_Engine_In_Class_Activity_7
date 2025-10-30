using UnityEngine;

namespace Chapter.Observer
{
    public class CarController : Subject
    {
        [SerializeField] float maxSpeed;
        EnemyObserver enemyObserver;

        void Awake()
        {
            enemyObserver = gameObject.AddComponent<EnemyObserver>();
        }

        void OnEnable()
        {
            if (enemyObserver)
            {
                Attach(enemyObserver);
            }
        }

        void OnDisable()
        {
            if (enemyObserver)
            {
                Detach(enemyObserver);
            }
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                AccelerateForward();
            }

            if (Input.GetKey(KeyCode.A))
            {

            }

            if (Input.GetKey(KeyCode.D))
            {

            }
        }

        public void AccelerateForward()
        {
            transform.position += new Vector3(0, 0, maxSpeed * Time.deltaTime);
        }

        public void HitEnemy()
        {
            NotifyObservers();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                HitEnemy();
            }
        }

    }
}