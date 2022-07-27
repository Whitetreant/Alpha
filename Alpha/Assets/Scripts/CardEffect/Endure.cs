using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endure : EffectExecute
{
    public override void dealDamage(List<Enemy> target)
   {
      for(int i = 0; i < target.Count; i++){
            // target[i].takeDamage(3);
            Debug.Log("Endure Deal 3 damage to" + target[i].name);
        }
   }
}
