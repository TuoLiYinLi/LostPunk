using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : BasicChara
{
    public Transform cursor_transform = null;

    public GameObject bullet_prefab = null;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        
        if(character_controller.isGrounded)
        { 
            velocity.x = Input.GetAxis("Vertical") + Input.GetAxis("Horizontal");
            velocity.z = Input.GetAxis("Vertical") - Input.GetAxis("Horizontal");
            velocity = velocity.normalized * 2f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 d = (cursor_transform.position - transform.position).normalized;

            GameObject b = Instantiate(bullet_prefab);

            b.transform.position = transform.position+d*1.2f;
            b.GetComponent<Bullet>().velocity=d * 20f;
            b.GetComponent<Bullet>().attacker = this;
        }
        
    }
}
