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
            if (!Players.Any(foundPlayer => foundPlayer.id == playerId))
            {
                throw new PlayerNotFoundException();
            }

            Player player = Players.Find(foundPlayer => foundPlayer.id == playerId);
            Team team = Teams.Find(foundTeam => foundTeam.id == player.teamId);

            if (team.captainId != -1)
            {
                Player currentCaptain = Players.Find(foundCurrentCaptain => foundCurrentCaptain.id == team.captainId);
                currentCaptain.isCaptain = false;
            }

            player.isCaptain = true;
            team.captainId = player.id;
        }

        public long GetTeamCaptain(long teamId)
        {
            if (!Teams.Any(foundTeam => foundTeam.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            Team team = Teams.Find(foundTeam => foundTeam.id == teamId);

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
                .Select(player => player.name).FirstOrDefault();
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
                .OrderByDescending(player => player.skillLevel).ThenBy(player => player.id)
                .Select(player => player.id).FirstOrDefault();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            return Players
                .Where(player => player.teamId == teamId)
                .OrderBy(player => player.birthDate).ThenBy(player => player.id)
                .Select(player => player.id).FirstOrDefault();
        }

        public List<long> GetTeams()
        {
            return Teams
                .Select(team => team.id)
                .OrderBy(team => team).ToList();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            return Players
                .Where(player => player.teamId == teamId)
                .OrderByDescending(player => player.salary).ThenBy(player => player.id)
                .Select(player => player.id).FirstOrDefault();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            if (!Players.Any(player => player.id == playerId))
            {
                throw new PlayerNotFoundException();
            }

            return Players
                .Where(player => player.id == playerId)
                .OrderByDescending(player => player.salary)
                .Select(player => player.salary).FirstOrDefault();
        }

        public List<long> GetTopPlayers(int top)
        {
            return Players
                .OrderByDescending(player => player.skillLevel).ThenBy(player => player.id)
                .Take(top)
                .Select(player => player.id).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            if (!Teams.Any(team => team.id == teamId))
            {
                throw new TeamNotFoundException();
            }

            Team homeTeam = Teams.Find(home => home.id == teamId);
            Team visitorTeam = Teams.Find(visitor => visitor.id == visitorTeamId);

            return homeTeam.mainShirtColor == visitorTeam.mainShirtColor ? visitorTeam.secondaryShirtColor : visitorTeam.mainShirtColor;
        }

    }
}