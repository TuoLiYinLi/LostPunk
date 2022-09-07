using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSolider : MonoBehaviour
{
    public CharacterController character_controller = null;

    public Vector3 velocity = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 f0 = new Vector3(0f, -9.8f, 0f) + velocity;
        character_controller.Move(f0 * Time.fixedDeltaTime);
    }
}
