using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public Transform player_transform = null;
    public Transform camera_transform = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_posi = player_transform.position;
        Vector3 camera_posi = camera_transform.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 d = ray.direction;

        float k = (player_posi.y- camera_posi.y) /d.y;

        Vector3 target_posi = new Vector3(camera_posi.x+d.x*k,player_posi.y,camera_posi.z+d.z*k);

        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(90f, Mathf.Atan2(target_posi.x - player_posi.x, target_posi.z - player_posi.z) / Mathf.PI * 180, 0);

        transform.SetPositionAndRotation(target_posi, q);
    }
}
