using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    static int indiceID = 0;
    public int id = 0;

    private void Awake()
    {
        id = ID.indiceID++;
    }
  
}
