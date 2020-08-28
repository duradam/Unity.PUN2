using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gamesettings;
    public static GameSettings GameSettings => Instance._gamesettings;
    [SerializeField]
    private List<NetworkedPrefab> _networkPrefabs = new List<NetworkedPrefab>();
    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation){
        foreach(NetworkedPrefab networkedPrefab in Instance._networkPrefabs){
            if (networkedPrefab.Prefab == obj){
                if (networkedPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation);
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameobject name " + networkedPrefab.Prefab);
                    return null; 
                }
            }
        }
        
        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkPrefabs()
    {
    #if UNITY_EDITOR
        Instance._networkPrefabs.Clear();    

        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < results.Length; i++)
        {
            if(results[i].GetComponent<PhotonView>() != null){
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance._networkPrefabs.Add(new NetworkedPrefab(results[i], path));
            }
        }
    #endif
    }
}
