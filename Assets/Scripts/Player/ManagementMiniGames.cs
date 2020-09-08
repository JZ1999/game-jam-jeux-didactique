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

    public GameObject player;
    public List<Minigames> miniGames = new List<Minigames>(); 
    public int indiceGame;
    [SerializeField]
    private readonly int State;

    virtual protected void Start()
    {
        indiceGame = 0;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
         
    }


    virtual protected void NextGame()
    {
        miniGames[indiceGame++].Play();
    }
}
