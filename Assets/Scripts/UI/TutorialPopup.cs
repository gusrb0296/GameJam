using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPopup : MonoBehaviour
{
    public int maxPage;
    [SerializeField] int page = 0;
    [SerializeField] Button btn_exit;
    [SerializeField] Button btn_prev;
    [SerializeField] Button btn_next;
    void Start()
    {
        btn_exit.onClick.AddListener(exitTutorial);
        btn_prev.onClick.AddListener(prevSlide);
        btn_next.onClick.AddListener(nextSlide);
    }

    private void exitTutorial()
    {
        gameObject.SetActive(false);
    }

    private void prevSlide()
    {
    }
    private void nextSlide()
    {
    }

    private void showPage(int page)
    { }
}
