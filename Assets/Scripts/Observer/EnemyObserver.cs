using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class EnemyObserver : Observer
    {
        CarController carController;
        bool enemyHit;

        void Update()
        {
            if (enemyHit)
            {
                Destroy(gameObject);
            }
        }

        public override void Notify(Subject subject)
        {
            if (!carController)
            {
                carController = subject.GetComponent<CarController>();
            }
            else
            {
                enemyHit = true;
            }
        }
    }
}