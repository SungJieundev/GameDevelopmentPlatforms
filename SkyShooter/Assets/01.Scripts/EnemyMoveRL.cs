using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRL : MonoBehaviour
{
    // Start is called before the first frame update
    bool bLeft = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bLeft == true)
        {
            if(transform.position.x < -8.0f)
            {
                bLeft = false;
            }
            transform.position += Vector3.left * 3.0f * Time.deltaTime;
        }
       
        else
        {
            if (transform.position.x > 8.0f)
            {
                bLeft = true;
            }
            transform.position += Vector3.right * 3.0f * Time.deltaTime;

        }
        print(transform.position.x);
    }
}
