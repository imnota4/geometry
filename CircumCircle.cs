using System;
using System.Collections.Generic;
using UnityEngine;
using Geometry;

// Thank you to Aanya Jindal at geeksforgeeks.org for freely distribution this code online

namespace Geometry {
    public static class CircumCircle
    {
        // C# program to find the CIRCUMCENTER of a
        // triangle

        // This pair is used to store the X and Y
        // coordinate of a point respectively

        // Function to find the line given two points
        private static void lineFromPoints(List<double> P, List<double> Q,
                       ref double a, ref double b, ref double c)
        {
            a = Q[1] - P[1];
            b = P[0] - Q[0];
            c = a * (P[0]) + b * (P[1]);
        }

        // Function which converts the input line to its
        // perpendicular bisector. It also inputs the points
        // whose mid-point lies on the bisector
        private static void perpendicularBisectorFromLine(
            List<double> P, List<double> Q, ref double a,
            ref double b, ref double c)
        {
            List<double> mid_point = new List<double>();
            mid_point.Add((P[0] + Q[0]) / 2);

            mid_point.Add((P[1] + Q[1]) / 2);

            // c = -bx + ay
            c = -b * (mid_point[0]) + a * (mid_point[1]);

            double temp = a;
            a = -b;
            b = temp;
        }

        // Returns the intersection point of two lines
        private static List<double> lineLineIntersection(double a1, double b1, double c1,
                             double a2, double b2, double c2)
        {
            List<double> ans = new List<double>();
            double determinant = a1 * b2 - a2 * b1;
            if (determinant == 0)
            {
                // The lines are parallel. This is simplified
                // by returning a pair of FLT_MAX
                ans.Add(double.MaxValue);
                ans.Add(double.MaxValue);
            }

            else
            {
                double x = (b2 * c1 - b1 * c2) / determinant;
                double y = (a1 * c2 - a2 * c1) / determinant;
                ans.Add(x);
                ans.Add(y);
            }
            return ans;
        }

        private static Vector2 findCircumCenter(List<double> P,
                                            List<double> Q,
                                            List<double> R)
        {
            // Line PQ is represented as ax + by = c
            double a = 0;
            double b = 0;
            double c = 0;
            lineFromPoints(P, Q, ref a, ref b, ref c);

            // Line QR is represented as ex + fy = g
            double e = 0;
            double f = 0;
            double g = 0;
            lineFromPoints(Q, R, ref e, ref f, ref g);

            // Converting lines PQ and QR to perpendicular
            // vbisectors. After this, L = ax + by = c
            // M = ex + fy = g
            perpendicularBisectorFromLine(P, Q, ref a, ref b,
                                          ref c);
            perpendicularBisectorFromLine(Q, R, ref e, ref f,
                                          ref g);

            // The point of intersection of L and M gives
            // the circumcenter
            List<double> circumcenter = lineLineIntersection(a, b, c, e, f, g);

            if (circumcenter[0] == float.MaxValue
                && circumcenter[1] == float.MaxValue)
            {
                Console.Write("The two perpendicular bisectors "
                              + "found come parallel");
                Console.Write("\n");
                Console.Write(
                    "Thus, the given points do not form "
                    + "a triangle and are collinear");
                Console.Write("\n");
                return new Vector2(-100, -100);
            }

            else
            {
                Console.Write(
                    "The circumcenter of the triangle PQR is: ");
                Console.Write("(");
                Console.Write(circumcenter[0]);
                Console.Write(", ");
                Console.Write(circumcenter[1]);
                Console.Write(")");
                Console.Write("\n");
                return new Vector2((float)circumcenter[0], (float)circumcenter[1]);
            }
        }

        // Driver code.
        public static Vector2 Generate(Vector2 vertex1, Vector2 vertex2, Vector2 vertex3)
        {

            List<double> P = new List<double>();
            P.Add(vertex1.x);
            P.Add(vertex1.y);
            List<double> Q = new List<double>();
            Q.Add(vertex2.x);
            Q.Add(vertex2.y);
            List<double> R = new List<double>();
            R.Add(vertex3.x);
            R.Add(vertex3.y);

            return findCircumCenter(P, Q, R);
        }
    }
}
