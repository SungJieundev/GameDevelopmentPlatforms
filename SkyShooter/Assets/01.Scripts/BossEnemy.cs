using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private bool bLeft = true;
    private Vector3 dir = Vector3.left;

    private float createTime = 2.0f;
    private float currentTime = 0.0f;
    public GameObject bulletPrefab;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        BossMove();
        BossFire();
    }
    
    void BossMove()
    {
        if (transform.position.x <= -5.0f)
        {
            bLeft = false;
            dir = Vector3.right;
        }

        if (transform.position.x >= 5.0f)
        {
            bLeft = true;
            dir = Vector3.left;
        }
        
        transform.position += 5.0f * dir * Time.deltaTime;
    }

    
    // 일정 시간마다 총알을 서클 형태로 발사 (2초) 
    void BossFire()
    {
        // 일정 시간이 지났을 때
        currentTime += Time.deltaTime;
        
        if (currentTime > createTime)
        {
            for (int i = 0; i < 36; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.transform.eulerAngles = new Vector3(0.0f, 0.0f, i * 10.0f);
            }
            
            currentTime = 0.0f;
        }
    }
}
