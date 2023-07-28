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
        List<Point> vertices;

        public List<Line> getEdges() { return edges; }

        public List<Point> getVertices()
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

        public bool containsVertice(Point point)
        {

            foreach (Point point2 in vertices)
            {
                if (point.Equals(point2)) { return true; }
            }
            return false; 
        }

        public float getAngle(Line edge1, Line edge2)
        {

            // if edges don't share a vertice, return
            if (edge1.getVertices().Item1 != edge2.getVertices().Item1 && edge1.getVertices().Item1!= edge2.getVertices().Item2 && edge1.getVertices().Item2 != edge2.getVertices().Item1 && edge1.getVertices().Item2 != edge2.getVertices().Item2)
            {
                return 0;
            }

            if (edge1.getVertices().Item1 == edge2.getVertices().Item1)
            {
                Vector2 vector1 = edge1.getVertices().Item2.toVector() - edge1.getVertices().Item1.toVector();
                Vector2 vector2 = edge2.getVertices().Item2.toVector() - edge2.getVertices().Item1.toVector();
                return Vector2.Angle(vector1, vector2);
            }

            if (edge1.getVertices().Item1 == edge2.getVertices().Item2)
            {
                Vector2 vector1 = edge1.getVertices().Item2.toVector() - edge1.getVertices().Item1.toVector();
                Vector2 vector2 = edge2.getVertices().Item1.toVector() - edge2.getVertices().Item2.toVector();
                return Vector2.Angle(vector1, vector2);
            }

            if (edge1.getVertices().Item2 == edge2.getVertices().Item1)
            {
                Vector2 vector1 = edge1.getVertices().Item1.toVector() - edge1.getVertices().Item2.toVector();
                Vector2 vector2 = edge2.getVertices().Item2.toVector() - edge2.getVertices().Item1.toVector();
                return Vector2.Angle(vector1, vector2);
            }

            if (edge1.getVertices().Item2 == edge2.getVertices().Item2)
            {
                Vector2 vector1 = edge1.getVertices().Item1.toVector() - edge1.getVertices().Item2.toVector();
                Vector2 vector2 = edge2.getVertices().Item1.toVector() - edge2.getVertices().Item2.toVector();
                return Vector2.Angle(vector1, vector2);
            }

            return 0;
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

        public Polygon(List<Point> vertices)
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

        public Polygon(List<Vector2> vertices) 
        {
            List<Point> trueVertices = new List<Point>();
            foreach (Vector2 vertice in vertices)
            {
                trueVertices.Add(new Point(vertice));
            }

            edges = new List<Line>();
            this.vertices = trueVertices;
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

        public Polygon(List<Line>edges)
        {
           this.edges = edges;
        }


    }
}

