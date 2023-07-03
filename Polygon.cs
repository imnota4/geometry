using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geometry;
using UnityEngine.UIElements;
using System.Drawing;
using System.Linq;

namespace Geometry
{
    public class Polygon
    {
        private List<Line> edges;
        List<Vector2> vertices;

        public List<Line> getEdges() { return edges; }

        public List<Vector2> getVertices()
        {

            return vertices;

        }

        public bool sharesEdge(Polygon polygon)
        {
            foreach (Line edge in this.edges)
            {
                foreach (Line edge2 in polygon.edges)
                {
                    if (edge == edge2) { return true; }
                }
            }
            return false;
        }

        public bool containsVertice(Vector2 point)
        {

            foreach (Vector2 point2 in vertices)
            {
                if (point.Equals(point2)) { return true; }
            }
            return false; 
        }

        public float getAngle(Line edge1, Line edge2)
        {
            return 0; // to be implemented
        }

        public void render(float lineWidth, UnityEngine.Color color)
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

        public Polygon(List<Vector2> vertices)
        {

            edges = new List<Line>();
            this.vertices = vertices;
            if (vertices.Count == 0) { return; }

            for (int i = 0; i < vertices.Count; i++)
            {
                if (i == vertices.Count - 1)
                {
                    edges.Add(new Line(vertices[i], vertices[0]));
                    return;
                }
                edges.Add(new Line(vertices[i], vertices[i + 1]));
            }
        }


    }
}

