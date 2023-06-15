using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    private bool canPause = false;

    [SerializeField] private GameObject menupausa;
    [SerializeField] private GameObject botonPartidaNueva;
    [SerializeField] private GameObject botonContinuar;
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private Light luz;
    [SerializeField] private GameObject dialogoInicial;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Pausa();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && canPause)
        {
            if (!menupausa.activeSelf)
            {
                Pausa();
                menupausa.SetActive(true);
                if (botonPartidaNueva.activeSelf)
                {
                    botonPartidaNueva.SetActive(false);
                    botonContinuar.SetActive(true);
                }
            }
            else
            {
                StartGame();
                menupausa.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        dialogoInicial.SetActive(true);
        audiosource.Play();
    }

    public void StartWhitMenu()
    {
        canPause = true;
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        audiosource.Pause();
    }

    public void ElPajaroEstaEnElNido(GameObject player)
    {
        //StartCoroutine(FadeLight());
        menupausa.SetActive(true);
        botonPartidaNueva.SetActive(false);
        botonContinuar.SetActive(false);
        MenuPrincipal.singlenton.ActivarCreditosGameOver();
    }

    private IEnumerator FadeLight()
    {

        while (luz.intensity > 0.02f)
        {
            luz.intensity -= 0.004f;
            yield return new WaitForSeconds(0.01f);
        }

        menupausa.SetActive(true);
        botonPartidaNueva.SetActive(false);
        botonContinuar.SetActive(false);
        MenuPrincipal.singlenton.ActivarCreditosGameOver();
    }


}
