namespace ProgramTest

module ProgramTest1 = 
    open Rubiks.Cube


    let MoveCubePart (info : PartInfo) (face: Face) =
        match info with 
            | (color, U) | (color, D) when face = U -> (color, U)
            | (color, U) | (color, D) when face = F -> (color, R)
            | (color, U) | (color, D) when face = R -> (color, B)
            | (color, U) | (color, D) when face = B -> (color, L)
            | (color, U) | (color, D) when face = L -> (color, F)
            | (color, U) | (color, D) when face = D -> (color, U)

            | (color, F) | (color, B) when face = U -> (color, U)
            | (color, F) | (color, B) when face = F -> (color, R)
            | (color, F) | (color, B) when face = R -> (color, B)
            | (color, F) | (color, B) when face = B -> (color, L)
            | (color, F) | (color, B) when face = L -> (color, F)
            | (color, F) | (color, B) when face = D -> (color, U)

            | (color, R) | (color, R) when face = U -> (color, U)
            | (color, R) | (color, R) when face = F -> (color, R)
            | (color, R) | (color, R) when face = R -> (color, B)
            | (color, R) | (color, R) when face = B -> (color, L)
            | (color, R) | (color, R) when face = L -> (color, F)
            | (color, R) | (color, R) when face = D -> (color, U)
    

    let ChangeCube (face: Face) (cubePart : CubePart) = 
        match cubePart with
            | Center(part)          -> Center(MoveCubePart part face)
            | Edge(part1, part2)    -> Edge(MoveCubePart part1 face, MoveCubePart part2 face)
            | Corner(part1, part2, part3) -> Corner(MoveCubePart part1 face, MoveCubePart part2 face, MoveCubePart part3 face)


    let MoveLayer (face : Face) (deep : int) (cube : Cube) = 
        cube |> (List.map (ChangeCube face))

    [<EntryPoint>]
    let main argv = 

        let cube222 = [ Corner ((White, U), (Blue, F), (Red, L)); 
                        Corner ((White, U), (Orange, R), (Blue, F))
                        Corner ((White, U), (Blue, F), (Red, L)); 
                        Corner ((White, U), (Orange, R), (Blue, F))
                        Corner ((White, U), (Blue, F), (Red, L)); 
                        Corner ((White, U), (Orange, R), (Blue, F))
                        Corner ((White, U), (Blue, F), (Red, L)); 
                        Corner ((White, U), (Orange, R), (Blue, F))]

        let newCube = cube222 |> MoveLayer U 1
        0 

    