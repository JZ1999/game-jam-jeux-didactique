using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderObjecsTable : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Objetos para la mesa (erroneos + correctos) (seran visibles para el usaurio, en la mesa )")]
    private List<GameObject> objectsToSpawn = new List<GameObject>(); //objectos en la mesa (errroneos + correctos)


    [SerializeField]
    [Tooltip("Objetos para comparacion (correctos + nulls) (no serán visibles para el usuario")]
    private List<GameObject> neededListOfObjects = new List<GameObject>();

    private List<Word> objDisabled = new List<Word>();

    private List<GameObject> setObjectsToWords = new List<GameObject>();

    [SerializeField]
    [Tooltip("Wordobjects para la ubicacion de los botones (correctos) (seran visibles para el usaurio, en la interfaz)")]
    public List<Word> words = new List<Word>();

    [Tooltip("indice que dira cuantos objetos estan erroneos")]
    public int nulls; 
    public GameObject stand;

    public GameObject templateButton;

    public Transform panel;

    [SerializeField]
    private GameObject objToInteract1; //objects in table
    [SerializeField]
    private Word objToInteract2; //objects in interface 

    public void CreateButtoms()
    {
        int max = words.Count;
        int indice = 0;
        foreach(Word word in words)
        {
            GameObject gameObjectWord = Instantiate(templateButton, panel);
            gameObjectWord.GetComponentInChildren<Text>().text = word.word;
            gameObjectWord.GetComponent<PickUp>().setMinigame(gameObject);
            gameObjectWord.GetComponent<Button>().onClick.AddListener(() => word.obj.GetComponent<PickUp>().ClickOnLabel(word));
            word.button = gameObjectWord;
            word.obj = setObjectsToWords[indice];
            indice++;
        }
    }
    
    public void Play()
    {        
        PositionObjects();
        CreateButtoms();
    }

    private void PositionObjects()
    {
        Vector3 newPosition;
        int max = objectsToSpawn.Count;
        List<int> order = Utils.createList(15);
        Transform children;
        int index = 0;
        while(index < max)
        {
            
            GameObject obj = objectsToSpawn[index];
            obj.GetComponent<PickUp>().setMinigame(gameObject);
            children = stand.transform.GetChild(order[index]);            
            newPosition = children.transform.position;
            setObjectsToWords.Add(Instantiate(obj, newPosition, new Quaternion(), stand.transform));
            index++;
        }

    }
    

    private void Validate()
    {
        int balance = objToInteract2.obj.GetComponent<ID>().id - objToInteract1.GetComponent<ID>().id;
        if (balance == 0)
            HideObj();
        else
            LoseState();
        UnSet();
    }

    private void ActiveAllObjects()
    {
      
        foreach(Word word in objDisabled)
        {
            Debug.Log(word.obj.GetComponent<ID>().id + "  " + word.obj + "  f"  + word.button);
            
            word.obj.SetActive(true);            
            word.button.SetActive(true);
        }
        objDisabled.Clear();
    }

    private void HideObj()
    {
        objDisabled.Add(objToInteract2);
        objToInteract1.SetActive(false);
        objToInteract2.button.SetActive(false);
    }

    private void UnSet()
    {
        objToInteract1 = null;
        objToInteract2 = null;
    }

    public void SetObjectInterface(Word word)
    {
        if (objToInteract2 == null)
        {            
            /*agregar efectos de luz*/
            objToInteract2 = word;
            if (objToInteract1 != null)
            {
                Validate();
            }
            return;
        }
        if (word.obj.GetComponent<ID>().id == objToInteract2.obj.GetComponent<ID>().id)
        {
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
            {
                Validate();
            }
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
