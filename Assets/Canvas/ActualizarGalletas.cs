using System;
using TMPro;
using UnityEngine;

public class ActualizarGalletas : MonoBehaviour
{
    public TMP_Text _tmpText;

    private void Start()
    {
        MoneyManager mm = MoneyManager.instance;
        int galleta = mm.GetGalleta();
        _tmpText.text = galleta.ToString();
    }

    private void OnEnable()
    {
        MoneyManager.OnMoneyChanged += Actualizar;
    }

    private void OnDisable()
    {
        MoneyManager.OnMoneyChanged -= Actualizar;
    }

    private void Actualizar(int cantidad)
    {
        _tmpText.text = cantidad.ToString();
    }
}
