using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    //public �� ���̸� �����Ϳ� ǥ�ð� ��
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // 1�ʿ� 200�� ����   
    {
        Vector2 v = GetInput(); // �Է��� �޴´�.
        

         Vector3 dir = GetDir(v);  // ������ ���Ѵ�.
         Moving(dir);   // �����δ�.

        //Moving(GetDir(GetInput()));
    }

    Vector2 GetInput()
    {
        // ����Ű�� �Է¹޾Ƽ� �����¿� ������ ����
        float h = Input.GetAxis("Horizontal");// -1 0 1
        float v = Input.GetAxis("Vertical");// Ű�� �ȴ������´� 0��ȯ ����Ű�� -1 ������Ű 1
        //    print("�Է°���: " + v);// �����â ���
        return new Vector2(h, v);
    }

    Vector3 GetDir(Vector2 v)
    {
        // ������ ���� �̿��Ͽ� ������ ������
        // ���͸� ���������� ũ�⸦ 1�� �ٲ��� Normalize(����ȭ)
        Vector3 dir = v.x * Vector3.right + v.y * Vector3.up;
        dir.Normalize();//ũ�Ⱑ 1�� ����
        return dir;
    }
    void Moving(Vector3 dir)
    {
        transform.position += speed * dir * Time.deltaTime;

        // 플레이어의 움직임을 제한하기 (Clipping 클리핑 처리)
        Vector3 pos = transform.position;
        
        // 1) if를 사용하는 방법
        // if (pos.x > 6.0f) pos.x = 6.0f;
        // if (pos.x < -6.0f) pos.x = -6.0f;
        // if (pos.y > 10.5f) pos.y = 10.5f;
        // if (pos.y < -8.5f) pos.y = -8.5f;
        
        // 2) Clamp를 사용하는 방법
        // pos.x = Mathf.Clamp(transform.position.x, -6.0f, 6.0f);
        // pos.y = Mathf.Clamp(transform.position.y, -8.5f, 10.5f);
        
        // * 직접 구현한 Clamp 사용 *
        pos.x = MyClamp(transform.position.x, -6.0f, 6.0f);
        pos.y = MyClamp(transform.position.y, -8.5f, 10.5f);
        transform.position = pos;
    }

    // 직접 CLamp함수 구현해보기
    float MyClamp(float value, float min, float max)
    {
        float returnValue = value;
        if (value < min) returnValue = min;
        if (value > max) returnValue = max;
        
        return returnValue;
    }
}
