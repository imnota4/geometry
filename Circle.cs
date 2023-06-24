using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geometry;
using UnityEngine.SocialPlatforms.GameCenter;


namespace Geometry
{
    public class Circle
    {
        private Vector2 center;
        private float radius;

        public Vector2 getCenter() { return center; }

        public float getRadius() { return radius; }
        public Circle(Vector2 center, float radius)
        {
            this.radius = radius;
            this.center = center;
        }

    }
}
