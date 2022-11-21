using Assets.CodeBase.Infrasctructure;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject _projectilePrefab;

    [SerializeField] private Transform _gunPoint;
    [SerializeField] private LayerMask _ignoredLayers;

    private AllServices _services = AllServices.Instance;

    private InputService _inputService;
    private float _maxRayDistance = 1000f;

    private void Start()
    {
        _inputService = _services.GetService<InputService>();
    }

    private void Update()
    {
        if (_inputService.GetShootButton())
        {
            Ray cameraRay = GetMouseRay();

            if (Physics.Raycast(cameraRay, out RaycastHit hit, _maxRayDistance, ~_ignoredLayers) == true)
            {
                Vector3 direction = (hit.point - _gunPoint.position).normalized;
                RealeseProjectile(hit, direction);
            }
        }
    }

    private void RealeseProjectile(RaycastHit hit, Vector3 direction)
    {
        GameObject projectile = GameObject.Instantiate(_projectilePrefab, _gunPoint.position, Quaternion.identity);
        projectile.transform.LookAt(hit.point);
        projectile.GetComponent<Projectile>().Direction = direction;
    }

    private Ray GetMouseRay() 
        => Camera.main.ScreenPointToRay(_inputService.MousePosition);
}
