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

}
