using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderTable : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Objetos para la mesa (erroneos + correctos)")]
    private List<GameObject> objectsToSpawn = new List<GameObject>(); //objectos en la mesa (errroneos + correctos)


    [SerializeField]
    [Tooltip("Objetos para comparacion (correctos + nulls)")]
    private List<GameObject> neededListOfObjects = new List<GameObject>();

    private List<GameObject> objDisabled = new List<GameObject>();
   
    private Dictionary<GameObject, GameObject> correlation = new Dictionary<GameObject, GameObject>(); // <objectospawn, nnedenlistobjects>

    [SerializeField]
    [Tooltip("Wordobjects para la ubicacion de los botones (correctos)")]
    public List<Word> words = new List<Word>();

    public GameObject stand;

    public GameObject templateButton;

    public Transform panel; 

    [SerializeField]
    private GameObject objToInteract1; //objects in table
    [SerializeField]
    private Word objToInteract2; //objects in interface 

    public void Start()
    {
        BuildDictionary();
        CreateButtoms();
        PositionObjects();
    }

    public void CreateButtoms() { 
        
        foreach (Word word in words) {
            GameObject gameObjectWord = Instantiate(templateButton, panel);
            gameObjectWord.GetComponentInChildren<Text>().text =  word.word;
            gameObjectWord.GetComponent<Button>().onClick.AddListener(() => word.obj.GetComponent<PickUp>().ClickOnLabel(word));
            word.button = gameObjectWord;
        }
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
        Vector3 newPosition;
        int max = objectsToSpawn.Count;
        int indice = 0;
        Utils.Shuffle(objectsToSpawn);
        Transform children;
        while (indice < max)
        {
            children = stand.transform.GetChild(indice);
            newPosition = children.transform.position;
            Instantiate(objectsToSpawn[indice], newPosition, new Quaternion(), stand.transform);
            indice++;
        }
        
    }
    
    private void Validate()
    {
        int balance = correlation[objToInteract2.obj].GetComponent<ID>().id - correlation[objToInteract1].GetComponent<ID>().id;
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
        objToInteract2.button.SetActive(false);
    }

    private void UnSet()
    {
        objToInteract1 = null;
        objToInteract2 = null;
    }
    
    public void SetObjectInterface(Word word)
    {
        Debug.Log(2.2);
        if (objToInteract2 == null) {
            /*agregar efectos de luz*/
            Debug.Log(3.2);
            objToInteract2 = word;
            Debug.Log(4.2);
            if (objToInteract1 != null)
            {
                Debug.Log(5.2);
                Validate();
            }
            return;
        }
        if (word.obj.GetComponent<ID>().id == objToInteract2.obj.GetComponent<ID>().id) {
            /* quitar efectos de luz*/
            Debug.Log(6.2);
            objToInteract2 = null;
            return;
        }
        Debug.Log(7.2);
    }

    public void SetObjectTable(GameObject obj)
    {
        Debug.Log(2.1);
        if (objToInteract1 == null)
        {
            Debug.Log(3.1);
            /*agregar efectos de luz*/
            objToInteract1 = obj;
            Debug.Log(4.1);
            if (objToInteract2 != null)
            {
                Debug.Log(5.1);
                Validate();
            }
            return;
        }
        if (obj.GetComponent<ID>().id == objToInteract1.GetComponent<ID>().id)
        {
            /* quitar efectos de luz*/
            Debug.Log(6.1);
            objToInteract1 = null;
            return;
        }
    }    

    private void LoseState()
    {
        ActiveAllObjects();    
    }

}
