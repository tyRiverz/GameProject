using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowEffect : MonoBehaviour
{
    public Vector3 Offset = new Vector3(-0.1f, -0.1f);
    public Material material;

    GameObject shadow;
    float fade = 0f;
    // Start is called before the first frame update
    void Start()
    {
        shadow = new GameObject("Shadow");
        shadow.transform.parent = transform;
        shadow.SetActive(false);

        shadow.transform.localPosition = Offset;
        shadow.transform.localRotation = transform.rotation;
        shadow.transform.Rotate(0, 0, 180);


        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = material;

        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 1;
    }

    // Update is called once per frame
    void Update()
    {
        fade += 0.09f;

        if (fade >= 1f)
        {
            fade = 1f;
            shadow.SetActive(true);

        }        

        shadow.transform.localPosition = Offset;
    }
}
