using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardDatabase : MonoBehaviour
{

    public static List<Card> cardList = new List<Card>();
    
    private Card addCard(int CardID, string Name, int Cost, string Role, string Category, string Description, string Rarity){
        Card thisCard = ScriptableObject.CreateInstance<Card>();
        thisCard.cardID = CardID;
        thisCard.name = Name;
        thisCard.cost = Cost;
        thisCard.role = Role;
        thisCard.category = Category;
        thisCard.description = Description;
        thisCard.rarity = Rarity;
        return thisCard;
    }

    // Start is called before the first frame update
    void Start()
    {
        cardList.Add(addCard(0, "Smash", 1, "Barbarian", "A", "Deal 3 damage.", "Common"));
        cardList.Add(addCard(1, "Endure", 2, "Barbarian", "S", "Gain 2 shield.", "Common"));
        cardList.Add(addCard(2, "Fury", 3, "Barbarian", "P", "Gain 1 power.", "Rare"));
        cardList.Add(addCard(3, "Slash", 1, "Guardian", "A", "Deal 3 damage.", "Common"));
        print("Add card to database successsful");
        
    }

    
}
