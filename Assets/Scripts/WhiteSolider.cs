using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSolider : BasicChara
{
    public override void OnLoseDefendArea(DefendeArea def)
    {
        if (def.defend_tag == "body")
        {
            Destroy(gameObject);
        }
    }
}
