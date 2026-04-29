using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KTH
{
    public class Enemy : MonoBehaviour
    {
        // 속도 10으로 위에서 아래로 이동하자
        public float speed = 10.0f;

        Transform targetTr;
        Vector3 dir;
        public int probability = 50;     
        // Start is called before the first frame update
        void Start()
        {
            targetTr = GameObject.Find("Player").transform;
            // 일정확률(50%)로 추적을 하거나 아래로 내려오자 


            // 주인공을 쫒아가자 
            // 백터의 차를 이용해서 주인공 방향을 구함

            // 이동공식 
            //Vector3 dir = Vector3.down;
            // P <- E
            int rnd = Random.Range(0, 100); //0~99 임의의 숫자반환
            if (rnd < probability) // 50% 확률
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
    }
}