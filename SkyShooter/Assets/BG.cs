using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float speed = 0.2f;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        meshRenderer.material.mainTextureOffset += speed * Vector2.up * Time.deltaTime; 
    }
}
