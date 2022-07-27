using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fury : EffectExecute
{
    public override bool executeEffect(List<Enemy> target){
        if (target.Count == 2){
            base.executeEffect(target);
            return true;
        }
        else{
            return false;
        }
    }
    public override void dealDamage(List<Enemy> target)
   {
      for(int i = 0; i < target.Count; i++){
            target[i].takeDamage(3);
            Debug.Log("Fury Deal 3 damage to" + target[i].name);
        }
   }
}
