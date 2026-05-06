using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Contains("Enemy") == true)
        {
            Destroy(other.gameObject);
        }
    }
}
