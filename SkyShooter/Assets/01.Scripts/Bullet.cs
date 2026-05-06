using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 이동공식   // 위로 이동하자
        // p = p0 + s*d*t   // p = p0+ VT
        // 목표위치  = 현재위치 + (속도(속력*방향))*시간
        transform.position += speed * transform.up * Time.deltaTime;
    }
}
