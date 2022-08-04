using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class EnemyScriptable : ScriptableObject
{
    public int enemyID;
    public string enemyName;
    public int enemyMaxHP;
    public string enemyEffectDescription;


}
