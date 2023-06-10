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

    private bool playerTriggerDialog;
    private bool didDialogueStart;
    private int lineIndex;
    private float timeTipeText = 0.05f;
    private SpriteRenderer playerReference;


    // Update is called once per frame
    void Update()
    {
        if (playerTriggerDialog && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                StartDialoge();
            }
            else if(dialogo_text.text == dialogoPrueba[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogo_text.text = dialogoPrueba[lineIndex];
            }
        }
    }

    private void StartDialoge()
    {
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
        if (lineIndex < dialogoPrueba.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialogo_panel.SetActive(false);
            indicador.SetActive(true);
            playerReference.enabled = true;
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogo_text.text = string.Empty;

        foreach (char ch in dialogoPrueba[lineIndex])
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
