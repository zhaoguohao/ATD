﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTriggerEvent : MonoBehaviour
{
    public Individual tower;
    private bool isCollideTower;

    private void OnTriggerEnter(Collider collison)
    {
        //Individual tower = gameObject.transform.parent.gameObject.GetComponent<Individual>();
        var collisonObject = collison.gameObject;

        foreach (Transform TowerChild in tower.transform)
        {
            if (TowerChild.gameObject == collisonObject)
            {
                isCollideTower = true;
            }
        }
        //子弹打到玩家、非个体单位
        if (isCollideTower || collison.name == "PlayerHandle" || LayerMask.LayerToName(collisonObject.layer) != "Individual")
        {
            Destroy(gameObject);
            return;
        }
        MessageSystem messageSystem = GetComponent<MessageSystem>();
        Individual otherIndividual = collisonObject.GetComponent<Individual>();

        messageSystem.SendMessage(1, otherIndividual.ID, tower.attack);
        //特效产生

        Destroy(gameObject);
    }

    private void OnSpecialEffect()
    {
        
    }
}
