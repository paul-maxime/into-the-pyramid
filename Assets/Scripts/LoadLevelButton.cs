using UnityEngine;
using UnityEngine.EventSystems;

public class LoadLevelButton : MonoBehaviour, IPointerClickHandler
{
    public string LevelName;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.LoadLevel(LevelName);
    }
}
