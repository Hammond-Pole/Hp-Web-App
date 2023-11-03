using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hp_Web_App.Shared.Models;

namespace Hp_Web_App.Shared.AppServices;
public interface IClientService
{
    Task<Clients_Details> GetClientsAsync();
    Task<Clients_Details> CreateUserAsync(Clients_Details user);
    Task<Clients_Details> GetClientbyTokenAsync(string RegistrationKey);
    Task<bool> VerifyToken(string token);
}
