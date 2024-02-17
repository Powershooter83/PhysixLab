using UnityEngine;
using UnityEngine.UI;

public class WristUiNavigation : MonoBehaviour
{
    [SerializeField] private Button itemBtn;
    [SerializeField] private Button assetsBtn;
    [SerializeField] private Button manipulationBtn;
    [SerializeField] private Button settingsBtn;

    [SerializeField] private GameObject itemPanel;
    [SerializeField] private GameObject assetsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject manipulationPanel;

    [SerializeField] private GameObject items;

    private Color _defaultColor;

    private Color _selectedColor;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#42B8FF", out _defaultColor);
        ColorUtility.TryParseHtmlString("#378CBF", out _selectedColor);
    }

    public void OnButtonClick(Selectable clickedButton)
    {
        ResetButtonColors();
        var colors = clickedButton.colors;

        switch (clickedButton.name)
        {
            case "ItemsBtn":
                itemPanel.SetActive(true);
                assetsPanel.SetActive(false);
                settingsPanel.SetActive(false);
                manipulationPanel.SetActive(false);
                items.SetActive(true);
                break;
            case "AssetsBtn":
                itemPanel.SetActive(false);
                assetsPanel.SetActive(true);
                settingsPanel.SetActive(false);
                manipulationPanel.SetActive(false);
                items.SetActive(false);
                break;
            case "ManipulationBtn":
                itemPanel.SetActive(false);
                assetsPanel.SetActive(false);
                settingsPanel.SetActive(false);
                manipulationPanel.SetActive(true);
                items.SetActive(false);
                break;
            case "SettingsBtn":
                itemPanel.SetActive(false);
                assetsPanel.SetActive(false);
                settingsPanel.SetActive(true);
                manipulationPanel.SetActive(false);
                items.SetActive(false);
                break;
        }


        colors.normalColor = _selectedColor;
        clickedButton.colors = colors;
    }

    private void ResetButtonColors()
    {
        itemBtn.colors = SetButtonColor(itemBtn, _defaultColor);
        assetsBtn.colors = SetButtonColor(assetsBtn, _defaultColor);
        manipulationBtn.colors = SetButtonColor(manipulationBtn, _defaultColor);
        settingsBtn.colors = SetButtonColor(settingsBtn, _defaultColor);
    }

    private static ColorBlock SetButtonColor(Selectable button, Color color)
    {
        var colors = button.colors;
        colors.normalColor = color;
        return colors;
    }
}