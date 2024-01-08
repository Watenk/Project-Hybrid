using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    private List<IEntity> entities = new List<IEntity>();

    public void Add(GameObject entityPrefab, Vector3 spawnPos){
        
        if (entityPrefab.GetComponent<IEntity>() == null) { 
            Debug.LogError(entityPrefab.name + " Doesn't contain IEntity"); 
            return; }

        GameObject entityGO = Instantiate(entityPrefab, spawnPos, Quaternion.identity);
        IEntity newEntity = entityGO.GetComponent<IEntity>();
        newEntity.GameObject = entityGO;
        entities.Add(newEntity);
    }

    public void Remove(IEntity entity){
        entities.Remove(entity);
        Destroy(entity.GameObject);
    }
}
