using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Graveyard : MonoBehaviour
{
    public List<string> cardList = new List<string>();
    public List<string> listCardInGraveyard;
    public Text currentCardInGraveyard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        listCardInGraveyard = cardList;
    }

    public void CardToGraveyard(string name){
        cardList.Add(name);
        refreshCurrentCardInDeck();
    }

    public void refreshCurrentCardInDeck(){
        currentCardInGraveyard.text = cardList.Count.ToString();
    }
}
