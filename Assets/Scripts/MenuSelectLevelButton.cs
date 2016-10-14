using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelectLevelButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] EnableButtons;
    public GameObject[] DisableButtons;

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (GameObject button in EnableButtons)
        {
            button.SetActive(true);
        }
        foreach (GameObject button in DisableButtons)
        {
            button.SetActive(false);
        }
    }
}
