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
        public Vector2 getCircumcenter()
        {
            return CircumCircle.Generate(getEdges()[0].getVertices().Item1, getEdges()[1].getVertices().Item1, getEdges()[2].getVertices().Item1);
        }

        public override string ToString()
        {
            return getVertices()[0] + ", " + getVertices()[1] + ", " + getVertices()[2];
        }

        public Vector2 getCentroid()
        {
            float centroidX = (getVertices()[0].x + getVertices()[1].x + getVertices()[2].x) / 3f;
            float centroidY = (getVertices()[0].y + getVertices()[1].y + getVertices()[2].y) / 3f;

            return new Vector2(centroidX, centroidY);
        }

        public Circle getCircumcircle()
        {
            return new Circle(this.getCircumcenter(), Vector2.Distance(this.getCircumcenter(), this.getVertices()[0]));
        }
        public Triangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3) : base(new List<Vector2> { vertex1, vertex2, vertex3 })
        {

        }
    }

}
