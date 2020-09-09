using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementMiniGames : MonoBehaviour
{

	/* script(padre) para el manejo de los eventos 
    con este script manejamos cual evento se estará dando,
    manejará orden y cantidad de los minijuegos.

    Padre de los Management futuros que haremos para los personajes (chef, camarero, cliente)
    no se seteará en el jugador sino cada personaje tendrá un hijo diferente
         */
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
