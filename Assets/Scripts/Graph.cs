using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField] private Transform pointPrefab;

    [SerializeField, Range(10, 200)] private int resolution = 50;

    [SerializeField]
    private FunctionLibrary.FunctionName functionName = FunctionLibrary.FunctionName.Wave;

    private List<Transform> points;

    void Awake() {
        points = new List<Transform>();
        float step = 2f / resolution;
        var scale = Vector3.one * step;
        for (int i = 0; i < resolution * resolution; i++) {
            Transform point = Instantiate(pointPrefab, transform);
            point.localScale = scale;
            points.Add(point);
        }
    }

    // Start is called before the first frame update
    void Start() {
        Update();
    }

    // Update is called once per frame
    void Update() {
        var function = FunctionLibrary.GetFunction(functionName);
        var pos = Vector3.zero;
        float step = 2f / resolution;
        for (int i = 0; i < points.Count; i++) {
            pos.x = (i % resolution + 0.5f) * step - 1f;
            pos.z = (i / resolution + 0.5f) * step - 1f;
            points[i].localPosition = function(pos, Time.time);
        }
    }
}