using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPopup : MonoBehaviour
{
    public int maxPage;
    [SerializeField] int page = 1;
    [SerializeField] Button btn_exit;
    [SerializeField] Button btn_prev;
    [SerializeField] Button btn_next;

    [SerializeField] Sprite[] guideImg;

    [SerializeField] GameObject currentImg;
    void Start()
    {
        btn_exit.onClick.AddListener(exitTutorial);
        btn_prev.onClick.AddListener(prevSlide);
        btn_next.onClick.AddListener(nextSlide);
    }

    void OnEnable()
    {
        page = 1;
        showPage(page);
        btn_next.gameObject.SetActive(true);
        btn_prev.gameObject.SetActive(false);
    }

    private void exitTutorial()
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
        if (page <= 1)
        {
            btn_prev.gameObject.SetActive(false);
        }
        showPage(page);
    }
    private void nextSlide()
    {
        page++;
        if (!btn_prev.gameObject.activeSelf)
        {
            btn_prev.gameObject.SetActive(true);
        }
        if (page >= maxPage)
        {
            btn_next.gameObject.SetActive(false);
        }
        showPage(page);
    }

    private void showPage(int page)
    {
        currentImg.GetComponent<Image>().sprite = guideImg[page - 1];
    }
}
