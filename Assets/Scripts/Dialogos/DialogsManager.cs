using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogsManager : MonoBehaviour
{
    public static DialogsManager singlenton;

    private ListaTextos listaTextos;
    private const string FILE_NAME = "/conversation/conversation.json";

    private void Awake()
    {
        singlenton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        string n = Application.dataPath;

        Debug.Log(n+FILE_NAME);
        CargarDialogos();
    }

    public List<Textos> DialogosEscena(int inicial, int final)
    {
        if(final >= listaTextos.listaDialogos.Count)
        {
            final = listaTextos.listaDialogos.Count-1;
        }
        List<Textos> lt = new List<Textos>();
        for (int i = inicial; i < final+1; i++)
        {
            lt.Add(listaTextos.listaDialogos[i]);
        }

        return lt;
    }


    private void CargarDialogos()
    {
        string path = Application.dataPath + FILE_NAME;
        string jsonDialogos = File.ReadAllText(path);
        Debug.Log(jsonDialogos);

        listaTextos = JsonUtility.FromJson<ListaTextos>(jsonDialogos);

        //Debuglista();
    }

    private void Debuglista()
    {
        Debug.Log("Se procede a debugear");
        Debug.Log(listaTextos.listaDialogos.Count);
        foreach (Textos t in listaTextos.listaDialogos)
        {
            Debug.Log(t.IdImagenIzquierda);
            Debug.Log(t.IdImagenDerecha);
            Debug.Log(t.Nombre);
            Debug.Log(t.Dialogo);
        }
    }
}
