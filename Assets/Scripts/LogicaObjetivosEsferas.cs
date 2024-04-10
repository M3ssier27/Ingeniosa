using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class LogicaObjetivosEsferas : MonoBehaviour
{
    public int numObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonMision; 


    // Start is called before the first frame update
    void Start()
    {
        numObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").Length;
        textoMision.text = "Hola ingeniosa, podrias ayudarme a recolectar las esferas rojos " +
                        "\n Restantes: " +  numObjetivos; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag =="Objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numObjetivos--;
            textoMision.text= "Hola ingeniosa, podrias ayudarme a recolectar las esferas rojos " +
                        "\n Restantes: " +  numObjetivos;
            if(numObjetivos<= 0)
            {
                textoMision.text = "Completaste la mision"; 
                botonMision.SetActive(true); 
            }
        }
    }
}
