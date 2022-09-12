using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChara : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController character_controller = null;

    public float gravity = 9.8f;

    public Vector3 velocity = new Vector3();

    public Vector3 direction = new Vector3();

    public List<DefendeArea> defend_areas = new List<DefendeArea>();
    
    public void Start()
    {
        character_controller = GetComponent<CharacterController>();
        if (!character_controller)
        {
            Debug.LogError("CharacterController不存在");
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector3 f0 = new Vector3(0f, -gravity, 0f) + velocity;
        character_controller.Move(f0 * Time.fixedDeltaTime);
    }
    // 当一个防御区被击溃
    public virtual void OnLoseDefendArea(DefendeArea def)
    {

    }
}
