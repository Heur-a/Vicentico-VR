using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Economía")]
    public int monedasActuales = 10; // Empezamos con 10 para probar
    
    [Header("UI HUD (Arriba Derecha)")]
    public TextMeshProUGUI textoMonedasHUD;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        ActualizarHUD();
    }

    public void GastarMonedas(int cantidad)
    {
        monedasActuales -= cantidad;
        ActualizarHUD();
    }

    public void ActualizarHUD()
    {
        // Actualiza el texto arriba a la derecha
        if(textoMonedasHUD != null)
            textoMonedasHUD.text = "Monedas: " + monedasActuales.ToString();
    }
}