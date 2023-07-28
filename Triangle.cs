using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Geometry;

namespace Geometry
{
    public class Triangle : Polygon
    {
        public Point getCircumcenter()
        {
            return new Point(CircumCircle.Generate(getEdges()[0].getVertices().Item1.toVector(), getEdges()[1].getVertices().Item1.toVector(), getEdges()[2].getVertices().Item1.toVector()));
        }

        public override string ToString()
        {
            return getVertices()[0] + ", " + getVertices()[1] + ", " + getVertices()[2];
        }

        public Point getCentroid()
        {
            float centroidX = (getVertices()[0].x + getVertices()[1].x + getVertices()[2].x) / 3f;
            float centroidY = (getVertices()[0].y + getVertices()[1].y + getVertices()[2].y) / 3f;

            return new Point(centroidX, centroidY);
        }

        public Circle getCircumcircle()
        {
            return new Circle(this.getCircumcenter(), Vector2.Distance(this.getCircumcenter().toVector(), this.getVertices()[0].toVector()));
        }
        public Triangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3) : base(new List<Vector2> { vertex1, vertex2, vertex3 })
        {

        }
        public Triangle(Point vertex1, Point vertex2, Point vertex3) : base(new List<Point> { vertex1, vertex2, vertex3 })
        {

        }
    }

}
