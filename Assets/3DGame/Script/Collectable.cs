using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int value = 10;
    [SerializeField] Bounds teleportBounds;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(teleportBounds.center, teleportBounds.size);

    }
    public int GetValue() { return value; }
    
    public void Teleport()
    {
        float rx = Random.Range(teleportBounds.min.x, teleportBounds.max.x);
        float ry = Random.Range(teleportBounds.min.y, teleportBounds.max.y);
        float rz = Random.Range(teleportBounds.min.z, teleportBounds.max.z);
        

        Vector3 randomPoint = new(rx, ry, rz);
        transform.position = randomPoint;

    }
        
    
}
