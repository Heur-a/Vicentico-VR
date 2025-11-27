using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TiendaGalletas : MonoBehaviour
{
    [Header("Configuración")]
    public int precioPorGalleta = 1;
    private int cantidadAComprar = 0;

    [Header("Referencias UI")]
    public TextMeshProUGUI textoContador; // El número en medio
    public TextMeshProUGUI textoPrecioTotal; // "Coste: X"
    public Button botonMas;
    public Button botonMenos;
    public Button botonComprar;

    void Start()
    {
        // Inicializamos la tienda en 0
        cantidadAComprar = 0;
        ActualizarUI();
    }

    public void BotonMas()
    {
        // Solo aumentamos si tenemos dinero suficiente para la SIGUIENTE unidad
        int dineroJugador = GameManager.Instance.monedasActuales;
        
        if ((cantidadAComprar + 1) * precioPorGalleta <= dineroJugador)
        {
            cantidadAComprar++;
            ActualizarUI();
        }
    }

    public void BotonMenos()
    {
        if (cantidadAComprar > 0)
        {
            cantidadAComprar--;
            ActualizarUI();
        }
    }

    public void BotonComprar()
    {
        if (cantidadAComprar > 0)
        {
            // Restar dinero y dar galletas (Lógica de inventario iría aquí)
            GameManager.Instance.GastarMonedas(cantidadAComprar * precioPorGalleta);
            
            Debug.Log("Has comprado " + cantidadAComprar + " galletas.");
            
            // Resetear contador tras compra
            cantidadAComprar = 0;
            ActualizarUI();
        }
    }

    private void ActualizarUI()
    {
        int dineroJugador = GameManager.Instance.monedasActuales;
        int costeFuturo = (cantidadAComprar + 1) * precioPorGalleta;

        // 1. Actualizar Textos
        textoContador.text = cantidadAComprar.ToString();
        textoPrecioTotal.text = "Total: " + (cantidadAComprar * precioPorGalleta).ToString();

        // 2. Lógica del Botón MENOS (Desactivar si es 0)
        botonMenos.interactable = (cantidadAComprar > 0);

        // 3. Lógica del Botón MAS (CRUCIAL: Desactivar si no alcanza para uno más)
        if (costeFuturo > dineroJugador)
        {
            botonMas.interactable = false; // Se apaga porque no puedes pagar el siguiente
        }
        else
        {
            botonMas.interactable = true;
        }

        // 4. Lógica del Botón COMPRAR
        botonComprar.interactable = (cantidadAComprar > 0);
    }
}