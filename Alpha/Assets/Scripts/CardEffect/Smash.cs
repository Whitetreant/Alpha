using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : EffectExecute
{
    public override void dealDamage(List<Enemy> target){
        for(int i = 0; i < target.Count; i++){
            target[i].TakeDamage(3);
            Debug.Log("Smash Deal 3 damage to" + target[i].name);
        }

    }
    
}
