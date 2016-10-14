using UnityEngine;
using UnityEngine.EventSystems;

public class MenuExitButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
