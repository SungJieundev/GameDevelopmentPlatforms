using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KTH
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 10.0f;
        public int probability = 50;
        public float rotSpeed = 3.0f;

        Transform targetTr;
        Vector3 dir;

        void Start()
        {
            targetTr = GameObject.Find("Player").transform;

            int rnd = Random.Range(0, 100);
            if (rnd < probability)
            {
                dir = targetTr.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }

        void Update()
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
            transform.position += speed * dir * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);

            if (collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.name.Contains("Player"))
            {
                // Player damage handling can be added here.
            }
        }
    }
}
