using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class softbody : MonoBehaviour
{
    #region Constants
    private const float splineOffset = 0.5f;

    private float moveDuration = 0.5f;

    private bool isfinish;

    public bool IsFinish => isfinish;
    #endregion

    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;

    [SerializeField] Transform dish;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        UpdateVertices();
    }

    private void Update()
    {
        UpdateVertices();
        if(isfinish)
        {
            MoveToDish();
        }
    }
    #endregion

    #region privateMethods
    private void UpdateVertices()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector2 _vertex = points[i].localPosition;
            Vector2 _towardsCenter = (Vector2.zero - _vertex).normalized;
            float _colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            try
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch
            {
                Debug.Log("Spline points are too close to each other");
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius * splineOffset)));
            }

            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);

            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - (_newRt);

            spriteShape.spline.SetRightTangent(i, _newRt);
            spriteShape.spline.SetLeftTangent(i, _newLt);
        }
    }
    #endregion

    public void CheckMoveToDish()
    {
        print("이동 시작");
        isfinish = true;
    }

    private IEnumerator MoveOverSeconds(Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        while (elapsedTime < seconds)
        {
            rb.velocity = Vector2.zero;
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = end;  // 이동 완료 후 정확히 목표 위치에 설정
        print("이동 완료");
    }

    private void MoveToDish()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, dish.position, Time.deltaTime * 5);
    }

    public void SetFalse()
    {
        isfinish = false;
    }
}
