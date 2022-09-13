using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public float damage = 0;

    public Vector3 velocity = new Vector3();

    public BasicChara attacker = null;

    public float life_time = 3f;

    void Start()
    {
        if (!GetComponent<Collider>())
        {
            Debug.LogError("物体上没有可用的Collider,此脚本失效");
        }else if (!GetComponent<Collider>().isTrigger)
        {
            Debug.LogError("Collider.isTrigger=false,此脚本失效");
        }
    }
    public void FixedUpdate()
    {
        life_time -= Time.fixedDeltaTime;
        if (life_time<=0)
        {
            OnVanish();
            Destroy(gameObject);
            return;
        }
        transform.Translate(velocity * Time.fixedDeltaTime);
    }
    // 当触发器被触发时(触发器应该和此脚本在同一物体下,攻击区域永远应该是碰撞触发器)
    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject == attacker)
        {
            return;
        }
        if (other.GetComponent<DefendeArea>())
        {
            var def = other.GetComponent<DefendeArea>();
            OnHit(def);
            def.OnHit(this);
        }
    }
    // 当产生击中时
    public virtual void OnHit(DefendeArea def)
    {

    }
    // 当生命时间结束时
    public virtual void OnVanish()
    {

    }
}
