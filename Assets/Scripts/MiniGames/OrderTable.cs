using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTable : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToSpawn = new List<GameObject>();
    [SerializeField]
    private List<GameObject> neededListOfObjects = new List<GameObject>();

    private List<GameObject> objDisabled = new List<GameObject>();
    private Dictionary<GameObject, GameObject> correlation = new Dictionary<GameObject, GameObject>();
    //private GameObject receivedObject;
    [SerializeField]
    private GameObject objToInteract1; //objects in table
    [SerializeField]
    private GameObject objToInteract2; //objects in interface

    public void Start()
    {
        BuildDictionary();
    }

    public void Update()
    {
    }

    private void BuildDictionary() {
        int indice = 0;
        int max = objectsToSpawn.Count;
        while (indice != max)
        {
            correlation.Add(objectsToSpawn[indice], neededListOfObjects[indice]);
            
            if (indice++ > 15) {
                break;
            }
        }
    }

    public void Play() {

    }

    private void PositionObjects() {
        Vector2 newPosition = this.ObtainPoint();
        
    }

    private Vector2 ObtainPoint() {
        Vector2 newPosition = new Vector2();

        /*
         Buscar las posiciones en la tablilla 
         */


        return newPosition;
    }

    private void Validate()
    {
        int balance = correlation[objToInteract2].GetComponent<ID>().id - correlation[objToInteract1].GetComponent<ID>().id;
        if (balance == 0)
        {
            HideObj();  
        }
        else {
            LoseState();
        }
        UnSet();
    }
    
    private void ActiveAllObjects()
    {
        int indice = objDisabled.Count;
        while (indice != 0)
        {
            objDisabled[indice++].SetActive(true);
        }
        objDisabled.Clear();
    }

    private void HideObj() {
        objDisabled.Add(objToInteract1);
        objToInteract1.SetActive(false);
        objToInteract2.SetActive(false);
    }

    private void UnSet()
    {
        objToInteract1 = null;
        objToInteract2 = null;
    }
    
    public void SetObjectInterface(GameObject obj)
    {        
        if (objToInteract2 == null) {
            /*agregar efectos de luz*/
            objToInteract2 = obj;
            if (objToInteract1 != null)
                Validate();
            return;
        }
        if (obj.GetComponent<ID>().id == objToInteract2.GetComponent<ID>().id) {
            /* quitar efectos de luz*/
            objToInteract2 = null;
            return;
        }
    }

    public void SetObjectTable(GameObject obj)
    {
        if (objToInteract1 == null)
        {
            /*agregar efectos de luz*/
            objToInteract1 = obj;
            if (objToInteract2 != null)
                Validate();
            return;
        }
        if (obj.GetComponent<ID>().id == objToInteract1.GetComponent<ID>().id)
        {
            /* quitar efectos de luz*/
            objToInteract1 = null;
            return;
        }
    }    

    private void LoseState()
    {
        ActiveAllObjects();    
    }

}
