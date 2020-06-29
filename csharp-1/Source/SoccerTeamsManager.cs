using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source.Modelagem;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {

        private List<Team> Teams { get; set; }
        private List<Player> Players { get; set; }

        public SoccerTeamsManager()
        {
            Teams = new List<Team>();
            Players = new List<Player>();
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Team newTeam = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);

            if (Teams.Any(team => team.id == newTeam.id))
            {
                throw new UniqueIdentifierException();
            }

            Teams.Add(newTeam);
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            Player newPlayer = new Player(id, teamId, name, birthDate, skillLevel, salary);

            if (Players.Any(player => player.id == newPlayer.id))
            {
                throw new UniqueIdentifierException();
            }

            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            Players.Add(newPlayer);
        }

        public void SetCaptain(long playerId)
        {
            if (!Players.Any(player => player.id == playerId))
            {
                throw new PlayerNotFoundException();
            }

            Player player = Players.Find(player => player.id == playerId);
            Team team = Teams.Find(team => team.id == player.teamId);

            if (team.captainId != -1)
            {
                Player currentCaptain = Players.Find(currentCaptain => currentCaptain.id == team.captainId);
                currentCaptain.isCaptain = false;
            }

            player.isCaptain = true;
            team.captainId = player.id;
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            Team team = Teams.Find(team => team.id == teamId);

            if (team.captainId == -1)
            {
                throw new CaptainNotFoundException();
            }

            return team.captainId;
        }

        public string GetPlayerName(long playerId)
        {
            if (!Players.Any(player => player.id == playerId))
            {
                throw new PlayerNotFoundException();
            }

            return Players
                .Where(player => player.id == playerId)
                .Select(player => player.name).FirstOrDefault<string>();
        }

        public string GetTeamName(long teamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            return Teams
                .Where(team => team.id == teamId)
                .Select(team => team.name).FirstOrDefault();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            if (!Teams.Any(team => team.id ==teamId))
            {
                throw new TeamNotFoundException();
            }

            return Players
                .Where(player => player.teamId == teamId)
                .Select(player => player.id)
                .OrderBy(player => player).ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            return Players
                .Where(player => player.teamId == teamId)
                .OrderByDescending(player => player.skillLevel)
                .Select(player => player.id)
                .FirstOrDefault();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            return Players
                .Where(player => player.teamId == teamId)
                .OrderBy(player => player.birthDate)
                .OrderBy(player => player.id)
                .FirstOrDefault();
        }

        public List<long> GetTeams()
        {
            return Teams
                .Select(team => team.id)
                .OrderBy(team => team).ToList();
        }

        public List<long> GetPlayers()
        {
            return Players
                .Select(player => player.id).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTopPlayers(int top)
        {
            throw new NotImplementedException();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            throw new NotImplementedException();
        }

    }
}
