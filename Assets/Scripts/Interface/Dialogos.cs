using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    [SerializeField] private GameObject nextDialogo;
    [SerializeField] private GameObject indicador;
    [SerializeField] private GameObject dialogo_panel;
    [SerializeField] private TMP_Text dialogo_text;
    [SerializeField] private int dialogo_Inicial;
    [SerializeField] private int dialogo_Final;
    [SerializeField] private Image imagenIzquierda;
    [SerializeField] private Image imagenCentral;
    [SerializeField] private Image imagenDerecha;
    [SerializeField] private List<Sprite> spritesDialogos;
    

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
            else if(dialogo_text.text == (textos[lineIndex].Nombre + textos[lineIndex].Dialogo) && Input.GetButtonDown("Submit"))
            {
                NextDialogueLine();
            }
            else if(Input.GetButtonDown("Submit"))
            {
                StopAllCoroutines();
                dialogo_text.text = (textos[lineIndex].Nombre + textos[lineIndex].Dialogo);
            }
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void StartDialoge()
    {
        textos = DialogsManager.singlenton.DialogosEscena(dialogo_Inicial,dialogo_Final);
        didDialogueStart = true;
        GameManager.singleton.GamePaused = true;
        dialogo_panel.SetActive(true);
        //indicador?.SetActive(false);
        playerReference.enabled = false;
        lineIndex = 0;
        CambiarSprites();
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void CambiarSprites()
    {
        if (textos[lineIndex].IdImagenIzquierda == 0)
        {
            imagenIzquierda.gameObject.SetActive(false);
        }
        else
        {
            imagenIzquierda.gameObject.SetActive(true);
        }

        if (textos[lineIndex].IdImagenCentral == 0)
        {
            imagenCentral.gameObject.SetActive(false);
        }
        else
        {
            imagenCentral.gameObject.SetActive(true);
        }

        if (textos[lineIndex].IdImagenDerecha == 0)
        {
            imagenDerecha.gameObject.SetActive(false);
        }
        else
        {
            imagenDerecha.gameObject.SetActive(true);
        }

        imagenIzquierda.sprite = spritesDialogos[textos[lineIndex].IdImagenIzquierda];
        imagenCentral.sprite = spritesDialogos[textos[lineIndex].IdImagenCentral];
        imagenDerecha.sprite = spritesDialogos[textos[lineIndex].IdImagenDerecha];
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < textos.Count)
        {
            CambiarSprites();
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            GameManager.singleton.GamePaused = false;
            dialogo_panel.SetActive(false);
            //indicador.SetActive(true);
            playerReference.enabled = true;
            GetComponent<Collider2D>().enabled = false;

            if (nextDialogo != null)
            {
                nextDialogo.SetActive(true);
            }
            gameObject.SetActive(false);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTriggerDialog = true;
            playerReference = collision.gameObject.GetComponent<SpriteRenderer>();
            //indicador?.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTriggerDialog = false;
            //indicador?.SetActive(false);
        }
    }
}
