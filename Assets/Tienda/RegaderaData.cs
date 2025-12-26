using UnityEngine;

[CreateAssetMenu(fileName = "RegaderaData", menuName = "GameData/RegaderaData")]
public class RegaderaData : ScriptableObject
{
    [Header("Stats Base")]
    public float duracionRiego = 2f;
    public float cantidadInicial = 1;
    public MejoraRegaderaConfig config;
    
}
