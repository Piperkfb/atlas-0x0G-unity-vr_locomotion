using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverVisuals : MonoBehaviour
{
    public GameObject Reticle;
    private Color FarColor = new Color(1f, 1f, 1f, 0.1f);
    private Color CloseColor = new Color(1f, 0f, 0f, 0.1f);
    private Color GrabColor = new Color(0f, 0f, 0f, 0f);
    // Start is called before the first frame update
    private new Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void HoverStart()
    {
        if (renderer != null)
        {
            renderer.material.color = CloseColor;
        }
    }
    public void HoverEnd()
    {
        if (renderer != null)
        {
            renderer.material.color = FarColor;
        }
    }
    public void HoverGrab()
    {
        Reticle.SetActive(false);
    }
    public void HoverDrop()
    {
        Reticle.SetActive(true);
    }
}
