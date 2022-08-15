using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fury : ThisCard
{
    public override bool ExecuteEffect(List<Enemy> Enemytarget, List<Character> CharacterTarget = null){
        if (Enemytarget.Count == 2){
            base.ExecuteEffect(Enemytarget);
            return true;
        }
        else{
            Debug.LogWarning("Apply Effect Failed not enough target");
            return false;
        }
    }
    public override void DealDamage(List<Enemy> target)
   {
      for(int i = 0; i < target.Count; i++){
            target[i].TakeDamage(3);
            Debug.Log("Fury Deal 3 damage to" + target[i].name);
        }
   }
}
