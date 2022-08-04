using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // public int cardID;
    // public new string name;
    public int cost = 0;
    // public string role;
    // public string category;
    // public string description;
    // public string rarity;
    //image

    public Text nameText;
    public Text costText;
    public Text categoryText;
    public Text descriptionText;
    public Image roleImage;
    public Image rarityColor;
    //public Image cardPic;

    private RectTransform rectTransform;
    public Image playZone;
    public Transform holdCard;
    public Transform parentToReturnTo = null;
    public bool isPlay = false;
    public List<Enemy> target;

    private EffectExecute effect;
    public Character characterPlayedCard;

    private void Constructor(){
        rectTransform = GetComponent<RectTransform>();
        effect = System.Activator.CreateInstance(System.Type.GetType(this.name)) as EffectExecute;
        playZone = GameObject.FindGameObjectWithTag("playArea").GetComponent<Image>();
        holdCard = GameObject.FindGameObjectWithTag("HoldCard").GetComponent<Transform>();
    }

    public void isDraw(int cardID){
        Card thisCard = CardDatabase.cardList[cardID];
        this.name = thisCard.name;
        nameText.text = thisCard.name;
        costText.text = thisCard.cost.ToString();
        cost = thisCard.cost;
        categoryText.text = thisCard.category;
        descriptionText.text = thisCard.description;
        roleImage.sprite = Resources.Load<Sprite>(thisCard.role);
        if (thisCard.rarity == "Common"){
            rarityColor.color = new Color32(153, 153, 153, 255);
        }
        else if (thisCard.rarity == "Rare"){
            rarityColor.color = new Color32(51, 51, 204, 255);
        }
        else{
            rarityColor.color = new Color32(102, 0, 153, 255);
        }    
        Constructor();

    }

    public void applyEffect(){
        Debug.Log("Apply effect" + this.name);
        
        if (effect != null){
            if (effect.executeEffect(target)){
                Destroy(this.gameObject);
                characterPlayedCard.PlayCard(cost);
            }
        }
    }

    private void subscribe(){
        Enemy.isTarget += setTarget;
    }

    private void unSubscribe(){
        Enemy.isTarget -= setTarget;
        Debug.Log("Unsubscribe");
    }

    private void setTarget(Enemy targetSelect){
        target.Add(targetSelect);
        Debug.Log("Target: " + targetSelect.name);
        applyEffect();

    }

    public void OnBeginDrag(PointerEventData eventData){
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        playZone.raycastTarget = true;
    }
    
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData){
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        playZone.raycastTarget = false;
        GameObject[] allCharacter = GameObject.FindGameObjectsWithTag("Player");
        bool canPlay;
        foreach (GameObject character in allCharacter){
            if (character.GetComponent<Character>().activePlayer==true){
                characterPlayedCard = character.GetComponent<Character>();
                break;
            }
        }
        if (cost > characterPlayedCard.currentMP){
            canPlay = false;
            Debug.LogWarning("Not Enough Mana");
        }
        else{
            canPlay = true;
        }
        if (isPlay == true && canPlay){
            Debug.Log("Can Play");
            this.transform.SetParent(holdCard.transform);
            subscribe();
        }

        else if (isPlay == false || canPlay){
            this.transform.SetParent(parentToReturnTo);
            unSubscribe();
            target.Clear();
            Debug.Log("Cancel Play");
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        print("Select: " + eventData.pointerPressRaycast.gameObject.transform.parent.name);
    }
    
    private void OnDisable(){
        Enemy.isTarget -= setTarget;
    }
}
