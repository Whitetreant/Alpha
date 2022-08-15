using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExecute
{
    public bool isPlaySuccessful = false;

    public virtual bool ExecuteEffect(List<Enemy> EnemyTarget = null, List<Character> CharacterTarget = null){
        // Debug.Log("Execute some effect");
        ApplyStatus(EnemyTarget);
        DealDamage(EnemyTarget);
        GetShield(CharacterTarget);
        return true;
    }

    public virtual void ApplyStatus(List<Enemy> target=null){
        
    }
    
    public virtual void DealDamage(List<Enemy> target=null){
        
    }

    public virtual void GetShield(List<Character> target=null){

    }
}
