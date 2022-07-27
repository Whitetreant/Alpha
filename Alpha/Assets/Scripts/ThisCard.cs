using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static CardDatabase;

public class ThisCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // public int cardID;
    // public new string name;
    // public int cost;
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
    public Transform parentToReturnTo = null;
    public bool isDestroy = false;
    public bool isPlay = false;


    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }

    public void isDraw(int cardID){
        Card thisCard = CardDatabase.cardList[cardID];
        this.name = thisCard.name;
        nameText.text = thisCard.name;
        costText.text = thisCard.cost.ToString();
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
    }

    public void OnBeginDrag(PointerEventData eventData){
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta;
    }
    
    public void OnEndDrag(PointerEventData eventData){
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        if (isPlay == false){
            this.transform.SetParent(parentToReturnTo);
        }
        if (isPlay == true){
            this.transform.SetParent(parentToReturnTo);
            //execute effect
        }
        if (isDestroy == true){
            Destroy(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        print(eventData.pointerPressRaycast);
    }
}
