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

    [SerializeField] bool locked;
    [SerializeField] GameObject[] lockedRecipe;
    [SerializeField] GameObject[] unlockedRecipe;
    private GameObject currentRecipeObject;
    void Start()
    {
        btn_exit.onClick.AddListener(exitRecipe);
        btn_prev.onClick.AddListener(prevSlide);
        btn_next.onClick.AddListener(nextSlide);
    }

    void OnEnable()
    {
        page = 0;
        showDish(page, locked);

        btn_next.gameObject.SetActive(true);
        btn_prev.gameObject.SetActive(false);
    }

    private void exitRecipe()
    {
        gameObject.SetActive(false);
    }
  
    private void prevSlide()
    {
        page--;
        if (!btn_next.gameObject.activeSelf)
        {
            btn_next.gameObject.SetActive(true);
        }
        if (page <= 0)
        {
            btn_prev.gameObject.SetActive(false);
        }
        showDish(page, locked);
    }

    private void nextSlide()
    {
        page++;
        if (!btn_prev.gameObject.activeSelf)
        {
            btn_prev.gameObject.SetActive(true);
        }
        if (page >= maxRecipe)
        {
            btn_next.gameObject.SetActive(false);
        }
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