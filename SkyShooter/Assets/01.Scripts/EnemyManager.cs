using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // deltaTime을 누적시킬 변수
    float currentTime =0.0f;
    public float createTime = 1.0f;
    // Update is called once per frame
    void Update()
    {
        //deltaTime을 계속 누적해서 더해줌
        currentTime += Time.deltaTime;

        // 왼쪽 컨트롤키를 눌렀을때 생성을 하자 
       //if(Input.GetButtonDown("Fire1")==true) // 키가 눌렸으면
       if( currentTime > createTime)  // 1초가 지났다
        {
            //GameObject obj(복제품) = Instantiate(소품의 원본);
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;

            currentTime = 0.0f; //
        }


    }
}
