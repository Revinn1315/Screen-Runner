using UnityEngine;

// Guide for Parallex Effect = https://www.youtube.com/watch?v=tMXgLBwtsvI
public class ParallexEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    //Starting position of Parallex game object
    Vector2 startingPosition;

    //Start z value of the Parallex game object
    float startingZ;

    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallexFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallexFactor;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
