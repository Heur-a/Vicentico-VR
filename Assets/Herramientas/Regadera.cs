using UnityEngine;

public class Regadera : MonoBehaviour
{
    public float umbralGrados = 70;
    public GameObject chorro;
    public GameObject hitcast;
    public string layerMaceta = "maceta";
    public string blendParameter = "grow";
    public float stepAmount = 0.001f;
    Vector3 direction = -Vector3.up;
    float maxDistance = 2f;
    void Update()
    {
        if (testIncl())
            testRay();
    }
    private bool testIncl()
    {
        float angle = Vector3.SignedAngle(this.transform.up, Vector3.up, this.transform.right);
        chorro.SetActive(angle < umbralGrados);
        return (angle < umbralGrados);
    }
    private void testRay()
    {
        int layerMask = LayerMask.GetMask(layerMaceta);
        RaycastHit hit;
        if (Physics.Raycast(hitcast.transform.position, direction, out hit, maxDistance, layerMask))
        {
            AdvanceBlendTree(hit);
        }
        Debug.DrawRay(hitcast.transform.position, direction * maxDistance, Color.red);
    }
    void AdvanceBlendTree(RaycastHit hit)
    {
        Debug.Log(hit.transform.name);
        Animator anim = hit.transform.GetComponent<Animator>();
        float current = anim.GetFloat(blendParameter);
        current = Mathf.Clamp(current + stepAmount, 0f, 1);
        anim.SetFloat(blendParameter, current);
    }
}
