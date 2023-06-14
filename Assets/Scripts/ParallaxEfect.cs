using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfect : MonoBehaviour
{
    // referencia a la camara
    public GameObject cam;
    // cantidad de efecto parallax
    public float parallaxEffect;

    // variables para longitud del fondo y la posicion inicial
    private float fondoWidth, startPos;

    public bool activado;

    // Start is called before the first frame update
    void Start()
    {
        Iniciar();
    }

    private void Iniciar()
    {
        // guardamos la posicion inicial
        startPos = transform.position.x;
        // guardamos una referencia al tamaño del sprite renderer del fondo en X
        fondoWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activado)
        {
            // variable para poder calcular cuadno se tiene que repetir la capa
            float temp = (cam.transform.position.x * (1 - parallaxEffect));
            // variable que mueve la capa segun el efecto de parallax
            float dist = (cam.transform.position.x * parallaxEffect);

            // se asigna a la posicion de la capa su posicion inicial mas la distancia recorrida
            transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        }
        // if para la reposicion de las capas
        /*
        if(temp > startPos + fondoWidth)
        {
            // se le suma a la posicion inicial el ancho del fondo
            startPos += fondoWidth;
        }else if (temp < startPos - fondoWidth)
        {
            // se le resta a la posicion inicial el ancho del fondo
            startPos -= fondoWidth;
        }*/
    }

    public void AcitvarParallax(bool status)
    {
        activado = status;

        if (activado)
        {
            Iniciar();
        }
    }
}
