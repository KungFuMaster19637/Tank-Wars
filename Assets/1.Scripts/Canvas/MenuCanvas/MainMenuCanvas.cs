using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : AnimatedCanvasVirtual
{
    public void CampaignButton()
    {
        MainFlowManager.Instance.OnCampaignButton();
    }

    public void MultiplayerButton()
    {
        MainFlowManager.Instance.OnMultiplayerButton();
    }
    public void OptionsButton()
    {
        MainFlowManager.Instance.OnOptionButton();
    }

    public void QuitButton()
    {
        MainFlowManager.Instance.OnQuitButton();
    }

    public override IEnumerator OnOpen()
    {
        return base.OnOpen();
    }

    public override IEnumerator OnClose()
    {
        return base.OnClose();
    }
}
