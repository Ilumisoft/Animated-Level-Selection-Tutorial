using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    SceneLoader SceneLoader { get; set; }

    private void Awake()
    {
        SceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void Load()
    {
        SceneLoader.Load(sceneName);
    }
}
