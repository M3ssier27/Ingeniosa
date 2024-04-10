using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public NPCLogic logicaNPC; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag== "Player")
        {
            logicaNPC.numDeObjetos--; 
            logicaNPC.textoMision.text= "Podrias ayudarme a recolectar los compnentes de mi computador, buscalos por esta ciudad " +
                        "\n Restantes: " + logicaNPC.numDeObjetos;
            if (logicaNPC.numDeObjetos <= 0)
            {

                logicaNPC.textoMision.text = "Completaste la mision";
                logicaNPC.botonDeMision.SetActive(true); 

            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
