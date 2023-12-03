using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    public float speed;
    [SerializeField]
    private Renderer _bgRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
