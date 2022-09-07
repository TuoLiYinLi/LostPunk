using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public CharacterController character_controller = null;

    public Vector3 velocity = new Vector3();

    public Transform cursor_transform = null;

    public GameObject bullet_prefab = null;

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") >0.5)
        {
            velocity.z = 1f;
        }else if (Input.GetAxis("Vertical")<-0.5)
        {
            velocity.z = -1f;
        }
        else
        {
            velocity.z = 0f;
        }
        if (Input.GetAxis("Horizontal") > 0.5)
        {
            velocity.x = 1f;
        }
        else if (Input.GetAxis("Horizontal") < -0.5)
        {
            velocity.x = -1f;
        }
        else
        {
            velocity.x = 0f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 d = (cursor_transform.position - transform.position).normalized;

            GameObject b = Instantiate(bullet_prefab);

            b.transform.position = transform.position+d*1.2f;
            b.GetComponent<Rigidbody>().AddForce(d * 200f);
        }
        
    }

    void FixedUpdate() {
        Vector3 f0 = new Vector3(0f,-9.8f,0f)+velocity;
        character_controller.Move(f0*Time.fixedDeltaTime);
    }
}
