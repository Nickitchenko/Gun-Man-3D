using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    private PlayerBluePrint playerToBuild;
    private Platform selectedPlatform;

    public NodeUI nodeUI;

    public bool CanBuild { get { return playerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= playerToBuild.cost; } }

    public void SelectPlatform(Platform platform)
    {
        if (selectedPlatform == platform)
        {
            DeselectPlatform();
            return;
        }

        selectedPlatform = platform;
        playerToBuild = null;

        nodeUI.SetTarget(platform);
    }

    public void DeselectPlatform()
    {
        selectedPlatform = null;
        nodeUI.Hide();
    }

    public void SelectPlayerToBuild(PlayerBluePrint player)
    {
        playerToBuild = player;
        DeselectPlatform();
    }

    public PlayerBluePrint GetPlayerToBuild()
    {
        return playerToBuild;
    }
}
