using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();

    [SerializeField]
    [Range(0f, 5f)]
    float speed = 1f;    

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    
    void FindPath()
    {
        path.Clear();

        //잘못된 방법
        //GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        Transform parent = GameObject.FindGameObjectWithTag("Path").transform;

        foreach (Transform child in parent)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
                path.Add(waypoint);
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
