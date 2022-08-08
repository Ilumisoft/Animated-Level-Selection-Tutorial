using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    Transform levelContainer;

    List<GameObject> elements = new List<GameObject>();

    GameObject CurrentElement => elements[currentIndex];

    int currentIndex = 0;

    private void Awake()
    {
        // Add all children of the level container to the list of elements
        for(int i=0; i<levelContainer.childCount; i++)
        {
            elements.Add(levelContainer.GetChild(i).gameObject);
        }

        // Disable all elements
        foreach (var element in elements)
        {
            element.SetActive(false);
        }

        // Enable first level element
        if (elements.Count > 0)
        {
            currentIndex = 0;
            CurrentElement.SetActive(true);
        }
    }

    void Update()
    {
        if (elements.Count == 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectPreviousLevel();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadLevel();
        }
    }

    private void SelectNextLevel()
    {
        CurrentElement.SetActive(false);

        // Increase index
        currentIndex = Mathf.Min(elements.Count - 1, currentIndex + 1);

        CurrentElement.SetActive(true);
    }

    private void SelectPreviousLevel()
    {
        CurrentElement.SetActive(false);

        // Decrease index
        currentIndex = Mathf.Max(0, currentIndex - 1);

        CurrentElement.SetActive(true);
    }

    private void LoadLevel()
    {
        // Disable the level selector behaviour to prevent further interaction while the level is being loaded
        this.enabled = false;

        if (CurrentElement.TryGetComponent<Level>(out var level))
        {
            level.Load();
        }
    }
}
