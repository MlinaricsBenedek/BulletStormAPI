using BulletStormAPI.Dto;
using BulletStormAPI.Model;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

namespace BulletStormAPI.Services
{
    public static class EloHandler 
    {
        const float killsMultiplier = 0.15f;
        const float assistMultiplier = 0.075f;
        const float deathMultiplayer = -0.10f;
        const float winStreakBonus = 1.05f;
        const float Lamdba = 0.2f;


        public static float CalculateELo
            (MatchResultClientDto resultClientDto,List<Result> games,Global global,MatchesDto statistics)
        {
            float perform = PlayerPerformance(resultClientDto.ResulClient);
            float activity = PlayerActivite(GetLastMatch(games));
            float mu = MeasurementUncertainty(activity);
            float consistency = ConsistenciFactor(statistics);
            float stats = MatchesScore(games);
            float quality = MatchQuality(resultClientDto.AggregatedKills, global.AggregatedKills, global.AggregatedMatches);
            float omega = Omega(WinCounter(games));
            float weight = WeightFactor(statistics.ELO);
            float bonus = weight * ((resultClientDto.ResulClient.Won ? 1 : 0) + Lamdba * perform + mu * (consistency * activity * stats) +quality + (resultClientDto.ResulClient.Won ? 1 : 0)*(omega * WinCounter(games)));
           
            float delta = statistics.ELO - resultClientDto.AvarageElo;
            float impact = 1f / (1f + MathF.Pow(10f, -delta / 400f));
            float gameResult = resultClientDto.ResulClient.Won ? 1f : 0f;
            float basicELO = weight * (gameResult - impact);
            float newElo = statistics.ELO + (0.3f * bonus + 0.7f * basicELO);
            return newElo;
        }

        private static float PlayerPerformance(ResulClientDto result)
        {
            float score = 0f;

            score += result.Kill * killsMultiplier;
            score += result.Assist * assistMultiplier;
            score += result.Deaths * deathMultiplayer;
            score = Math.Clamp(score, 0f, 1f);
            return score;
        }

        private static float PlayerPerformance(Result result)
        {
            float score = 0f;

            score += result.Kill * killsMultiplier;
            score += result.Assist * assistMultiplier;
            score += result.Deaths * deathMultiplayer;
            score = Math.Clamp(score, 0f, 1f);
            return score;
        }

        private static float PlayerActivite(DateTime lastMatch)
        {
            TimeSpan elapsedDate = DateTime.Now - lastMatch;
            int days = elapsedDate.Days;
            double insecurity = MathF.Exp((float)days * (-0.5f));
            return (float)insecurity;
        }

        private static float MeasurementUncertainty(float recency)
        {
            var value = 0.05f + 0.2f * recency;

            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        private static float ConsistenciFactor(MatchesDto statistics)
        {
            float oldSigma = 0.0f;
            ResulClientDto stats = new()
            {
                Kill = statistics.AggregatedKills,
                Assist = statistics.AggregatedAssits,
                Deaths = statistics.AggregatedDeath,
            };

            oldSigma = PlayerPerformance(stats);
            oldSigma = oldSigma / (float)statistics.AggregatedMatches + 1;

            return 1.0f / oldSigma;
        }

        private static float MatchesScore(List<Result> playerStats)
        {
            float score = 0f;
            foreach (var stat in playerStats)
            {
                score += PlayerPerformance(stat);
            }
            return score / playerStats.Count;
        }

        private static float MatchQuality(int kill, int aggregatedKills, int aggregatedMatches)
        {
            float generalKillsPerGame = (float)aggregatedKills / aggregatedMatches;
            float ratio = (float)kill / generalKillsPerGame;
            float score =0.05f * (1 - ratio);
            return Math.Clamp(score, -0.05f, 0.05f);
        }

        private static float Omega(int wins)
        {
            float value = 0.05f * MathF.Sqrt(wins);
            return Math.Clamp(value * wins, 0, 0.15f);
        }

        private static float WeightFactor(float oldELO)
        {
            int maxElo = 3600;
            int maxWeight = 40;
            float x = 1 - ((float)oldELO / maxElo);

            float K = Math.Clamp(x * maxWeight, 5, maxWeight);
            return K;
        }

        private static DateTime GetLastMatch(List<Result> matches)
        {
            matches.Sort((a, b) => a.UpdatedAt.CompareTo(b.UpdatedAt));
            return matches.FirstOrDefault().UpdatedAt;
        }

        private static int WinCounter(List<Result> games)
        {
            int counter = 0;

            foreach (var game in games)
            {
                if (game.Won is true)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }
            return counter;
        }

    }
}
