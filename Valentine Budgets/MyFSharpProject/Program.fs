// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
// Define Cuisine discriminated union for restaurant options
type Cuisine =
    | Korean
    | Turkish

// Define MovieType discriminated union for different movie experiences
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define Activity discriminated union for different activities
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float // (kilometres, fuel charge per kilometre)

// Calculate the budget for each activity
let calculateBudget (activity: Activity) =
    match activity with
    | BoardGame -> 0  // Playing a board game costs 0 CAD
    | Chill -> 0      // Chilling out costs 0 CAD
    | Movie movieType ->
        match movieType with
        | Regular -> 12         // Regular movie costs 12 CAD per head
        | IMAX -> 17           // IMAX movie costs 17 CAD per head
        | DBOX -> 20           // DBOX movie costs 20 CAD per head
        | RegularWithSnacks -> 12 + 5  // Regular movie with snacks costs 12 + 5 CAD
        | IMAXWithSnacks -> 17 + 5      // IMAX with snacks costs 17 + 5 CAD
        | DBOXWithSnacks -> 20 + 5      // DBOX with snacks costs 20 + 5 CAD
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70          // Korean restaurant costs 70 CAD per couple
        | Turkish -> 65         // Turkish restaurant costs 65 CAD per couple
    | LongDrive (kilometres, fuelPerKilometre) ->
        int (float kilometres * fuelPerKilometre)  // Long drive cost = kilometres * fuel rate

// Main function to test and print the budget for each activity
[<EntryPoint>]
let main argv =
    // List of test activities
    let activities = [
        BoardGame
        Chill
        Movie Regular
        Movie IMAX
        Movie DBOX
        Movie RegularWithSnacks
        Movie IMAXWithSnacks
        Movie DBOXWithSnacks
        Restaurant Korean
        Restaurant Turkish
        LongDrive (150, 0.15)  // Example of a long drive (150 km, 0.15 CAD per km)
    ]

    // Print the budget for each activity
    activities
    |> List.iter (fun activity ->
        printfn "Activity: %A, Budget: %d CAD" activity (calculateBudget activity)
    )

    0 // Exit code
