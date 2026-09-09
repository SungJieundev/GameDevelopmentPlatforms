using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    public float speed = 5.0f;
    private Joystick joystick; // 조이스틱 에셋의 클래스
    
    // Start is called before the first frame update
    void Start()
    {
        // Joystick을 가지고 있는 오브젝트 반환
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update() // 1초에 200번
    {
        Vector2 v = GetInput(); // 입력을 받는다
        

         Vector3 dir = GetDir(v);  // 빙향을 구한다
         Moving(dir);   // 움직인다

        //Moving(GetDir(GetInput()));
    }

    Vector2 GetInput()
    {
        // joystick -1 0 1
        // ����Ű�� �Է¹޾Ƽ� �����¿� ������ ����
        float h = Input.GetAxis("Horizontal") + joystick.Horizontal;// -1 0 1
        float v = Input.GetAxis("Vertical") + joystick.Vertical; // Ű�� �ȴ������´� 0��ȯ ����Ű�� -1 ������Ű 1
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
