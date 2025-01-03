using Newtonsoft.Json;
using Questao2.Domain;

public class Program
{
    static async Task Main(string[] args)
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        var totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        try
        {
            List<GameResult> allData1 = await GetAllDataAsync(team, year, 1);

            var goalsHome = allData1.Select(t => t.team1goals).Sum();

            List<GameResult> allData2 = await GetAllDataAsync(team, year, 2);

            var goalsVisitor = allData2.Select(t => t.team2goals).Sum();

            return goalsHome + goalsVisitor;

        }
        catch
        {
            return 0;
        }        
    }

    static async Task<List<GameResult>> GetAllDataAsync(string teamName, int year, int variation)
    {
        string baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";

        List<GameResult> allData = new List<GameResult>();
        using HttpClient client = new HttpClient();
        int page = 1;
        bool moreData = true;

        while (moreData)
        {
            string url = string.Empty;
            if (variation == 1) {
                url = $"{baseUrl}?page={page}&team1={teamName}&year={year}";
            } else
            {
                url = $"{baseUrl}?page={page}&team2={teamName}&year={year}";
            }

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ApiResponse>(json);

                    if (result != null && result.data.Count > 0)
                    {
                        allData.AddRange(result.data);
                        page++;
                    }
                    else
                    {
                        moreData = false;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    moreData = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        return allData;
    }

}