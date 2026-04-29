using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFire : MonoBehaviour
{
    public GameObject[] bulletPrefab;  // 소품한개 연결
    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
       // 왼쪽 컨트롤키를 누르면 총알을 발사하자
       // 총알을 소품화 시키자 
       // 소품을 복제하자 
       // 복제된 소품의 촬영장에서의 위치를 잡아주자
       if(Input.GetButtonDown("Fire1")==true)
        {
            int rnd = Random.Range(0, 3); // 0,1,2중에서 내PC 땡기는 숫자 보내줌
            GameObject bullet = Instantiate(bulletPrefab[rnd]);
            bullet.transform.position = transform.position;
        }
    }
}
