using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    private List<GameObject> gameObjects = new List<GameObject>();

    //--------------------------------------------------

    public GameObject AddGameObject(GameObject prefab){
        GameObject prefabInstance = Instantiate(prefab);
        SetParent(prefabInstance, this.gameObject);
        gameObjects.Add(prefabInstance);
        return prefabInstance;
    }

    public GameObject AddGameObject(GameObject prefab, Vector3 pos){
        GameObject instance = AddGameObject(prefab);
        instance.transform.position = pos;
        return instance;
    }

    public GameObject AddGameObject(GameObject prefab, Vector3 pos, Quaternion rotation){
        GameObject instance = AddGameObject(prefab, pos);
        instance.transform.rotation = rotation;
        return instance;
    }

    public void RemoveGameObject(GameObject destroyGameObject){
        gameObjects.Remove(destroyGameObject);
        Destroy(destroyGameObject);
    }

    //------------------------------------------------------

    private void SetParent(GameObject child, GameObject parent){
        child.transform.parent = parent.transform;
    }
}
