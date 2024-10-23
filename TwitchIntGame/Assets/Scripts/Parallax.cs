using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    Vector2 startPos;
    float startZ;

    // => means the value will calculate and change on every frame
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startPos;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // ? in setter means take the first following value if the statement is correct, otherwise take the second
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // parallax object moves faster the further it is from the target
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    void Start()
    {
        startPos = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // parallax effect changes based on the target's movement multiplied by a value
        Vector2 newPos = startPos + camMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
