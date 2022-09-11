using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PYP_PhoneDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PYP_PhoneDirectory.Helpers
{
    public static class Helper
    {
        public const string AddInfo = "a";
        public const string ShowAllInfo = "l";
        public const string SearchInfo = "s";
        public const string Exit = "e";

        public const string ConnectionString = "server=DESKTOP-8J9LQBU;database=PhoneDirectory;Trusted_Connection=True;";
        public static void Print(object text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static string AddQueryGenerate<T>(T model)
        {
            string command = "";
            command += $"insert into {typeof(T).Name.ToString()} (";
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.Name.Contains("Id"))
                    continue;
                command += property.Name + ",";
            }
            command=command.Substring(0, command.Length-1);
            command += ") values (";
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.Name.Contains("Id")) continue;
                command += "'" + property.GetValue(model) + "'" + ",";
            }
            command=command.Substring(0, command.Length - 1);
            command += ")";
            return command;
        }
        public static bool CheckName(string name)
        {
            var result = new Regex(@"^\b([A-ZÀ-ÿ][-,a-z. ']+[ ]*)+$");
            Match match = result.Match(name);
            return match.Success;
        }
        public static bool CheckNumber(string phoneNumber)
        {
            var result = new Regex(@"^(\+?994|0)(77|51|50|55|70|40|60|12)(\-|)(\d){3}(\-|)(\d){2}(\-|)(\d){2}$");
            Match match = result.Match(phoneNumber);
            return match.Success;
        }
        public static bool CheckEmail(string email)
        {
            var result = new Regex(@"^([a-zA-Z]+[a-zA-z.!#$%&'*+-=?^`{|}~]{0,64})+[@]+[a-zA-z-]+[.]+[a-zA-z]+$");
            Match m = result.Match(email);
            return m.Success;
        }
    }
}
