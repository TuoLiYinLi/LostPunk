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
            Debug.LogError("������û�п��õ�Collider,�˽ű�ʧЧ");
        }else if (!GetComponent<Collider>().isTrigger)
        {
            Debug.LogError("Collider.isTrigger=false,�˽ű�ʧЧ");
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
    // ��������������ʱ(������Ӧ�úʹ˽ű���ͬһ������,����������ԶӦ������ײ������)
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
    // ����������ʱ
    public virtual void OnHit(DefendeArea def)
    {

    }
    // ������ʱ�����ʱ
    public virtual void OnVanish()
    {

    }
}
