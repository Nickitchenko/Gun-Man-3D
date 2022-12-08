using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    private PlayerBluePrint playerToBuild;

    public bool CanBuild { get { return playerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= playerToBuild.cost; } }

    public void BuildPlayerOn(Platform platform)
    {
        if(PlayerStats.Money<playerToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= playerToBuild.cost;

        GameObject player = (GameObject)Instantiate(playerToBuild.prefab, platform.GetBuildPosition(), Quaternion.identity);
        platform.player = player;

        GameObject effect = (GameObject)Instantiate(buildEffect, platform.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Player build! Money left: " + PlayerStats.Money);
    }

    public void SelectPlayerToBuild(PlayerBluePrint player)
    {
        playerToBuild = player;
    }
}
