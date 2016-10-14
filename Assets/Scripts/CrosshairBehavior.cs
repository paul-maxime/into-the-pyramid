using UnityEngine;

public class CrosshairBehavior : MonoBehaviour
{
    public Texture2D Texture;
    
    void OnGUI()
    {
        GUI.DrawTexture(
            new Rect(
                (Screen.width - Texture.width) / 2, (Screen.height - Texture.height) / 2,
                Texture.width, Texture.height),
            Texture);
    }
}
