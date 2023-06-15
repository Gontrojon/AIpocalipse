using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public static MenuPrincipal singlenton;

    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private GameObject panelCreditosGameOver;
    [SerializeField] private GameObject ButonPlay;
    [SerializeField] private GameObject ButonCredits;
    [SerializeField] private GameObject ButonCloseGame;
    [SerializeField] private AudioSource audiosource;

    private void Awake()
    {
        singlenton = this;
    }

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

    public void ContinuarButonOnClick()
    {
        gameObject.SetActive(false);
        GameManager.singleton.StartGame();
    }

    public void CerrarJuegoButonOnclick()
    {
        Debug.Log("Se cierra el juego");
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

    public void ActivarCreditosGameOver()
    {
        panelCreditosGameOver.SetActive(true);
        ActivaDesactivaCreditos(true);
        panelCreditos.SetActive(false);
    }

    public void CerrarCreditosGameOverButonOnclick()
    {
        panelCreditosGameOver.SetActive(false);
        ButonCloseGame.GetComponent<RectTransform>().position = ButonCredits.GetComponent<RectTransform>().position;
        ButonCloseGame.SetActive(true);
    }

    private void ActivaDesactivaCreditos(bool status)
    {
        panelCreditos.SetActive(status);
        ButonPlay.SetActive(!status);
        ButonCredits.SetActive(!status);
        ButonCloseGame.SetActive(!status);
    }
}
