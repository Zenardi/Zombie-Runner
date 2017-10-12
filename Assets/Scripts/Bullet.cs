using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRunner.Ammo
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed = 15;
        private Rigidbody _rigidbody;
        private float _timeLeft = 15000; //destroy bullet after 5 secs

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidbody.velocity = transform.forward * bulletSpeed;

            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0)
            {
                Debug.Log("Bullet destroyed by time");

                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Zombie>())
            {
                Debug.Log("Bullet destroyed by zombie collision");
                Destroy(this.gameObject);
            }
        }
    }
}
