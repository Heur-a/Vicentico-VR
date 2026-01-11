using UnityEngine;

public class RegaderaManager : MonoBehaviour
{
    [Header ("Objetos configuración")]
    public RegaderaData regaderaData;
    public PrecioConfig precioRegadera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [Header ("Valores Actuales")]
    [SerializeField] private float cantidadAguaActual;

    [SerializeField] private float aguaMax;
    void Start()
    {
        aguaMax = regaderaData.cantidadInicial;
    }

    private void OnEnable()
    {
        ComprarAccion.OnComprar += OnMejora;
    }

    private void OnDisable()
    {
        ComprarAccion.OnComprar -= OnMejora;
    }

    private void OnMejora(PrecioConfig precio)
    {
        if (precio == precioRegadera)
        {
            aguaMax += regaderaData.config.incrementoCantidad;
        }
    }
}
