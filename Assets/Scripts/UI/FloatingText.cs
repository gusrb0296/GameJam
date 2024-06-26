using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    #region Fields

    [SerializeField] float floatingTime = 1.5f;
    [SerializeField] Color textColor;
    private float _floatingSpeed = 0.5f;
    private float _alphaSpeed = 1.5f;

    [SerializeField] private TextMeshProUGUI _txtGold;
    public Color Alpha;

    #endregion

    #region Properties

    public long Gold { get; private set; }

    #endregion

    #region Init

    public void Initialize(int value)
    {
        SetGold(value);
        Alpha = _txtGold.color;
        //Alpha = Color.white;
        Alpha = textColor;
        Alpha.a = 1;

        Destroy(gameObject, floatingTime);
    }

    #endregion

    #region Unity Flow

    private void Update()
    {

        transform.Translate(Vector2.up * _floatingSpeed * Time.deltaTime);
        Alpha.a = Mathf.Lerp(Alpha.a, 0, Time.deltaTime * _alphaSpeed);

        _txtGold.color = Alpha;
    }

    #endregion

    #region SetGold

    public void SetGold(long value)
    {
        //_isReleased = false;
        Gold = value;
        _txtGold.text = $"+ {Gold}";
    }

    #endregion
}
