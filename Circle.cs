using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geometry;
using System;

namespace Geometry
{
    public class Circle
    {

        private List<Line> edges; // Circles do not have edges, but true circles do not exist in the programming world. 
        private Vector2 center;
        private float radius;

        public Vector2 getCenter() { return center; }

        public float getRadius() { return radius; }

        public bool isPointWithin(Vector2 point)
        {
            if (Vector2.Distance(point, center) < radius) { return true; } return false;
        }

        public void setSteps(float steps)
        {

            edges.Clear();
            float prevAngle = 0;
            for (float i = (360 / steps); i < 360; i = i + (360 / steps))
            {
                Vector2 vertex1 = new Vector2(center.x + this.radius * Mathf.Sin(prevAngle *(Mathf.PI / 180)), center.y + this.radius * Mathf.Cos(prevAngle * (Mathf.PI / 180)));
                Vector2 vertex2 = new Vector2(center.x + this.radius * Mathf.Sin(i * (Mathf.PI / 180)), center.y + this.radius * Mathf.Cos(i * (Mathf.PI / 180)));
                Line line = new Line(vertex1, vertex2);
                edges.Add(line);
                prevAngle = i;

            }

            Vector2 finalVertex1 = new Vector2(center.x + this.radius * Mathf.Sin(prevAngle * (Mathf.PI / 180)), center.y + this.radius * Mathf.Cos(prevAngle * (Mathf.PI / 180)));
            Vector2 finalVertex2 = new Vector2(center.x + this.radius * Mathf.Sin(360 * (Mathf.PI / 180)), center.y + this.radius * Mathf.Cos(360 * (Mathf.PI / 180)));
            Line finalLine = new Line(finalVertex1, finalVertex2);
            edges.Add(finalLine);
        }
        public void render(float lineWidth, Color color)
        {
            foreach (Line edge in edges)
            {
                edge.renderLine(lineWidth, color);
            }
        }

        public void unrender()
        {
            foreach (Line edge in edges)
            {
                edge.unrender();
            }
        }

        // Construct a circle based on the location of it's center and the radius of the circle
        public Circle(Vector2 center, float radius)
        {
            this.edges = new List<Line>();
            this.radius = radius;
            this.center = center;
            this.setSteps(100);
        }


    }
}
