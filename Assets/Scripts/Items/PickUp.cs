using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	private int index;
    void Start()
    {
		index = ManagementMiniGames.player.GetComponent<ManagementMiniGames>().indiceGame;
	}  

	private void OnMouseDown(){
		SendToOrderedTable();
	}

    private void SendToOrderedTable() {
		//ManagementMiniGames.player.GetComponent<ManagementMiniGames>().miniGames[index];
		gameObject.SetActive(false);
    }

}
