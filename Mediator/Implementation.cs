using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    //public abstract class ChatRoom
    //{
    //    public abstract void Register(TeamMember teamMember);
    //    public abstract void Send(string from, string message);
    //}
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IChatRoom
    {
        void Register(TeamMember teamMember);
        void Send(string from, string message);
        void Send(string from,string to, string message);
        void SendTo<T>(string from, string message) where T : TeamMember;
    }
    /// <summary>
    /// Colleague
    /// </summary>
    public abstract class TeamMember
    {
        private IChatRoom? _chatRoom;
        public string Name { get; set; }
        public TeamMember( string name)
        {
            Name= name;
            
        }
        internal void SetChatroom(IChatRoom chatroom)
        {
            _chatRoom = chatroom;
        }
        public void Send(string   message)
        {
            _chatRoom?.Send(Name, message);
        }
        public void Send(string to,string message)
        {
            _chatRoom?.Send(Name, to,message);
        }
        public void SendTo<T>(string message) where T : TeamMember 
        {
            _chatRoom?.SendTo<T>(Name, message);
        }
        public virtual void Recieve(string from,string message)
        {
            Console.WriteLine($"Message {from}to{Name}:{message}");
        }

    }
    /// <summary>
    /// ConcreteColleague
    /// </summary>
    public class Lawyer :TeamMember
    {
        public Lawyer(string name):base(name)
        { 
        }

        public override void Recieve(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)}{Name} recieved :");
            base.Recieve(from, message);
        }
    }
    /// <summary>
    /// ConcreteColleague
    /// </summary>
    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {
        }

        public override void Recieve(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)}{Name} recieved :");
            base.Recieve(from, message);
        }
    }
    /// <summary>
    /// ConcreteMediator
    /// </summary>
    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> teamMembers = new();
        public void Register(TeamMember teamMember)
        {
            teamMember.SetChatroom(this);
            if (!teamMembers.ContainsKey(teamMember.Name))
            {
                teamMembers.Add(teamMember.Name,teamMember);
            }
        }
        public void Send(string from,string message)
        {
            foreach (var teamMember in teamMembers.Values)
            {
                teamMember.Recieve(from, message);
            }
        }

        public void Send(string from, string to, string message)
        {
            var teamMember = teamMembers[to];
            teamMember?.Recieve(from, message);
        }

        public void SendTo<T>(string from, string message) where T : TeamMember
        {
            foreach(var teamMember in teamMembers.Values.OfType<T>())
            {
                teamMember.Recieve(from, message);
            }
        }
    }
}
