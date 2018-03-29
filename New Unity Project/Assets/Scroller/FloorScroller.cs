using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorScroller : MonoBehaviour
{
	[SerializeField]
	private GameObject floor;
	[SerializeField]
	private int count;
	[SerializeField]
	private Vector3 interval;
	[SerializeField]
	private Vector3 scrollSpeed;
	[SerializeField]
	private Vector3 origin;

	private List<GameObject> floors;
	private int frontMostIndex;
	private Vector3 movement;

	void Start()
	{
		floors = Enumerable.Range(0, count)
			.Select(_ => GameObject.Instantiate(floor))
			.ToList();
		frontMostIndex = 0;
		movement = Vector3.zero;

		ArrangeFloors();
	}

	void FixedUpdate()
	{
		// This causes suspicient jumping of objects
		if (movement.magnitude > interval.magnitude) {
			movement = Vector3.zero;
			frontMostIndex = (frontMostIndex + 1) % floors.Count;
		} else {
			movement += Time.deltaTime * scrollSpeed;
		}

		ArrangeFloors();
	}

	void ArrangeFloors()
	{
		for (var i = 0; i < floors.Count; i++)
		{
			floor = floors[(i + frontMostIndex) % floors.Count];
			floor.transform.position = origin + interval * i + movement;
		}
	}
}
