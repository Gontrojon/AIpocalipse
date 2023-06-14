using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private GameObject ButonPlay;
    [SerializeField] private GameObject ButonCredits;
    [SerializeField] private GameObject ButonCloseGame;
    [SerializeField] private AudioSource audiosource;

    private void OnEnable()
    {
        audiosource.Play();
    }

    private void OnDisable()
    {
        audiosource.Pause();
    }

    public void PartidaNuevaButonOnclick()
    {
        gameObject.SetActive(false);
        GameManager.singleton.StartWhitMenu();
        GameManager.singleton.StartGame();
    }

    public void CerrarJuegoButonOnclick()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void Restart()
    {
        //GameManager.instance.Restart();
    }

    public void CreditosButonOnclick()
    {
        ActivaDesactivaCreditos(true);

    }

    public void CerrarCreditosButonOnclick()
    {
        ActivaDesactivaCreditos(false);
    }

    private void ActivaDesactivaCreditos(bool status)
    {
        panelCreditos.SetActive(status);
        ButonPlay.SetActive(!status);
        ButonCredits.SetActive(!status);
        ButonCloseGame.SetActive(!status);
    }
}
