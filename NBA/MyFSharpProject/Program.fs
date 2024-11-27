// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

// Define records for Coach, Stats, and Team
type Coach = { Name: string; FormerPlayer: bool }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }

// Create list of 5 teams
let teams =
    [
        { Name = "Atlanta Hawks"; Coach = { Name = "Quin Snyder"; FormerPlayer = true }; Stats = { Wins = 2927; Losses = 3010 } }
        { Name = "Boston Celtics"; Coach = { Name = "Joe Mazzulla"; FormerPlayer = true }; Stats = { Wins = 3634; Losses = 2480 } }
        { Name = "Brooklyn Nets"; Coach = { Name = "Jordi Fernandez"; FormerPlayer = false }; Stats = { Wins = 1654; Losses = 2214 } }
        { Name = "Charlotte Hornets"; Coach = { Name = "Charles Lee"; FormerPlayer = true }; Stats = { Wins = 1174; Losses = 1539 } }
        { Name = "Chicago Bulls"; Coach = { Name = "Billy Donovan"; FormerPlayer = true }; Stats = { Wins = 2383; Losses = 2297 } }
    ]

// Filter the list of successful teams
let successfulTeams = teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Calculate success percentage using map
let teamSuccessPercentages =
    teams
    |> List.map (fun team ->
        let percentage = float team.Stats.Wins / float (team.Stats.Wins + team.Stats.Losses) * 100.0
        team, percentage
    )

// Print all team details
printfn "All Teams Information:"
teams 
|> List.iter (fun team ->
    printfn "Team: %s" team.Name
    printfn "  Coach: %s (Former Player: %b)" team.Coach.Name team.Coach.FormerPlayer
    printfn "  Wins: %d, Losses: %d" team.Stats.Wins team.Stats.Losses
    let percentage = float team.Stats.Wins / float (team.Stats.Wins + team.Stats.Losses) * 100.0
    printfn "  Success Percentage: %.2f%%\n" percentage
)

// Print successful teams
printfn "Successful Teams:"
successfulTeams |> List.iter (fun team -> printfn "%s" team.Name)

// Print success percentages
printfn "\nTeam Success Percentages:"
teamSuccessPercentages 
|> List.iter (fun (team, percentage) -> 
    printfn "Team: %s, Success Percentage: %.2f%%" team.Name percentage
)

