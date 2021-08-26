using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public Text text;
    public MeshRenderer Renderer;

    public Vector3 rgb;
    public Vector3 direction;

    void Start()
    {
        //transform.position = Vector3.up;
        transform.localScale = Vector3.one * 2f;

        rgb = Vector3.zero;
        direction = Vector3.one;

        InvokeRepeating("ChangeColor", 0, 0.05f);
    }

    void Update()
    {
        transform.Rotate(Vector3.one * 10.0f * Time.deltaTime);
    }

    private void ChangeColor()
    {
        Material material = Renderer.material;

        rgb.x = material.color.r + Random.Range(0f, 1 / 64f) * direction.x;
        rgb.y = material.color.g + Random.Range(0f, 1 / 64f) * direction.y;
        rgb.z = material.color.b + Random.Range(0f, 1 / 64f) * direction.z;

        if (rgb.x > 1 || rgb.x < 0)
        {
            rgb.x = Mathf.Clamp01(rgb.x);
            direction.x *= -1;
        }
        if (rgb.y > 1 || rgb.y < 0)
        {
            rgb.y = Mathf.Clamp01(rgb.y);
            direction.y *= -1;
        }
        if (rgb.z > 1 || rgb.z < 0)
        {
            rgb.z = Mathf.Clamp01(rgb.z);
            direction.z *= -1;
        }

        text.text = $"R:{rgb.x}\nG:{rgb.y}\nB:{rgb.z}";
        material.color = new Color(rgb.x, rgb.y, rgb.z, 1);
    }
}
