using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Geometry;

namespace Geometry
{
    public class Triangle : Polygon
    {
        private Vector2 circumcenter;
        private Circle circumcircle;
        public Vector2 getCircumcenter()
        {
            return circumcenter;
        }

        public override string ToString()
        {
            return getVertices()[0] + ", " + getVertices()[1] + ", " + getVertices()[2];
        }

        public bool containsVertice(Vector2 point)
        {

            return point.Equals(getVertices()[0]) || point.Equals(getVertices()[1]) || point.Equals(getVertices()[2]);

        }

        public bool sharesEdge(Triangle triangle)
        {
            // Check if any of the edges in triangle1 match any of the edges in triangle2
            return
                EdgesMatch(getEdges()[0], triangle) ||
                EdgesMatch(getEdges()[1], triangle) ||
                EdgesMatch(getEdges()[2], triangle);
        }

        private bool EdgesMatch(Line edge1, Triangle triangle)
        {
            return
                (edge1 == triangle.getEdges()[0]) ||
                (edge1 == triangle.getEdges()[1]) ||
                (edge1 == triangle.getEdges()[2]);
        }


        public Vector2 getCentroid()
        {
            float centroidX = (getVertices()[0].x + getVertices()[1].x + getVertices()[2].x) / 3f;
            float centroidY = (getVertices()[0].y + getVertices()[1].y + getVertices()[2].y) / 3f;

            return new Vector2(centroidX, centroidY);
        }
        public Circle getCircumcircle()
        {
            return circumcircle;
        }
        public Triangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3) : base(new List<Vector2> { vertex1, vertex2, vertex3 })
        {
            circumcenter = CircumCircle.Generate(getEdges()[0].getVertices().Item1, getEdges()[1].getVertices().Item1, getEdges()[2].getVertices().Item1);
            circumcircle = new Circle(this.getCircumcenter(), Vector2.Distance(this.getCircumcenter(), this.getVertices()[0]));

        }
    }

}
