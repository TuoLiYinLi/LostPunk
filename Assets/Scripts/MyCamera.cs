using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public GameObject chasing_target;
    public Vector3 posi_offset = new Vector3(-8, 10, -8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing_target)
        {
            transform.position = chasing_target.transform.position + posi_offset;
        }
    }
}
