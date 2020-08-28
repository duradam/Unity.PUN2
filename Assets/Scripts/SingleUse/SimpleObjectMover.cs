using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun
{
    [SerializeField]
    private float _moveSpeed = 1f;
    private Animator _animator;

    private bool _moving = false;

    private void Awake(){
        _animator = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (base.photonView.IsMine){
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(x,y,0f) * _moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                updateMovingBoolean();
            }
        }        
    }

    private void updateMovingBoolean(){
        _moving = !_moving;
        _animator.SetBool("Moving", _moving);
    }
}
