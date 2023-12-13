using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MatchScore.Models;

namespace MatchScore.Services
{
    public class FootballApiService
    {
        private readonly HttpClient _httpClient;

        public FootballApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Fixture>> GetFixturesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var fixtures = new List<Fixture>();
            try
            {
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    var dateString = date.ToString("yyyy-MM-dd");
                    var response = await _httpClient.GetFromJsonAsync<FixtureResponse>($"https://api-football-v1.p.rapidapi.com/v3/fixtures?date={dateString}");
                    if (response?.Response != null)
                    {
                        fixtures.AddRange(response.Response);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return fixtures;
        }


        public async Task<StatisticsResponse?> GetMatchStatisticsAsync(int matchId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<StatisticsResponse>($"https://api-football-v1.p.rapidapi.com/v3/fixtures/statistics?fixture={matchId}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred fetching statistics: {ex.Message}");
                return null;
            }
        }

        public async Task<List<StandingsLeague>> GetLeagueStandingsAsync(int leagueId, int season)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<StandingsResponse>($"https://api-football-v1.p.rapidapi.com/v3/standings?league={leagueId}&season={season}");
                if (response?.Response != null)
                {
                    return response.Response;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred fetching league standings: {ex.Message}");
            }
            return new List<StandingsLeague>();
        }

        public async Task<LineupsResponse?> GetMatchLineupsAsync(int matchId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<LineupsResponse>($"https://api-football-v1.p.rapidapi.com/v3/fixtures/lineups?fixture={matchId}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred fetching lineups: {ex.Message}");
                return null;
            }
        }

        public async Task<List<MatchEvent>> GetMatchEventsAsync(int matchId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<MatchEventResponse>($"https://api-football-v1.p.rapidapi.com/v3/fixtures/events?fixture={matchId}");
                if (response?.Response != null)
                {
                    return response.Response;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred fetching match events: {ex.Message}");
            }

            Console.WriteLine($"An error occurred fetching match events");
            return new List<MatchEvent>();
        }
    }
}
