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
        public Vector2 getCircumcenter()
        {
            return circumcenter;
        }
        public Triangle(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3) : base(new List<Vector2> { vertex1, vertex2, vertex3 })
        {
            circumcenter = CircumCircle.Generate(getEdges()[0].getVertices().Item1, getEdges()[1].getVertices().Item1, getEdges()[2].getVertices().Item1);

        }
    }

}
