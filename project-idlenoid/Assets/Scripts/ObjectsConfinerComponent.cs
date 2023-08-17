using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsConfinerComponent : MonoBehaviour
{
    [Header("Configuration fields")]
    [SerializeField]
    Sprite _sprite;
    [SerializeField]
    int _confinerLayer;
    [SerializeField]
    float horizontalOffset = 0.5f;
    [SerializeField]
    float verticalOffset = 0.75f;
    void Start()
    {
        PutColliders();
    }

    private void PutColliders()
    {
        GameObject left = new GameObject("LeftCollider", typeof(BoxCollider2D));
        left.AddComponent<SpriteRenderer>().sprite = _sprite;
        GameObject right = new GameObject("RightCollider", typeof(BoxCollider2D));
        right.AddComponent<SpriteRenderer>().sprite = _sprite;
        GameObject top = new GameObject("TopCollider", typeof(BoxCollider2D));
        top.AddComponent<SpriteRenderer>().sprite = _sprite;

        GameObject bottom = new GameObject("BottomCollider", typeof(BoxCollider2D));
        bottom.AddComponent<SpriteRenderer>().sprite = _sprite;


        left.transform.SetParent(transform);
        right.transform.SetParent(transform);
        top.transform.SetParent(transform);
        bottom.transform.SetParent(transform);

        left.layer = _confinerLayer;
        right.layer = _confinerLayer;
        top.layer = _confinerLayer;
        bottom.layer = _confinerLayer;

        Vector2 leftBottomCorner = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector2 rightTopCorner = Camera.main.ViewportToWorldPoint(Vector3.one);

        left.transform.position = new Vector2(
            leftBottomCorner.x - horizontalOffset,
            Camera.main.transform.position.y
            );
        right.transform.position = new Vector2(
            rightTopCorner.x + horizontalOffset,
            Camera.main.transform.position.y
            );
        top.transform.position = new Vector2(
            Camera.main.transform.position.x,
            rightTopCorner.y + verticalOffset
            );
        bottom.transform.position = new Vector2(
            Camera.main.transform.position.x,
            leftBottomCorner.y - verticalOffset
            );

        left.transform.localScale = new Vector3(1, Mathf.Abs(rightTopCorner.y - leftBottomCorner.y));
        right.transform.localScale = new Vector3(1, Mathf.Abs(rightTopCorner.y - leftBottomCorner.y));
        top.transform.localScale = new Vector3(Mathf.Abs(rightTopCorner.x - leftBottomCorner.x), 1);
        bottom.transform.localScale = new Vector3(Mathf.Abs(rightTopCorner.x - leftBottomCorner.x), 1);
    }
}
