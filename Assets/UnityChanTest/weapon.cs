using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public CapsuleCollider c;
    public Animator animator;
    public int aTime;

    private void FixedUpdate()
    {
        aTime--;
        if (animator.GetBool("attack")==true)
        {
            c.isTrigger = true;
            aTime = 25;
        }
        if (aTime < 0)
        {
            c.isTrigger = false;
        }
    }

}
