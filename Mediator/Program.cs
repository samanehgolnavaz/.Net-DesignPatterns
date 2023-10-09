// See https://aka.ms/new-console-template for more information
using Mediator;

TeamChatRoom teamChatRoom = new();
var jan = new Lawyer("jan");
var jimi = new Lawyer("jimi");
var anna = new AccountManager("anna");
var john = new AccountManager("john");
var kaylli = new AccountManager("kayli");

teamChatRoom.Register(jan);
teamChatRoom.Register(jimi);
teamChatRoom.Register(anna);
teamChatRoom.Register(john);
teamChatRoom.Register(kaylli);

anna.Send("Hi Everyone this is a test");
jimi.Send("OK");
jimi.Send("anna", "Could you call me?");
anna.SendTo<AccountManager>("The file is recieved");
Console.ReadKey();

