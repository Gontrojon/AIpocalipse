using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPrincipal : MonoBehaviour
{
    public static MenuPrincipal singlenton;

    private bool menuActivo = true;

    public bool MenuActivo
    {
        get { return menuActivo; }
        set { menuActivo = value; }
    }


    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private GameObject ButonPlay;
    [SerializeField] private GameObject ButonContinue;
    [SerializeField] private GameObject ButonCredits;
    [SerializeField] private GameObject ButonCloseGame;
    [SerializeField] private GameObject ButonCloseCredits;
    [SerializeField] private AudioSource audiosource;

    private void Awake()
    {
        singlenton = this;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ButonPlay);
    }

    private void Update()
    {
        if (menuActivo)
        {
            float vertical = Input.GetAxisRaw("Vertical");

            if (vertical > 0 || vertical < 0)
            {
                GameObject go = EventSystem.current.currentSelectedGameObject;
                if (go == null)
                {
                    if (panelCreditos.activeSelf)
                    {
                        EventSystem.current.SetSelectedGameObject(ButonCloseCredits);
                    }
                    else if (ButonPlay.activeSelf)
                    {
                        EventSystem.current.SetSelectedGameObject(ButonPlay);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(ButonContinue);
                    }
                    
                }
            }
        }
    }

    private void OnEnable()
    {
        menuActivo = true;
        audiosource.Play();
    }

    private void OnDisable()
    {
        menuActivo = false;
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
