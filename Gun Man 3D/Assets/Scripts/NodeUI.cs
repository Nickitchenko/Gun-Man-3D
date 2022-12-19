using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Platform target;

    public TMP_Text upgrade_cost;
    public Button upgrade_button;

    public TMP_Text SellAmount;
    
    public void SetTarget(Platform _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgrade_cost.text = "$" + target.playerBluePrint.upgradeCost;
            upgrade_button.interactable = true;
        }
        else
        {
            upgrade_button.interactable = false;
            upgrade_cost.text = "DONE";
        }

        SellAmount.text = "$" + target.playerBluePrint.GetSellAmount();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradePlayer();
        BuildManager.instance.DeselectPlatform();
    }

    public void Sell()
    {
        target.SellPlayer();
        BuildManager.instance.DeselectPlatform();
    }

}
