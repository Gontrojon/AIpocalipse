using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

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
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("se pulso cancelar");
        }
    }


    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
    }

}
