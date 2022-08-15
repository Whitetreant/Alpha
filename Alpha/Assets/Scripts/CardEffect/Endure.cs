using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endure : ThisCard
{
    public override bool ExecuteEffect(List<Enemy> Enemytarget, List<Character> CharacterTarget){
        if (CharacterTarget.Count == 1){
            base.ExecuteEffect(null, CharacterTarget);
            return true;
        }
        else{
            Debug.LogWarning("Apply Effect Failed not enough target");
            return false;
        }
    }
    public override void GetShield(List<Character> target)
   {
        for(int i = 0; i < target.Count; i++){
            target[i].GetShield(3);
            Debug.Log(target[i].name + " Get 3 shield");
        }
        
   }
}
