using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollOffset : MonoBehaviour
{
    public Material mat;
    public Vector2 scrollSpeed = new Vector2(0.5f, 0.0f);

    private Vector2 offset;

    void Update()
    {
        offset += scrollSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }

    // stop the scroll
    public void StopScroll()
    {
        scrollSpeed = Vector2.zero;
    }
}
