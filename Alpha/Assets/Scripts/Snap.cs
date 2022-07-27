using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Snap : MonoBehaviour, IDropHandler
{

    // , IPointerEnterHandler, IPointerExitHandler
    // public void OnPointerEnter(PointerEventData eventData){
    //     print("Enter");
    // }
    
    // public void OnPointerExit(PointerEventData eventData){
    //     print("Exit");
    // }
    public void  OnDrop(PointerEventData eventData){
        ThisCard thisCard = eventData.pointerDrag.GetComponent<ThisCard>();
        print(eventData.pointerDrag.name + " was drop to " + this.name);
        if (this.name != "Hand"){
            thisCard.parentToReturnTo = this.transform;
            thisCard.isPlay = true;
        }
        else{
            thisCard.parentToReturnTo = this.transform;
        }
         
    }
}