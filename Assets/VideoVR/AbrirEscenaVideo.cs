using UnityEngine;

public class AbrirEscenaVideo : MonoBehaviour
{
 public string escenaVideo;

 public void AbrirEscena()
 {
     UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(escenaVideo);
     Debug.Log("Cargando escena: " + escenaVideo);
 }
}
