using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBumper : MonoBehaviour
{
    // untuk mengatur warna bumper
public Color color;

private Renderer renderers;
    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponent<Renderer>();

	// kita akses materialnya dan kita ubah warna nya saat Start
        renderers.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
