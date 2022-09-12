using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendeArea : MonoBehaviour
{
    public float health = 1;
    public bool invincible = false;
    public string defend_tag = "default";
    public BasicChara host_chara = null;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Collider>())
        {
            Debug.LogError("物体上没有可用的Collider,此脚本失效");
        }
        if (!host_chara)
        {
            Debug.LogError("DefendArea没有可用的host_chara,此脚本失效");
        }
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            host_chara.OnLoseDefendArea(this);
            host_chara.defend_areas.Remove(this);
            Destroy(gameObject);
        }
    }

    public void OnHit(AttackArea atk)
    {
        if (!invincible) 
        {
            health -= atk.damage;
        }
    }
}
