using UnityEngine;

public class NextLevelBehavior : MonoBehaviour
{
    public string NextScene;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            GameManager.GetInstance().PlayUpgrade();
            Application.LoadLevel(NextScene);
        }
    }
}
