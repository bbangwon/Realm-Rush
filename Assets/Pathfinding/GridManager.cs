using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    Node node;

    private void Start()
    {
        Debug.Log(node.coordinates);
        Debug.Log(node.isWalkable);
    }
}
