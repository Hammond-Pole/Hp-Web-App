using Hp_Web_App.Shared.DbContexts;
using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hp_Web_App.Shared.AppServices;
public class ClientService : IClientService
{
    private readonly DbWebAppContext _context;

    public ClientService (DbWebAppContext context)
    { 
        _context = context; 
    }


    public async Task<Clients_Details> CreateUserAsync(Clients_Details client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "User cannot be null.");
        }


        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Clients_Details> GetClientbyTokenAsync(string RegistrationKey)
    {
        // find user by id and include the UserRole.
        var client = await _context.Set<Clients_Details>()
            .Where(u => u.RegistrationKey == RegistrationKey)
            .FirstOrDefaultAsync();

        return client ?? new Clients_Details();
    }

    public Task<Clients_Details> GetClientsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> VerifyToken(string token)
    {
        throw new NotImplementedException();
    }
}
