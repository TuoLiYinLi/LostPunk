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
            Debug.LogError("������û�п��õ�Collider,�˽ű�ʧЧ");
        }
        if (!host_chara)
        {
            Debug.LogError("DefendAreaû�п��õ�host_chara,�˽ű�ʧЧ");
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
