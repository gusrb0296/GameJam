using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePopup : MonoBehaviour
{
    public int maxRecipe;
    [SerializeField] int page = 0;
    [SerializeField] Button btn_exit;
    [SerializeField] Button btn_prev;
    [SerializeField] Button btn_next;
    [SerializeField] bool locked; // test variable
    [SerializeField] GameObject[] lockedRecipe;
    [SerializeField] GameObject[] unlockedRecipe;
    private GameObject currentRecipeObject;
    void Start()
    {
        btn_exit.onClick.AddListener(exitRecipe);
        btn_prev.onClick.AddListener(prevRecipe);
        btn_next.onClick.AddListener(nextRecipe);
        page = 0;
        showDish(page, locked);
    }

    private void exitRecipe()
    {
        gameObject.SetActive(false);
    }
    private void prevRecipe()
    {
        if (page <= 0)
        {
            page = maxRecipe - 1;
        }
        else
        {
            page--;
        }
        showDish(page, locked);
    }
    private void nextRecipe()
    {
        page = (page + 1) % maxRecipe;
        showDish(page, locked);
    }

    private void showDish(int page, bool locked)
    {
        if (currentRecipeObject != null)
        {
            Destroy(currentRecipeObject);
        }

        if (locked)
        {
            currentRecipeObject = Instantiate(lockedRecipe[page], transform);
        }
        else
        {
            currentRecipeObject = Instantiate(unlockedRecipe[page], transform);
        }
    }
}