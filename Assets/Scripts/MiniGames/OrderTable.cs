using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTable : Minigames
{
    [Header("Custom Variables")]
    [SerializeField]
    private List<GameObject> objectsToRespawn = new List<GameObject>();

    

    override public void Play() {

    }

    private void PositionObjects() {
        Vector2 newPosition = this.ObtainPoint();
        
    }

    private Vector2 ObtainPoint() {
        Vector2 newPosition = new Vector2();


        return newPosition;
    }
}
