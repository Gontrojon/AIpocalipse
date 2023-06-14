using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeactivePArallax : MonoBehaviour
{

    public List<ParallaxEfect> listaDesactivar;
    public List<ParallaxEfect> listaActivar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < listaActivar.Count; i++)
            {
                listaDesactivar[i].AcitvarParallax(false);
                listaActivar[i].AcitvarParallax(true);
            }
        }
    }
}
