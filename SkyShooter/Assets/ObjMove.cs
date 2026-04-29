using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    //public 을 붙이면 에디터에 표시가 됨
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // 1초에 200번 돈다   
    {
        Vector2 v = GetInput(); // 입력을 받는다.
        

         Vector3 dir = GetDir(v);  // 방향을 구한다.
         Moving(dir);   // 움직인다.

        //Moving(GetDir(GetInput()));
    }

    Vector2 GetInput()
    {
        // 방향키를 입력받아서 상하좌우 움직여 보자
        float h = Input.GetAxis("Horizontal");// -1 0 1
        float v = Input.GetAxis("Vertical");// 키가 안눌린상태는 0반환 왼쪽키는 -1 오른쪽키 1
        //    print("입력값은: " + v);// 디버그창 출력
        return new Vector2(h, v);
    }

    Vector3 GetDir(Vector2 v)
    {
        // 백터의 합을 이용하여 방향을 구하자
        // 백터를 강제적으로 크기를 1로 바꾸자 Normalize(정규화)
        Vector3 dir = v.x * Vector3.right + v.y * Vector3.up;
        dir.Normalize();//크기가 1로 변함
        return dir;
    }
    void Moving(Vector3 dir)
    {
        transform.position += speed * dir * Time.deltaTime;
    }    
}
