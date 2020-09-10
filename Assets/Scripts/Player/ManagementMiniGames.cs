using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementMiniGames : MonoBehaviour
{
    
	public static GameObject player;
    public OrderTable miniGame;    
    
    [SerializeField]
    private readonly int State;

    private void Awake()
    {
        ManagementMiniGames.player = gameObject;
    }

    virtual protected void Start()
    {
        
		NextGame();
    }
    
    virtual public void NextGame()
    {
        miniGame.Play();
    }
}
