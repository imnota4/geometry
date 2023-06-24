using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geometry;
using UnityEngine.UIElements;

public class Polygon 
{
    private List<Line> edges;
    List<Vector2> vertices;

    public List<Line> getEdges() { return edges; }

    public List<Vector2> getVertices() {

        return vertices;
    
    }

    public Polygon(List<Vector2> vertices)
    {

        edges = new List<Line> ();
        this.vertices = vertices;
        if (vertices.Count == 0) {  return; }

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
