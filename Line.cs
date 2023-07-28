using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Geometry
{
    
    public class Line
    {

        private Point startPoint;
        private Point endPoint;
        private float length;
        private Point midpoint;
        private float slope;
        private GameObject rendererObject;

        public Point getMidpoint() { return midpoint; }

        public float getLength() { return length; }

        public (Point, Point) getVertices() { return (startPoint, endPoint); }

        public float getSlope() { return slope; }

        public float getInverseSlope() {

            return (1f / slope);
        }

        public Vector3 toVector()
        {
            return new Vector3(endPoint.x - startPoint.x, endPoint.y - startPoint.y, endPoint.z - startPoint.z);
        }

        public override string ToString() 
        { 
            return "(" + startPoint.x + ", " + startPoint.y + ", " + startPoint.z + ") | (" + endPoint.x + ", " + endPoint.y + ", " + endPoint.z + ")";
        }

        public static bool operator ==(Line obj1, Line obj2)
        {
            return ((obj1.startPoint == obj2.startPoint && obj1.endPoint == obj2.endPoint) || (obj1.startPoint == obj2.endPoint && obj1.endPoint == obj2.startPoint));
        }

        public static bool operator !=(Line obj1, Line obj2)
        {
            return ((obj1.startPoint != obj2.startPoint || obj1.endPoint != obj2.endPoint) && (obj1.startPoint != obj2.endPoint || obj1.endPoint != obj2.startPoint));
        }

        public float getPerpendicularSlope() { return -getInverseSlope(); }

        public void renderLine(float width, Color color)
        {

            if (rendererObject != null)
            {
                rendererObject.GetComponent<LineRenderer>().material.SetColor("_Color", color);
                rendererObject.GetComponent<LineRenderer>().widthMultiplier = width;
                return;

            }

            rendererObject = new GameObject();
            LineRenderer renderer = rendererObject.AddComponent<LineRenderer>();
            Vector3[] positions = new Vector3[] { new Vector3(startPoint.x, startPoint.y, 0), new Vector3(endPoint.x, endPoint.y, 0) };
            renderer.GetComponent<LineRenderer>().SetPositions(positions);
            renderer.useWorldSpace = true;
            renderer.enabled = true;
            renderer.widthMultiplier = width;
            renderer.material.SetColor("_Color", color);
        }

        public void unrender()
        {
            GameObject.Destroy(rendererObject);
        }


        // NOTE: rewrite "slope" calculations to use vector notation instead of defining the slope such that y is a function of x
        public Line(Vector3 startpoint, Vector3 endpoint)
        {
            this.startPoint = new Point(startpoint);
            this.endPoint = new Point(endpoint);
            length = Vector3.Distance(startPoint.toVector(), endPoint.toVector());
            float pos1 = (startpoint.x + endpoint.x) / 2f;
            float pos2 = (startpoint.y + endpoint.y) / 2f;
            float pos3 = (startpoint.z + endpoint.z) / 2f;
            midpoint = new Point(pos1, pos2, pos3);
            slope = ((startpoint.y - endpoint.y) / (startpoint.x - endpoint.x));


        }

        public Line(Vector2 startpoint, Vector2 endpoint)
        {
            this.startPoint = new Point(startpoint.x, startpoint.y);
            this.endPoint = new Point(endpoint.x, endpoint.y);
            length = Vector3.Distance(this.startPoint.toVector(), this.endPoint.toVector());
            float pos1 = (startpoint.x + endpoint.x) / 2f;
            float pos2 = (startpoint.y + endpoint.y) / 2f;
            midpoint = new Point(pos1, pos2, 0);
            slope = ((startpoint.y - endpoint.y) / (startpoint.x - endpoint.x));


        }

        public Line(Point startPoint, Point endPoint) :this(new Vector3(startPoint.x, startPoint.y, startPoint.z), new Vector3(endPoint.x, endPoint.y, endPoint.z)) { }

    }
}
