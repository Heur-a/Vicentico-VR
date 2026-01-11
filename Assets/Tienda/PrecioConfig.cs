using UnityEngine;


[CreateAssetMenu(fileName = "precioConfig", menuName = "Tienda/precioConfig", order = 0)]
public class PrecioConfig : ScriptableObject
{
    [TextArea] public string descripcion;
    public uint precioBase = 1;
    public uint incrementoPrecio= 1;
}