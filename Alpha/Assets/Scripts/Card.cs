using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class Card : ScriptableObject
{
    public int cardID;
    public new string name;
    public int cost;
    public string role;
    public string category;
    public string description;
    public string rarity;


    //image
}