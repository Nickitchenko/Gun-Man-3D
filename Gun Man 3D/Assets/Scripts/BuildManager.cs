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

    public GameObject GunManPrefab;
    public GameObject SoldierPrefab;
    public GameObject MissleTurretPrefab;

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

        Debug.Log("Player build! Money left: " + PlayerStats.Money);
    }

    public void SelectPlayerToBuild(PlayerBluePrint player)
    {
        playerToBuild = player;
    }
}
