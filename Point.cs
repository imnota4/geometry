using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public class Point
    {

        private GameObject pointObject;
        public float x, y, z;

        public void render(PrimitiveType shape)
        {
            pointObject = GameObject.CreatePrimitive(shape);
            pointObject.transform.localPosition = new Vector3(x, y, z);
        }

        public Vector3 toVector()
        {
            return new Vector3(x, y, z);
        }
        public Point(Vector3 point)
        {
            this.x = point.x;
            this.y = point.y;
            this.z = point.z;
        }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point(float x, float y) : this(new Vector3(x, y, 0))
        {

        }

        public Point(Vector2 point) : this(new Vector3(point.x, point.y, 0))
        {

        }

    }
}

