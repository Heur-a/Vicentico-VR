using System;
using UnityEngine;

public class CortarArbol : MonoBehaviour
{
    public string blendParameter = "cortar";
    public float stepAmount = 0.34f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Animator anim = other.gameObject.GetComponent<Animator>();
        if (anim != null)
        {
            float current = anim.GetFloat(blendParameter);
            current = Mathf.Clamp(current + stepAmount, 0f, 1);
            Debug.Log(current);
            anim.SetFloat(blendParameter, current);
            if (current >= 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
