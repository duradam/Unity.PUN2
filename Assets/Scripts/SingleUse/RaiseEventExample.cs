using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RaiseEventExample : MonoBehaviourPun

{
    private SpriteRenderer _spriteRenderer;

    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Space)){
            ChangeColor();
        }
    }

    private void ChangeColor(){
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b  = Random.Range(0f, 1f);
        _spriteRenderer.color = new Color(r, g, b, 1f);
    }
}
