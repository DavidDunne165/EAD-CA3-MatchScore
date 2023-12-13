using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;
// Models
namespace MatchScore.Models
{
    public class FixtureResponse
    {
        [JsonPropertyName("response")]
        public List<Fixture>? Response { get; set; }
    }

    public class Fixture
    {
        [JsonPropertyName("fixture")]
        public FixtureDetails? Details { get; set; }

        [JsonPropertyName("league")]
        public League? League { get; set; }

        [JsonPropertyName("teams")]
        public Teams? Teams { get; set; }

        [JsonPropertyName("goals")]
        public Goals? Goals { get; set; }

        [JsonPropertyName("score")]
        public Score? Score { get; set; }
    }

    public class FixtureDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("referee")]
        public string? Referee { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("periods")]
        public Periods? Periods { get; set; }

        [JsonPropertyName("venue")]
        public Venue? Venue { get; set; }

        [JsonPropertyName("status")]
        public Status? Status { get; set; }

        public DateTime LocalTime => Date.ToLocalTime();
    }

    public class Periods
    {
        [JsonPropertyName("first")]
        public long? First { get; set; }

        [JsonPropertyName("second")]
        public long? Second { get; set; }
    }

    public class Venue
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }
    }

    public class Status
    {
        [JsonPropertyName("long")]
        public string? Long { get; set; }

        [JsonPropertyName("short")]
        public string? Short { get; set; }

        [JsonPropertyName("elapsed")]
        public int? Elapsed { get; set; }
    }

    public class StatisticsResponse
    {
        [JsonPropertyName("response")]
        public List<TeamStatistics>? Response { get; set; }
    }

    public class TeamStatistics
    {
        [JsonPropertyName("team")]
        public Team? Team { get; set; }

        [JsonPropertyName("statistics")]
        public List<Statistic>? Statistics { get; set; }
    }

    public class Statistic
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("value")]
        public object? Value { get; set; }
    }

    public class StandingsResponse
    {
        [JsonPropertyName("response")]
        public List<StandingsLeague>? Response { get; set; }
    }

    public class StandingsLeague
    {
        [JsonPropertyName("league")]
        public LeagueWithStandings? League { get; set; }
    }

    public class LeagueWithStandings
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("standings")]
        public List<List<Standing>>? Standings { get; set; }
    }

    public class Standing
    {
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("team")]
        public Team? Team { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("goalsDiff")]
        public int GoalsDiff { get; set; }

        [JsonPropertyName("group")]
        public string? Group { get; set; }

        [JsonPropertyName("form")]
        public string? Form { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("all")]
        public PlayedGames? All { get; set; }

        [JsonPropertyName("home")]
        public PlayedGames? Home { get; set; }

        [JsonPropertyName("away")]
        public PlayedGames? Away { get; set; }

        [JsonPropertyName("update")]
        public DateTime Update { get; set; }
    }

    public class PlayedGames
    {
        [JsonPropertyName("played")]
        public int? Played { get; set; }

        [JsonPropertyName("win")]
        public int? Win { get; set; }

        [JsonPropertyName("draw")]
        public int? Draw { get; set; } 

        [JsonPropertyName("lose")]
        public int? Lose { get; set; } 

        [JsonPropertyName("goals")]
        public Goals? Goals { get; set; }
    }


    public class LineupsResponse
    {
        [JsonPropertyName("response")]
        public List<TeamLineup>? Response { get; set; }
    }

    public class TeamLineup
    {
        [JsonPropertyName("team")]
        public Team? Team { get; set; }

        [JsonPropertyName("formation")]
        public string? Formation { get; set; }

        [JsonPropertyName("startXI")]
        public List<LineupPlayer>? StartXI { get; set; }

        [JsonPropertyName("substitutes")]
        public List<LineupPlayer>? Substitutes { get; set; }

        [JsonPropertyName("coach")]
        public Coach? Coach { get; set; }
    }

    public class LineupPlayer
    {
        [JsonPropertyName("player")]
        public Player? Player { get; set; }
        [JsonPropertyName("id")]
        public int? Id { get; set; }
    }

    public class Player
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("pos")]
        public string? Position { get; set; }

        [JsonPropertyName("grid")]
        public string? Grid { get; set; }
    }

    public class Coach
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("photo")]
        public string? Photo { get; set; }
    }

    public class FavouriteClub
    {
        [JsonPropertyName("clubId")]
        public int? ClubId { get; set; }

        [JsonPropertyName("clubName")]
        public string? ClubName { get; set; }
    }

    public class MatchEvent
    {
        [JsonPropertyName("time")]
        public Time? Time { get; set; }

        [JsonPropertyName("team")]
        public Team? Team { get; set; }

        [JsonPropertyName("player")]
        public Player? Player { get; set; }

        [JsonPropertyName("assist")]
        public Player? Assist { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }
    }

    public class MatchEventResponse
    {
        [JsonPropertyName("response")]
        public List<MatchEvent>? Response { get; set; }
    }

    public class Time
    {
        [JsonPropertyName("elapsed")]
        public int Elapsed { get; set; }

        [JsonPropertyName("extra")]
        public int? Extra { get; set; }
    }

    public class Team
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("logo")]
        public string Logo { get; set; }
    }

    public class League
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Logo { get; set; }
        public string? Flag { get; set; }
        public int Season { get; set; }
        public string? Round { get; set; }
    }
    public class Teams
    {
        public Team? Home { get; set; }
        public Team? Away { get; set; }
    }

    public class Goals
    {
        public int? Home { get; set; }
        public int? Away { get; set; }

        [JsonPropertyName("for")]
        public int? For { get; set; }

        [JsonPropertyName("against")]
        public int? Against { get; set; }
    }

    public class Score
    {
        public ScoreDetail? Halftime { get; set; }
        public ScoreDetail? Fulltime { get; set; }
        public ScoreDetail? Extratime { get; set; }
        public ScoreDetail? Penalty { get; set; }
    }

    public class ScoreDetail
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
    }
}
