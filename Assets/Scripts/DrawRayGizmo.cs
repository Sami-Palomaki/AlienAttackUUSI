using UnityEngine;

public class DrawRayGizmo : MonoBehaviour
{
    public float rayLength = 5.0f; // Säteen pituus

    void OnDrawGizmos()
    {
        // Asetetaan Gizmo-värin väri (tässä punainen)
        Gizmos.color = Color.red;

        // Päätellään säteen alkupiste
        Vector3 rayStart = transform.position;

        // Päätellään säteen loppupiste säteen suunnan ja pituuden perusteella
        Vector3 rayEnd = transform.position + transform.forward * rayLength;

        // Piirretään Gizmo-säde alkupisteestä loppupisteeseen
        Gizmos.DrawLine(rayStart, rayEnd);
    }
}
