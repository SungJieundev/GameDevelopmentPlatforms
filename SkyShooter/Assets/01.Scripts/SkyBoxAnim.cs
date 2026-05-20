using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoxAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float currentTime = 0.0f;
    public float speed = 2.0f;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        RenderSettings.skybox.SetFloat("_Rotation", -currentTime*speed);
    }

    //외부에서 접근할수 있도록 public으로 설정
    // 게임씬으로 전환하자
    public void NextScene(string nextScene)
    {
        // 중요!!
        // Build Setting에서 씬이 등록되어야 한다.
        SceneManager.LoadScene(nextScene);
    }


}
