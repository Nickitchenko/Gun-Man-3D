using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public PlayerBluePrint GunMan;
    public PlayerBluePrint Soldier;
    public PlayerBluePrint MissleTurret;
    public PlayerBluePrint LazerBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectGunMan()
    {
        buildManager.SelectPlayerToBuild(GunMan);
    }

    public void SelectSoldier()
    {
        buildManager.SelectPlayerToBuild(Soldier);
    }

    public void SelectMissleTurret()
    {
        buildManager.SelectPlayerToBuild(MissleTurret);
    }

    public void SelectLazerBeamer()
    {
        buildManager.SelectPlayerToBuild(LazerBeamer);
    }

}
