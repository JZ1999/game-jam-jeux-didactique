using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{	
    public GameObject miniGame;
    
    void Start()
    {		
	}  

	private void OnMouseDown(){
		SendToOrderedTable();
	}

    public void setMinigame(GameObject newMinigame) {
        miniGame = newMinigame;
    }

    private void SendToOrderedTable() {
        miniGame.GetComponent<OrderObjecsTable>().SetObjectTable(gameObject);
    }

    public void ClickOnLabel(Word word){
        miniGame.GetComponent<OrderObjecsTable>().SetObjectInterface(word);
    }
}
 