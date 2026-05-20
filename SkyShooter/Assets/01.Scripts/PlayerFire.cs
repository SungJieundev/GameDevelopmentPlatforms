using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerFire : MonoBehaviour
{
    public GameObject[] bulletPrefab;  // ��ǰ�Ѱ� ����
    public int maxHp = 3;
    
    // public이지만 인스펙터에 표시 안됨
    [System.NonSerialized] public int nHp;

    public Image hpImage;
    public Image hpWorldImage;
    public Button reStartBtn;
    
    void Start()
    {
        nHp = maxHp;
        SetHp();
        
        // 버튼 꺼두기
        reStartBtn.gameObject.SetActive(false);
    }

    public void SetHp()
    {
        hpWorldImage.fillAmount = (float)nHp / maxHp;
        hpImage.fillAmount = (float)nHp / maxHp;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 총알 발사하기 
    // 총알 소품화, 복제, 위치잡기
    void Update()
    {
       
       if(Input.GetButtonDown("Fire1")==true)
       {
           OneShotBullet();
       }

       if (Input.GetButtonDown("Fire2") == true)
       {
           CircleShotBullet();
       }

       if (Input.GetButtonDown("Fire3") == true) SpiralShotBullet();
       
       if (Input.GetButtonDown("Jump") == true) SpecialShotBullet();
    }

    void OneShotBullet()
    {
        //int rnd = Random.Range(0, 3); //0, 1, 2 중 랜덤숫자
        //GameObject bullet = Instantiate(bulletPrefab[rnd]);
        
        GameObject bullet = Instantiate(bulletPrefab[0]);
        bullet.transform.position = transform.position;
        
        //bullet.GetComponent<AudioSource>().Play();
    }

    void CircleShotBullet()
    {
        // 원형으로 36발 발사하기
        for (int i = 0; i < 36; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab[1]);
            bullet.transform.position = transform.position;
            bullet.transform.eulerAngles = new Vector3(0.0f, 0.0f, i * 10.0f);
        }
    }

    int nCnt;
    void SpiralShotBullet()
    {
        // 나선형으로 발사하기
        GameObject bullet = Instantiate(bulletPrefab[2]);
        bullet.transform.position = transform.position;
        
        bullet.transform.eulerAngles = new Vector3(0.0f, 0.0f, nCnt * 10.0f);
            
        nCnt++;
        if(nCnt >= 36) nCnt = 0;
    }
    

    void SpecialShotBullet()
    {
        GameObject bullet1 = Instantiate(bulletPrefab[2]);
        bullet1.transform.position = transform.position + new Vector3(0.3f, 0.0f, 0);
        
        GameObject bullet2 = Instantiate(bulletPrefab[2]);
        bullet2.transform.position = transform.position + new Vector3(-0.3f, 0.0f, 0);
        
        GameObject bullet3 = Instantiate(bulletPrefab[2]);
        bullet3.transform.position = transform.position + new Vector3(0.3f, 0.0f, 0);
        bullet3.transform.eulerAngles = new Vector3(0.0f, 0.0f, -20.0f);
        
        GameObject bullet4 = Instantiate(bulletPrefab[2]);
        bullet4.transform.position = transform.position;
        bullet4.transform.eulerAngles = new Vector3(0.0f, 0.0f, 20.0f);
    }
}
