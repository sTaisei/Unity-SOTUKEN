using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    public GameObject chara;
    public float z;
    private Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = chara.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        z = t.position.z;
        this.gameObject.transform.position = new Vector3(0, 4.5f, z - 4f);
    }
}
