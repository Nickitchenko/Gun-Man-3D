using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public PlayerBluePrint playerBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (player != null)
        {
            buildManager.SelectPlatform(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        //build a player
        BuildPlayer(buildManager.GetPlayerToBuild());
    }

    void BuildPlayer(PlayerBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= bluePrint.cost;

        GameObject _player = (GameObject)Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        player = _player;

        playerBluePrint = bluePrint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Player upgraded!");
    }

    public void UpgradePlayer()
    {
        if (PlayerStats.Money < playerBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= playerBluePrint.upgradeCost;

        //Get rid of the old player
        Destroy(player);

        //Build a new one
        GameObject _player = (GameObject)Instantiate(playerBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        player = _player;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Player build!");
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (!buildManager.CanBuild) { return; }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
