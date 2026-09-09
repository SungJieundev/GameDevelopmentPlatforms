using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

    public class Enemy : MonoBehaviour
    {
        public float speed = 10.0f;
        public int probability = 50;
        public float rotSpeed = 3.0f;

        Transform targetTr;
        Vector3 dir;
    
        public GameObject explosionPrefab;

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
                GameObject explosion = Instantiate(explosionPrefab);
                explosion.transform.position = transform.position;
                
                Destroy(collision.gameObject);
                UIScoreManager.instance.score += 10;
                UIScoreManager.instance.SetScore();

                UIScoreManager.instance.killCnt++;
                if (UIScoreManager.instance.killCnt == 10)
                {
                    UIScoreManager.instance.bossEnemy.SetActive(true);
                    
                }
            }

            if (collision.gameObject.name.Contains("Player"))
            {
                // 플레이어 데미지 처리
                PlayerFire pf = collision.gameObject.GetComponent<PlayerFire>();

                pf.nHp--; //체력 1 감소
                pf.SetHp();
                
                if (pf.nHp <= 0)
                {
                    // 사망 시 씬 다시 시작하기
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    
                    // 재시작 버튼 활성화
                    pf.reStartImage.gameObject.SetActive(true);
                }
            }
        }
    }


