using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private void Awake()
    {
        transform.SetPositionAndRotation(new Vector3{x=transform.position.x-3, y=transform.position.y, z=transform.position.z}
            , Quaternion.identity) ;
        MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
    }
}
