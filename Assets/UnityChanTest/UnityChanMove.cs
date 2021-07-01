using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanMove : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //再生されているアニメ
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        //attak中は移動しない
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack1")
        {
            //Run
            if (target_dir.magnitude > 0.1)
            {
                //体の向きを変更
                transform.rotation = Quaternion.LookRotation(target_dir);
                //前方へ移動
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                //アニメーション用
                animator.SetBool("is_running", true);
            }
            else
            {
                animator.SetBool("is_running", false);
            }
        }


        //攻撃アニメーション
        if (Input.GetAxis("R2") > 0f)
        {
            animator.SetBool("attack", true);
            Debug.Log("attackOn");
        }else
        {
            animator.SetBool("attack", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "katai")
        {
            Debug.Log("katai");
            pad p = GameObject.Find("pad").GetComponent<pad>();
            p.SetRight((byte)(0));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "katai")
        {
            Debug.Log("kataiOff");
            pad p = GameObject.Find("pad").GetComponent<pad>();
            p.SetRight((byte)(255));
        }
    }

}
