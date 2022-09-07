using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life_time = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life_time -= Time.deltaTime;
        if (life_time <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<WhiteSolider>())
        {
            Debug.Log("hit white solider");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }else
        if (collision.gameObject.GetComponent<Desk>())
        {
            Debug.Log("hit desk");
            Destroy(gameObject);
        }
    }
}
