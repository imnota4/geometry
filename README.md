# geometry

## About
A simple library that contains data structures for represeting different shapes. The goal is this library and by extension these data structures, will provide a very minimal and simplistic way to implement geometric math and operations that allows a user flexibility in their own code without making too many assumptions or limitations. 

*This library is a fairly new project as of 7/3/2023 and the structure of certain classes may change over time*

## How to use

Using this library is fairly straightforward. There exists two classes that define the primary attributes of all shapes, and every other class's implementation is designed around these two classes. These classes are the **Line** class and the **Polygon** class.

The Line class is exactly what you'd think, it defines the traits of a straight line between two vertices. It is used to define the edges of shapes as well as offering additional functionality like rendering functions and math operations. Check the *docs* folder for further documentation

The Polygon class aptly named, is used to represent polygons. It defines the barebone functionality that all polygonal shapes have, such as what the vertices and edges are, as well as a function for rendering all the edges of the polygon. Check the *docs* folder for further documentation

Additional classes such as the **Triangle** and **Circle** class are also defined within this library and provide useful ways to represent geometric data in a minimalist format. All classes and the full list of their functionality is in the documentation found in the *docs* folder




