using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptHandler : MonoBehaviour
{
    public  static event Action<string> OnDraw;
    public void ScriptConstructor(string cardName){
        System.Type MyScript = System.Type.GetType(cardName + ",Assembly-CSharp");
        gameObject.AddComponent(MyScript);
        OnDraw?.Invoke(cardName);
    }
}
