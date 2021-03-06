﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementMiniGames : MonoBehaviour
{
    
	public static GameObject player;
    public OrderObjecsTable miniGame1;    
    
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
        miniGame1.Play();
    }
}
