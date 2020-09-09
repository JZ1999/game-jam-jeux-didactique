using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    static int indiceID;
    public int id;

    private void Awake()
    {
        id = ID.indiceID++;
    }
  
}
