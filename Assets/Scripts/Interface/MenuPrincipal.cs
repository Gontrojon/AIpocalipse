using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPrincipal : MonoBehaviour
{
    public static MenuPrincipal singlenton;

    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private GameObject ButonPlay;
    [SerializeField] private GameObject ButonCredits;
    [SerializeField] private GameObject ButonCloseGame;
    [SerializeField] private GameObject ButonCloseCredits;
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
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ButonCloseCredits);

    }

    public void CerrarCreditosButonOnclick()
    {
        if (GameManager.singleton.GameOver)
        {
            panelCreditos.SetActive(false);
            ButonCloseGame.GetComponent<RectTransform>().position = ButonCredits.GetComponent<RectTransform>().position;
            ButonCloseGame.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(ButonCloseGame);
        }
        else
        {
            ActivaDesactivaCreditos(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(ButonCredits);
        }
    }

    private void ActivaDesactivaCreditos(bool status)
    {
        panelCreditos.SetActive(status);

        if (!GameManager.singleton.CanPause)
        {
            ButonPlay.SetActive(!status);
        }
        ButonCredits.SetActive(!status);
        ButonCloseGame.SetActive(!status);
    }
}
