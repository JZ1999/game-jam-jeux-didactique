using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementMiniGames : MonoBehaviour
{

    /*script(padre) para el manejo de los eventos 
    con este script manejamos cual evento se estara dando,
    (orden y cantidad de los minijuegos)*/

    public GameObject player;
    public List<Minigames> miniGames = new List<Minigames>(); //cambiar por list<scriptpadreminijuegos>
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
