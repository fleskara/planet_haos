using UnityEngine;
using Random = UnityEngine.Random;
public class ProjectileSpawn : MonoBehaviour
{
    Vector3 start_position;
    Vector3 sphere = new Vector3(0, 0, 0);
    float velocity;
    public GameObject projectile;
    private GameObject spawned;
    public AudioClip spawn_sound;
    public AudioClip collide_sound;
    void Start()
    {
        spawnProjectile();
    }

    void Update()
    {
        if (spawned != null)
        {
            spawned.transform.position -= start_position.normalized * velocity * Time.deltaTime;
            if (Vector3.Distance(spawned.transform.position, sphere) <= 15f)
            {
                Destroy(spawned, 0.05f);
                AudioSource.PlayClipAtPoint(collide_sound, spawned.transform.position);
                spawnProjectile();
            }
        }
    }

    void spawnProjectile()
    {
        start_position = Random.onUnitSphere * ((float)Random.Range(35, 40));
        velocity = Random.Range(10f, 20f);
        spawned = Instantiate(projectile, start_position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(spawn_sound, sphere);
    }

}
