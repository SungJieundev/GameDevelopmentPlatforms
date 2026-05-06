using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace KTH
{
    public class Enemy : MonoBehaviour
    {
        // �ӵ� 10���� ������ �Ʒ��� �̵�����
        public float speed = 10.0f;

        Transform targetTr;
        Vector3 dir;
        public int probability = 50;     
        // Start is called before the first frame update
        void Start()
        {
            targetTr = GameObject.Find("Player").transform;
            // ����Ȯ��(50%)�� ������ �ϰų� �Ʒ��� �������� 


            // ���ΰ��� �i�ư��� 
            // ������ ���� �̿��ؼ� ���ΰ� ������ ����

            // �̵����� 
            //Vector3 dir = Vector3.down;
            // P <- E
            int rnd = Random.Range(0, 100); //0~99 ������ ���ڹ�ȯ
            if (rnd < probability) // 50% Ȯ��
            {
                dir = targetTr.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
            transform.up = dir;

        }

        // Update is called once per frame
        void Update()
        {

            transform.position += speed * dir * Time.deltaTime;
        }

        // Rigidbody가 있어 충돌 상황에서 호출
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject); // 자신을 파괴
            
            // Contains: 문자에 포함되어 있는가 / contains로 비교하기보다 태그로 구분
            //if (collision.gameObject.name.Contains("Bullet") == true)
            if (collision.gameObject.tag=="Bullet")
            {
                Destroy(collision.gameObject); // 총알 파괴
            }
            if (collision.gameObject.name.Contains("Player"))
            {
                //플레이어 데미지 처리
            }
        }
    }
}