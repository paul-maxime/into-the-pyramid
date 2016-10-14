using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    public int MusicIndex;

    void Start()
    {
        GameManager.GetInstance().PlayMusic(MusicIndex);
    }
    
    void Update()
    {

    }
}
