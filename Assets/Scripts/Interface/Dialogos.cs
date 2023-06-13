using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogos : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogoPrueba;
    [SerializeField] private GameObject indicador;
    [SerializeField] private GameObject dialogo_panel;
    [SerializeField] private TMP_Text dialogo_text;
    [SerializeField] private int dialogo_Inicial;
    [SerializeField] private int dialogo_Final;

    private bool playerTriggerDialog;
    private bool didDialogueStart;
    private int lineIndex;
    private float timeTipeText = 0.02f;
    private SpriteRenderer playerReference;
    private List<Textos> textos;


    // Update is called once per frame
    void Update()
    {
        if (playerTriggerDialog)
        {
            if (!didDialogueStart)
            {
                StartDialoge();
            }
            else if(dialogo_text.text == (textos[lineIndex].Nombre + textos[lineIndex].Dialogo) && Input.GetButtonDown("Fire1"))
            {
                NextDialogueLine();
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                StopAllCoroutines();
                dialogo_text.text = (textos[lineIndex].Nombre + textos[lineIndex].Dialogo);
            }
        }
    }

    private void StartDialoge()
    {
        textos = DialogsManager.singlenton.DialogosEscena(dialogo_Inicial,dialogo_Final);
        didDialogueStart = true;
        dialogo_panel.SetActive(true);
        indicador.SetActive(false);
        playerReference.enabled = false;
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < textos.Count)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialogo_panel.SetActive(false);
            indicador.SetActive(true);
            playerReference.enabled = true;
            GetComponent<Collider2D>().enabled = false;
            Time.timeScale = 1f;
            
        }
    }

    private IEnumerator ShowLine()
    {
        dialogo_text.text = textos[lineIndex].Nombre;

        foreach (char ch in textos[lineIndex].Dialogo)
        {
            dialogo_text.text += ch;
            yield return new WaitForSecondsRealtime(timeTipeText);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colision");
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTriggerDialog = true;
            playerReference = collision.gameObject.GetComponent<SpriteRenderer>();
            indicador.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTriggerDialog = false;
            indicador.SetActive(false);
        }
    }
}
