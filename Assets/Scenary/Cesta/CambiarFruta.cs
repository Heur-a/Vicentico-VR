using System;
using System.Collections.Generic;
using UnityEngine;

public class CambiarFruta : MonoBehaviour
{
    public List<Fruta> frutasValor;
    public List<GameObject> frutasObject;
    public Dictionary<String, Fruta> frutaValorMapa = new Dictionary<string, Fruta>();

    private void Start()
    {
        for (int i = 0; i < frutasValor.Count; i++)
        {
            frutaValorMapa.Add
            (
                frutasObject[i].tag,
                frutasValor[i]
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject frutaObject = other.gameObject;
        if (frutaValorMapa.ContainsKey(frutaObject.tag))
        {
            Debug.Log(frutaObject);
            DarGalletas(frutaValorMapa[frutaObject.tag]);
            Destroy(frutaObject);
        }
    }

    private void DarGalletas(Fruta fruta)
    {
        MoneyManager.instance.ActualizarGalletas(fruta.GalletasDadas);
    }
}