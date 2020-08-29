using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using static Photon.Pun.PhotonAnimatorView;

public class SetStartOptions : MonoBehaviour
{
    PhotonAnimatorView PhotonAnimatorView;
    void Start()
    {
        PhotonAnimatorView = GetComponent<PhotonAnimatorView>();
        foreach (var par in PhotonAnimatorView.GetSynchronizedParameters())
        {
            par.SynchronizeType = SynchronizeType.Continuous;
        }
        foreach (var lay in PhotonAnimatorView.GetSynchronizedLayers())
        {
            lay.SynchronizeType = SynchronizeType.Continuous;
        }
    }

 
}
