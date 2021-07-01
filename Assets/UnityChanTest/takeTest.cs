using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeTest : MonoBehaviour
{
    public Rigidbody r;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            Debug.Log("hit");
            r.useGravity = true;
        }
    }
}
