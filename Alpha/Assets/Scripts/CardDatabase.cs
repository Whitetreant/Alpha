using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardDatabase: MonoBehaviour
{
    static Card thisCard;
    public static List<Card> cardList;
    
    private static Card AddCard(int CardID, string Name, int Cost, string Role, string Category, string Description, string Rarity){
        // Card thisCard = ScriptableObject.CreateInstance<Card>();
        // Card thisCard = new Card();
        thisCard.cardID = CardID;
        thisCard.name = Name;
        thisCard.cost = Cost;
        thisCard.role = Role;
        thisCard.category = Category;
        thisCard.description = Description;
        thisCard.rarity = Rarity;
        return thisCard;
    }    
}
