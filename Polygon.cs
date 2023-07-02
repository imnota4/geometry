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

