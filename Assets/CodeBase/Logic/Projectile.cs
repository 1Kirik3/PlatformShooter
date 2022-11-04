using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public Vector3 Direction;
    public LayerMask IgnoredLayers;

    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _distanceCheck = 0.15f;
    [SerializeField] private float _speed;

    private void Update()
    {
        Ray projectileRay = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(projectileRay, out RaycastHit hit, _distanceCheck, ~IgnoredLayers) == true)
        {
            DestroyProjectile(hit);
        }
        MoveProjectile(Direction);

    }

    private void MoveProjectile(Vector3 direction) 
        => this.transform.position += direction * _speed * Time.deltaTime;

    private void DestroyProjectile(RaycastHit hit)
    {
        GameObject.Instantiate(_particlePrefab, hit.point, Quaternion.LookRotation(hit.normal));
        GameObject.Destroy(gameObject);
    }
}
