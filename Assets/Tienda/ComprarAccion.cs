using UnityEngine;


public class ComprarAccion : MonoBehaviour
{
    public PrecioConfig precioObjeto;
    private MoneyManager _cartera;
    private int _precio;
    
    public delegate void CompraEvent(PrecioConfig precio);
    public static event CompraEvent OnComprar;

    private void Start()
    {
        _cartera = MoneyManager.instance;
        _precio = (int) precioObjeto.precioBase;
    }

    public void Comprar()
    {
        if (_cartera.galletas < _precio)
        {
            Debug.Log("Dinero Insuficiente");
            return;
        }
        else
        {
            _cartera.ActualizarGalletas(-_precio);
            OnOnComprar(precioObjeto);
            
        }
        
    }

    private static void OnOnComprar(PrecioConfig precio)
    {
        OnComprar?.Invoke(precio);
    }
}