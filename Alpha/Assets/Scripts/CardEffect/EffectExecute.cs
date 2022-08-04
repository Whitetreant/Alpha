using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExecute
{
    public bool isPlaySuccessful = false;

    public virtual bool executeEffect(List<Enemy> target){
        // Debug.Log("Execute some effect");
        applyStatus(target);
        dealDamage(target);
        return true;
    }

    public virtual void applyStatus(List<Enemy> target){
        for(int i = 0; i < target.Count; i++){
            
        }
        
    }
    
    public virtual void dealDamage(List<Enemy> target){
        
        
    }
}
