using UnityEngine;

[CreateAssetMenu(fileName = "MejoraRegaderaConfig", menuName = "Tienda/MejoraRegaderaConfig")]
public class MejoraRegaderaConfig : ScriptableObject
{
    public string nombreMejora;
    [TextArea] public string descripcion;
    public float incrementoDuracion = 0.5f;
    public uint incrementoCantidad = 1;
}