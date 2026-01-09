using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public GameObject abreFruta;
    public GameObject abreNoFruta;
    public GameObject fruta;
    public List<Transform> frutaSpawn;

    private void CrearFruta()
    {
        if (frutaSpawn.Count >= 0)
        {
            foreach (Transform spawnPoint in frutaSpawn)
            {
                Instantiate(fruta, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    private void CambiarArbol()
    {
        if (abreFruta != null && abreNoFruta != null)
        {
            abreFruta.gameObject.SetActive(false);
            abreNoFruta.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Prefabs No Configurados");
        }
        
    }

    public void RecolectarFruta()
    {
        CrearFruta();
        CambiarArbol();
    }


}
