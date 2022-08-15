using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // public int cardID;
    public string cardName;
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
    public List<Enemy> EnemyTarget = new List<Enemy>();
    public List<Character> CharacterTarget = new List<Character>();
    private EffectExecute effect;
    public Character characterPlayedCard;

    public bool isPlaySuccessful = false;

    public void OnEnable(){
        ScriptHandler.OnDraw += Constructor;
    }
    private void Constructor(string name){
        cardName = name;
        rectTransform = GetComponent<RectTransform>();
        Debug.Log(this.name + " ConstructorStart");
        playZone = GameObject.FindGameObjectWithTag("playArea").GetComponent<Image>();
        holdCard = GameObject.FindGameObjectWithTag("HoldCard").GetComponent<Transform>();
        Text[] allText = gameObject.GetComponentsInChildren<Text>();
        Image[] allImage = gameObject.GetComponentsInChildren<Image>();
        for (int i = 0; i < allText.Length; i++){
            if (allText[i].name == "Cost"){
                costText = allText[i];
            }
            else if (allText[i].name == "Category"){
                categoryText = allText[i];
            }
            else if (allText[i].name == "Name"){
                nameText = allText[i];
            }
            else{
                descriptionText = allText[i];
            }
        }

        for (int i = 0; i < allImage.Length; i++){
            if (allImage[i].name == "Template"){
                roleImage = allImage[i];
            }
            else if(allImage[i].name == "Rarity"){
                rarityColor = allImage[i];
            }
        }

        IsDraw();
        
    }

    public void IsDraw(){
        Card thisCard = Resources.Load<Card>("CardContainer/" + cardName);
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
        Debug.Log("Card is Draw");
        
        ScriptHandler.OnDraw -= Constructor;
    }

    public void ApplyEffect(){
        Debug.Log("Apply effect" + this.name);
        if (ExecuteEffect(EnemyTarget, CharacterTarget)){
            Destroy(this.gameObject);
            characterPlayedCard.PlayCard(cost);
        }
        // if (effect != null){
        //     if (effect.ExecuteEffect(EnemyTarget, CharacterTarget)){
        //         Destroy(this.gameObject);
        //         characterPlayedCard.PlayCard(cost);
        //     }
        // }
    }

    public virtual bool ExecuteEffect(List<Enemy> EnemyTarget = null, List<Character> CharacterTarget = null){
        // Debug.Log("Execute some effect");
        ApplyStatus(EnemyTarget);
        DealDamage(EnemyTarget);
        GetShield(CharacterTarget);
        return true;
    }

    public virtual void ApplyStatus(List<Enemy> target=null){
        
    }
    
    public virtual void DealDamage(List<Enemy> target=null){
        
    }

    public virtual void GetShield(List<Character> target=null){

    }
    private void Subscribe(){
        Enemy.isTarget += SetEnemyTarget;
        Character.isTarget += SetCharacterTarget;
    }

    private void Unsubscribe(){
        Enemy.isTarget -= SetEnemyTarget;
        Character.isTarget -= SetCharacterTarget;

        Debug.Log("Unsubscribe");
    }

    private void SetEnemyTarget(Enemy targetSelect){
        EnemyTarget.Add(targetSelect);
        Debug.Log("Target: " + targetSelect.name);
        ApplyEffect();

    }

    private void SetCharacterTarget(Character targetSelect){
        CharacterTarget.Add(targetSelect);
        Debug.Log("Target: " + targetSelect.name);
        ApplyEffect();
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
            Debug.Log("Select " + this.name);
            this.transform.SetParent(holdCard.transform);
            Subscribe();
        }

        else if (isPlay == false || !canPlay){
            this.transform.SetParent(parentToReturnTo);
            Unsubscribe();
            EnemyTarget.Clear();
            CharacterTarget.Clear();
            Debug.Log("Cancel Play");
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        print("Card: " + eventData.pointerPressRaycast.gameObject.transform.parent.name);
    }
    
    private void OnDisable(){
        Enemy.isTarget -= SetEnemyTarget;
        Character.isTarget -= SetCharacterTarget;
    }
}
