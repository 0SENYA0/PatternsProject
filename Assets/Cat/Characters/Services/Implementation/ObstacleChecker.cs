using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Services.Implementation
{
	public class ObstacleChecker : MonoBehaviour, IObstacleChecker
	{
		[SerializeField] private LayerMask _obstacleMask;
		[Range(0, 50)] [SerializeField] private float _radius;
		[SerializeField] private Vector3 _offset;
		[SerializeField] private Color _colorToGizmos;
		[SerializeField] private GizmosTypeSphere _gizmosTypeSphere;

		private readonly Collider[] _colliders = new Collider[1];

		public bool IsCollided { get; private set; }

		private void Update() =>
			IsCollided = Physics.OverlapSphereNonAlloc(transform.position + _offset, _radius, _colliders, _obstacleMask.value) >= 1;

		private void OnDrawGizmos()
		{
			Gizmos.color = _colorToGizmos;

			switch (_gizmosTypeSphere)
			{
				case GizmosTypeSphere.Default:
					Gizmos.DrawSphere(transform.position + _offset, _radius);
					break;

				case GizmosTypeSphere.Wire:
					Gizmos.DrawWireSphere(transform.position + _offset, _radius);
					break;

				default:
					Debug.LogError("Unknown gizmos type");
					break;
			}
		}

		private enum GizmosTypeSphere
		{
			Unknown = 0,
			Wire = 1,
			Default = 2
		}
	}
}