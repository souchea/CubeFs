namespace Rubiks

module Cube = 
    type Face = 
    | U
    | R
    | F
    | D
    | L
    | B
           
    type Color = 
        | Blue
        | Red
        | Green
        | Orange 
        | Yellow
        | White 

    type PartInfo = (Color * Face)

    type CubePart = 
        | Center of (PartInfo)
        | Edge of (PartInfo * PartInfo)
        | Corner of (PartInfo * PartInfo * PartInfo)

    type Cube = CubePart list
