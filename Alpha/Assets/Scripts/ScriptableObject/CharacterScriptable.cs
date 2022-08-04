using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class CharacterScriptable : ScriptableObject
{
    public string characterName;
    public int characterMaxHP;
    public int characterMaxMP;
    public string characterClass;
    public string characterEffectDescription;
}