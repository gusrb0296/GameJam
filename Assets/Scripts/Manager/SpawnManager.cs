using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Ingredients;

    public int[] values = new int[16] {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};

    public GameObject[] rangeObject;
    BoxCollider2D[] rangeCollider = new BoxCollider2D[16];

    private void Awake()
    {
        for (int i = 0; i < values.Length; i++)
        {
            rangeCollider[i] = rangeObject[i].GetComponent<BoxCollider2D>();
        }
        
    }

    private void Start()
    {
        GameManager.Instance.GetIngredient.AddListener(SpawnIngredient);

        Shuffle(values);

        for (int i = 0; i < values.Length; i++)
        {
            SpawnIngredient(i, i);
        }
    } 

    void Shuffle(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    Vector3 Return_RandomPosition(int index)
    {
        Vector3 originPosition = rangeObject[index].transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider[index].bounds.size.x;
        float range_Z = rangeCollider[index].bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }


    public void SpawnIngredient(int index, int pivotIndex)
    {
        GameObject go = Instantiate(Ingredients[values[index]], Return_RandomPosition(pivotIndex), Quaternion.identity);
        go.GetComponentInChildren<Stickable>().pivotIndex = pivotIndex;
    }
}
