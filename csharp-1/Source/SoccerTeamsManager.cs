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
            throw new NotImplementedException();
        }

        public void SetCaptain(long playerId)
        {
            throw new NotImplementedException();
        }

        public long GetTeamCaptain(long teamId)
        {
            throw new NotImplementedException();
        }

        public string GetPlayerName(long playerId)
        {
            throw new NotImplementedException();
        }

        public string GetTeamName(long teamId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            throw new NotImplementedException();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            throw new NotImplementedException();
        }

        public List<long> GetTeams()
        {
            throw new NotImplementedException();
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
