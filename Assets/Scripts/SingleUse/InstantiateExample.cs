using System.Collections;
using System.Collections.Generic;
using MalbersAnimations;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    public MFreeLookCamera FreeLookCamera; 
    private void Awake()
    {
        Vector2 offset = Random.insideUnitCircle * 3f;
        Vector3 position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);
        transform.SetPositionAndRotation(new Vector3{x=transform.position.x, y=transform.position.y, z=transform.position.z}
            , Quaternion.identity) ;
        var unka = MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);

        FreeLookCamera.SetTarget(unka.transform); 
    }
}
