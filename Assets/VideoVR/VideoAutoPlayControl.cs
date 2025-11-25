using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoAutoPlayControl : MonoBehaviour
{
    public string escenaDeVuelta = "Main";
    public VideoPlayer video;
    void Start()
    {
        if (video == null)
        {
            video = GetComponent<VideoPlayer>();
        }
        video.loopPointReached += VideoTerminado;
    }
    void VideoTerminado(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync(escenaDeVuelta);
    }
}
