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
        miniGame.GetComponent<OrderTable>().SetObjectTable(gameObject);
    }

    public void ClickOnLabel(GameObject obj){
        miniGame.GetComponent<OrderTable>().SetObjectInterface(obj);
    }
}
