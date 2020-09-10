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

    private void SendToOrderedTable() {
        Debug.Log(1.1);
        miniGame.GetComponent<OrderTable>().SetObjectTable(gameObject);
    }

    public void ClickOnLabel(Word word){
        Debug.Log(1.2);
        miniGame.GetComponent<OrderTable>().SetObjectInterface(word);
    }
}
