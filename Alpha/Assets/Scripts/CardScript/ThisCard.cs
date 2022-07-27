using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public Image playZone;
    public Transform parentToReturnTo = null;
    public bool isPlay = false;
    public List<Enemy> target;

    private EffectExecute effect;

    private void Constructor(){
        rectTransform = GetComponent<RectTransform>();
        effect = System.Activator.CreateInstance(System.Type.GetType(this.name)) as EffectExecute;
        playZone = GameObject.FindGameObjectWithTag("playZone").GetComponent<Image>();
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
        Constructor();

    }

    public void applyEffect(){
        Debug.Log("apply effect" + this.name);
        
        if (effect != null){
            if (effect.executeEffect(target)){
                Destroy(this.gameObject);
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
        
        if (isPlay == false){
            this.transform.SetParent(parentToReturnTo);
            unSubscribe();
            target.Clear();
            Debug.Log("Cancel Play");
        }
        if (isPlay == true){
            Debug.Log("IsPlay");
            this.transform.SetParent(parentToReturnTo);
            subscribe();
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        print("Click: " + eventData.pointerPressRaycast.gameObject.transform.parent.name);
    }
    
    private void OnDisable(){
        Enemy.isTarget -= setTarget;
    }
}
