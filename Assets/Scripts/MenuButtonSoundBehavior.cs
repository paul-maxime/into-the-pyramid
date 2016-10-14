using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonSoundBehavior : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public AudioClip MouseOverSound;
    public AudioClip ClickSound;

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(ClickSound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(MouseOverSound);
    }
}