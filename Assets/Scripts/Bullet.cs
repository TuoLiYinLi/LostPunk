using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AttackArea
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(gameObject);
    }
}
