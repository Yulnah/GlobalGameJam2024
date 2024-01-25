using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject panelToControl;

    void Start()
    {
        // Check if the panel is assigned
        if (panelToControl == null)
        {
            enabled = false; // Disable the script to avoid issues
            return;
        }

        ActivatePanel();

        // Schedule the deactivation after X seconds
        Invoke("DeactivatePanel", 4f);
    }

    void ActivatePanel()
    {
        panelToControl.SetActive(true);
    }

    void DeactivatePanel()
    {
        panelToControl.SetActive(false);
    }
}
