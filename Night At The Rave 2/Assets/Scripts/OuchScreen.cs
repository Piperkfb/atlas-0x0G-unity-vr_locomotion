using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OuchScreen : MonoBehaviour
{
    private Image Ouch;
    // Start is called before the first frame update
    void Start()
    {
        Ouch = GetComponent<Image>();
    }

    public void Ouch1()
    {
        Ouch.color = new Color(1, 1, 1, 0.05f);
    }
    public void Ouch2()
    {
        Ouch.color = new Color(1, 1, 1, 0.2f);
    }
    public void Ouch3()
    {
        Ouch.color = new Color(1, 1, 1, 0.6f);

    }
}
