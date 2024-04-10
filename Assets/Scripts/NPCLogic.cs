using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using System;

public class NPCLogic : MonoBehaviour
{
    public GameObject simboloMision;
    public PlayerController jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCmision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetos;
    public GameObject botonDeMision;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetos = objetivos.Length;
        textoMision.text = "Podrias ayudarme a recolectar los compnentes de mi computador, buscalos por esta ciudad " +
                        "\n Restantes: " + numDeObjetos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); // Corregido
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && aceptarMision == false)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);

            jugador.anim.SetFloat("X", 0);
            jugador.anim.SetFloat("Y", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true; // Corregido
            if (aceptarMision == false)
            {
                panelNPC.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false; 
            
            panelNPC.SetActive(false) ;
            panelNPC2.SetActive(false) ;
        }
    }
    public void NO()
    {
        jugador.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }
    public void SI()
    {
        jugador.enabled = true;
        aceptarMision = true;
        for (int i = 0; i < objetivos.Length; i++) // Corregido
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCmision.SetActive(true);
    }
}

