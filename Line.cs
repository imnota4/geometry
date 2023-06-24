using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    
    public class Line
    {

        private (Vector2, Vector2) vertices;
        private float length;
        private Vector2 midpoint;
        private float slope;
        private List<GameObject> rendererObjects;

        public Vector2 getMidpoint() { return midpoint; }

        public float getLength() { return length; }

        public (Vector2, Vector2) getVertices() { return vertices; }

        public float getSlope() { return slope; }

        public float getInverseSlope() {

            return (1f / slope); 
        
        }

        public float getPerpendicularSlope() { return -getInverseSlope(); }

        public void renderLine(float width)
        {
            GameObject rendererObject = new GameObject();
            rendererObjects.Add(rendererObject);
            LineRenderer renderer = new LineRenderer();
            renderer = rendererObject.AddComponent<LineRenderer>();
            Vector3[] positions = new Vector3[] { new Vector3(vertices.Item1.x, vertices.Item1.y, 0), new Vector3(vertices.Item2.x, vertices.Item2.y, 0) };
            renderer.GetComponent<LineRenderer>().SetPositions(positions);
            renderer.useWorldSpace = true;
            renderer.enabled = true;
            renderer.widthMultiplier = width;
        }

        public Line(Vector2 vertex1, Vector2 vertex2)
        {
            vertices.Item1 = vertex1; 
            vertices.Item2 = vertex2;
            length = Vector2.Distance(vertices.Item1, vertices.Item2);
            float pos1 = (vertex1.x + vertex2.x) / 2f;
            float pos2 = (vertex1.y + vertex2.y) / 2f;
            midpoint = new Vector2(pos1, pos2);
            slope = ((vertex1.y - vertex2.y) / (vertex1.x - vertex2.x));
            rendererObjects = new List<GameObject>();



        }

    }
}
