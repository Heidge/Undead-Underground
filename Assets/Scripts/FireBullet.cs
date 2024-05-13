using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    public InputActionProperty fireAction;

    public int damage = 50;
    private bool cooldown = true;

    public LayerMask mask;
    private RaycastHit hit;
    public AudioSource gunSound;
    public GameObject bulletHole;

    void Update()
    {
        float fire = fireAction.action.ReadValue<float>();

        if (cooldown && fire > 0.8) {
            //Fire
            cooldown = false;
            gunSound.Play();

            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, mask)) {
                CreateBulletImpact(hit);
                if (hit.collider.tag == "Zombie")
                {
                    Zombie zombie = hit.collider.gameObject.GetComponent<Zombie>();
                    if (zombie != null)
                        zombie.TakeDamage(damage);
                    else
                        Debug.LogError("Zombie script not found on the zombie GameObject.");
                }
            }
        }

        if (fire < 0.2)
            cooldown = true;
    }

    void CreateBulletImpact(RaycastHit hit) {
        GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
